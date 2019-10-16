using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Pages {
    public interface IPageNavigatorSupporting {
        IPageNavigator PageNavigator { get; }
    }

    public interface INavigationDecorator {
        bool IsPresented { get; set; }
        string Title { get; set; }
        string IconSource { get; set; }
        bool IsBusy { get; set; }
        IList<ToolbarItem> ToolbarMenu { get; }
        INavigation Navigation { get; }
    }
    public interface IPageNavigator : INavigationDecorator {       
        void UpdateNavigation(NavigationPage nav);
        void UpdateNavigation(ContentPage nav);

        void UpdateNavigation(MasterDetailPage master);
        void UpdateDetail(NavigationPage master);
    }

    public class PageNavigatorAdapter : IPageNavigator {
        public string Title {
            get => decorator.Title;
            set {
                decorator.Title = value;
            }
        }
        public string IconSource {
            get => decorator.IconSource;
            set {
                decorator.IconSource = value;
            }
        }
        public bool IsBusy {
            get => decorator.IsBusy;
            set {
                decorator.IsBusy = value;
            }
        }
        public bool IsPresented {
            get => decorator.IsPresented;
            set {
                decorator.IsPresented = value;
            }
        }

        public IList<ToolbarItem> ToolbarMenu {
            get => decorator.ToolbarMenu;
        }
        public INavigation Navigation {
            get => decorator.Navigation;
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
            decorator.ToolbarMenu.ForEach(x => dec.ToolbarMenu.Add(x));
            decorator = dec;
        }
        public void UpdateNavigation(ContentPage page) {
            var dec = new ContentNavigationPageDecorator(page);
            dec.Title = decorator.Title;
            dec.IconSource = decorator.IconSource;
            dec.IsBusy = decorator.IsBusy;
            decorator.ToolbarMenu.ForEach(x => dec.ToolbarMenu.Add(x));
            decorator = dec;
        }

        public void UpdateNavigation(MasterDetailPage master) {
            decorator = new MasterDetailDecorator(master);
        }

        public void UpdateDetail(NavigationPage nav) {
           if(decorator is MasterDetailDecorator master) {
                master.UpdateDetail(nav);
            }
        }
    }

    public class ContentNavigationPageDecorator : INavigationDecorator {
        readonly ContentPage page;

        public bool IsPresented {
            get => page.IsBusy;
            set {
                page.IsBusy = value;
            }
        }
        public string Title {
            get => page.Title;
            set => page.Title = value;
        }
        public string IconSource {
            get => page.Icon;
            set => page.Icon = value;
        }
        public bool IsBusy {
            get => page.IsBusy;
            set {
                page.IsBusy = value;
            }
        }
        public IList<ToolbarItem> ToolbarMenu {
            get => page.ToolbarItems;
        }
        public INavigation Navigation { get => page.Navigation; }

        public ContentNavigationPageDecorator(ContentPage page) {
            this.page = page;
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

        public IList<ToolbarItem> ToolbarMenu => toolbar;
        readonly List<ToolbarItem> toolbar;
        public INavigation Navigation { get; set; }
        public bool IsPresented { get; set; }

        public NoNavigationPageDecorator() {
            toolbar = new List<ToolbarItem>();
        }

    }
    public class NavigationPageDecorator : INavigationDecorator {
        public bool IsPresented {
            get => nav.IsBusy;
            set {
                nav.IsBusy = value;
            }
        }
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
        }
        public INavigation Navigation {
            get => nav.Navigation;
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
    public class MasterDetailDecorator : INavigationDecorator {
        public string Title {
            get => master.Title;
            set {
                master.Title = value;
                nav.Do(x => x.Title = value);
            }
        }
        public string IconSource {
            get => master.Icon;
            set {
                master.Icon = value;
                nav.Do(x => x.Icon = value);
            }
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

        public IList<ToolbarItem> ToolbarMenu {
            get  {
                return master.ToolbarItems;
            }
        }
        public INavigation Navigation {
            get => master.Detail.Navigation;
            set { }
        }

        MasterDetailPage master;
        NavigationPage nav;

        public MasterDetailDecorator(MasterDetailPage master) {
            this.master = master;
        }
        public void UpdateMaster(MasterDetailPage master) {
            this.master = master;
        }
     
        public void UpdateDetail(NavigationPage nav) {
            this.nav = nav;
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
    }
}
