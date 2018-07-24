using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Pages {
    public interface IPageNavigatorSupporting {
        IPageNavigator PageNavigator { get; }
    }

    public interface INavigationDecorator {
        string Title { get; set; }
        string IconSource { get; set; }
        bool IsBusy { get; set; }
        IList<ToolbarItem> ToolbarMenu { get; set; }
        INavigation Navigation { get; set; }
    }
    public interface IPageNavigator : INavigationDecorator {
       
        void UpdateNavigation(NavigationPage nav);
    }
    public interface IMasterDetailPageNavigator : INavigationDecorator {
        bool IsPresented { get; set; }

        void UpdateMaster(MasterDetailPage master);
        void UpdateDetail(NavigationPage master);
    }

    public class MasterDetailDecorator : IMasterDetailPageNavigator {
        public string Title {
            get => master.Title;
            set => master.Title = value;
        }
        public string IconSource {
            get => master.Icon;
            set => master.Icon = value;
        }
        public bool IsBusy {
            get => master.IsBusy;
            set {
                master.IsBusy = value;
            }
        }
        public bool IsPresented {
            get => master.IsPresented;
            set {
                master.IsPresented = value;
            }
        }

        public IList<ToolbarItem> ToolbarMenu { get; set; }
        public INavigation Navigation {
            get => master.Detail.Navigation;
            set { }
        }

        private MasterDetailPage master;

        public MasterDetailDecorator() {
            master = new MasterDetailPage();
        }

        public void UpdateMaster(MasterDetailPage master) {
            this.master = master;
        }

        public void UpdateDetail(NavigationPage nav) {
            //var prevpage = (NavigationPage)master.Detail;

            //await prevpage.CurrentPage.FadeTo(0, 100U);
            // prevpage.CurrentPage.IsVisible = false; 
            //await System.Threading.Tasks.Task.Delay(30);

            //nav.CurrentPage.Opacity = 0;
            master.Detail = nav;
            // nav.CurrentPage.IsVisible = true;
            // await nav.CurrentPage.FadeTo(1);
            //nav.Popped += Nav_Popped;
            //nav.PoppedToRoot += Nav_PoppedToRoot;
        }

        //private void Nav_PoppedToRoot(object sender, NavigationEventArgs e) {
        //    var p = e.Page;
        //}

        //private void Nav_Popped(object sender, NavigationEventArgs e) {
        //    var p = e.Page;
        //}
    }

    public class PageNavigatorAdapter : BaseNotify, IPageNavigator {
        public string Title {
            get => decorator.Title;
            set {
                decorator.Title = value;
                SetPropertyChanged();
            }
        }
        public string IconSource {
            get => decorator.IconSource;
            set {
                decorator.IconSource = value;
                SetPropertyChanged();
            }
        }
        public override bool IsBusy {
            get => decorator.IsBusy;
            set {
                decorator.IsBusy = value;
                SetPropertyChanged();
            }
        }

        public IList<ToolbarItem> ToolbarMenu {
            get => decorator.ToolbarMenu;
            set {
                decorator.ToolbarMenu = value;
                SetPropertyChanged();
            }
        }
        public INavigation Navigation {
            get => decorator.Navigation;
            set {
                decorator.Navigation = value;
                SetPropertyChanged();
            }
        }

        INavigationDecorator decorator;
        public PageNavigatorAdapter() {            
            decorator = new NoNavigationPageDecorator();
        }

        public void UpdateNavigation(NavigationPage nav) {
            var dec = new NavigationPageDecorator(nav);
            dec.Title = decorator.Title;
            dec.IconSource = decorator.IconSource;
            dec.IsBusy = decorator.IsBusy;
            dec.ToolbarMenu = decorator.ToolbarMenu;
            decorator = dec;
        }
    }

   
    public class NoNavigationPageDecorator : BaseNotify, INavigationDecorator {
        private bool isBusy;

        public string Title { get; set; }
        public string IconSource { get; set; }
        public override bool IsBusy {
            get => isBusy;
            set {
                isBusy = value;
            }
        }

        public IList<ToolbarItem> ToolbarMenu { get; set; }
        public INavigation Navigation { get; set; }

        public NoNavigationPageDecorator() {
            ToolbarMenu = new List<ToolbarItem>();
        }

    }
    public class NavigationPageDecorator : INavigationDecorator {

        public string Title {
            get => nav.Title;
            set => nav.Title = value;
        }
        public string IconSource {
            get => nav.Icon;
            set => nav.Icon = value;
        }
        public bool IsBusy {
            get => nav.IsBusy;
            set {
                nav.IsBusy = value;
            }
        }

        public IList<ToolbarItem> ToolbarMenu {
            get => nav.ToolbarItems;
            set{ }
        }
        public INavigation Navigation {
            get => nav.Navigation;
            set { }
        }

        private readonly NavigationPage nav;

        public NavigationPageDecorator(NavigationPage nav) {
            this.nav = nav;
            nav.Popped += Nav_Popped;
            nav.PoppedToRoot += Nav_PoppedToRoot;
        }

        private void Nav_PoppedToRoot(object sender, NavigationEventArgs e) {
            var p =e.Page;
        }

        private void Nav_Popped(object sender, NavigationEventArgs e) {
            var p =e.Page;
        }
    }
}
