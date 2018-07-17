using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Presentation.DI;

namespace Xamarin.Presentation.Navigation {
    public interface ICommutator {
        //Task GoTo(Type type);
        //Task<TVM> GoTo<TVM>(Type type);


        /// <summary>
        /// will craete View/ViewModel itself
        /// </summary>
        //Task<TVM> GoTo<TVM>(INavigation nav) where TVM : class;

        /// <summary>
        /// ViewModel will nor been created, it will get from View.BindingContext
        /// ViewModel must be binded to View in XAML 
        /// </summary>
        Task<TViewModel> GoToPage<TViewModel>(INavigation nav) where TViewModel : class;
        //Task<TVM> GoTo<TView, TVM>() where TView : Page;
        //Task<TVM> OpenModal<T, TVM>();
        //void CloseModal();
    }

    public class NavigationAdapter : ICommutator {
        private readonly ViewModelContainer container;

        //  private readonly MainPage main;
        private INavigation navigation => Application.Current.MainPage.Navigation;
        public NavigationAdapter(ViewModelContainer container) {
            this.container = container;
        }

        //public async Task<TVM> GoTo<TVM>(INavigation nav) where TVM : class {
        //    var displayPage = container.GetView<TVM, Page>();
        //    displayPage.BindingContext = container.GetViewModel<TVM>();

        //    await nav.PushAsync(displayPage);

        //    return (TVM)displayPage.BindingContext;
        //}

        public async Task<TViewModel> GoToPage<TViewModel>(INavigation nav) where TViewModel : class {
            var displayPage = container.GetView<TViewModel, Page>();
            
            await nav.PushAsync(displayPage);

            return (TViewModel)displayPage.BindingContext;
        }

        private NavigationPage GetNavigationPage(Page destinationPage) {
            NavigationPage navigationPage = null;
            var main = Application.Current.MainPage as MasterDetailPage;
            if (main.IsNotNull()) {
                navigationPage = main.Detail as NavigationPage;
            }
            if (navigationPage.IsNull()) {
                navigationPage = new NavigationPage(destinationPage);
            }
            if (main.IsNotNull()) {
                main.IsPresented = false;
            }
            return navigationPage;
        }
        private async Task<TVM> GoTo<TVM>(Type type) {
            var displayPage = (Page)Activator.CreateInstance(type);
            //await GetNavigationPage(displayPage).PushAsync(displayPage);

            await navigation.PushAsync(new NavigationPage(displayPage));

            displayPage.BindingContext = container.GetViewModel(type);
            return (TVM)displayPage.BindingContext;
            //Application.Current.MainPage = new NavigationPage(new Login());
        }
        private async Task<TVM> GoTo<TView, TVM>() where TView : Page {
            return await GoTo<TVM>(typeof(TView));
        }
        private async Task GoTo(Type type) {
            await GoTo<object>(type);
        }

        private async Task<TVM> OpenModal<T, TVM>() {
            var type = typeof(T);
            var displayPage = (Page)Activator.CreateInstance(type);
            await navigation.PushModalAsync(displayPage);
            displayPage.BindingContext = container.GetViewModel(type);
            return (TVM)displayPage.BindingContext;
        }

        private async void CloseModal() {
            var page = await navigation.PopModalAsync();

            //navigation.RemovePage(type);
        }


    }

}
