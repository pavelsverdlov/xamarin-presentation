using Xamarin.Forms;

namespace Xamarin.Presentation.Pages {
   /*
    public class ViewNavigatorBehavior : Behavior<VisualElement> {
        public static readonly BindableProperty NavigatorProperty = BindableProperty.CreateAttached(nameof(Navigator), typeof(IPageNavigator), typeof(PageNavigatorBehavior), null);

        public IPageNavigator Navigator {
            get { return (IPageNavigator)GetValue(NavigatorProperty); }
            set { SetValue(NavigatorProperty, value); }
        }

        protected override void OnAttachedTo(VisualElement bindable) {
            base.OnAttachedTo(bindable);

            if (Navigator.IsNull()) {
                return;
            }

            Navigator.Navigation = bindable.Navigation;

            if (bindable.Navigation is NavigationPage navigation) {
                Navigator.UpdateNavigation(navigation);
            } else {
                Navigator.UpdateNavigation(navigation);
            }
        }
    }
    */
    public class PageNavigatorBehavior : Behavior<ContentPage> {
        public static readonly BindableProperty PageProperty = BindableProperty.CreateAttached(nameof(Page), typeof(IPageNavigator), typeof(PageNavigatorBehavior), null);

        public IPageNavigator Page {
            get { return (IPageNavigator)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }
        protected override void OnAttachedTo(ContentPage bindable) {
            base.OnAttachedTo(bindable);

            if (Page.IsNull()) {
                return;
            }

            //bindable.SetBinding(ContentPage.IconProperty, new Binding(nameof(Page.IconSource), BindingMode.OneWay, source: Page));
            //bindable.SetBinding(ContentPage.TitleProperty, new Binding(nameof(Page.Title), BindingMode.OneWay, source: Page));
            //bindable.SetBinding(ContentPage.IsBusyProperty, new Binding(nameof(Page.IsBusy), BindingMode.OneWay, source: Page));
            
            //foreach (ToolbarItem item in Page.ToolbarMenu) {
            //    bindable.ToolbarItems.Add(item);
            //}

            //Page.Navigation = bindable.Navigation;

            if (bindable.Navigation is NavigationPage navigation) {
                //this.Page.Navigation = navigation;
                navigation.SetBinding(NavigationPage.IconProperty, new Binding(nameof(Page.IconSource), BindingMode.OneWay, source: Page));
                navigation.SetBinding(NavigationPage.TitleProperty, new Binding(nameof(Page.Title), BindingMode.OneWay, source: Page));
                //NavigationPage.SetTitleIcon(bindable, new FileImageSource() { File="person.png" });
                Page.UpdateNavigation(navigation);
            } else {
                Page.UpdateNavigation(bindable);
                //  var nav = new NavigationPage(bindable);
                // this.Page.Navigation = nav;
            }
        }
    }
    /// <summary>
    /// Behavior should be added after block of 
    ///     </NavigationPage>
    ///  </MasterDetailPage.Detail>
    ///  <MasterDetailPage.Behaviors>
    ///     <pages:MasterDetailPageNavigatorBehavior
    /// 
    /// insteed it does not work ... Detail should be initialized before this Behavior
    /// </summary>
    public class MasterDetailPageNavigatorBehavior : Behavior<MasterDetailPage> {
        public static readonly BindableProperty PageProperty = BindableProperty.CreateAttached(nameof(Page), typeof(IPageNavigator), typeof(PageNavigatorBehavior), null);

        public IPageNavigator Page {
            get { return (IPageNavigator)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }
        protected override void OnAttachedTo(MasterDetailPage bindable) {
            base.OnAttachedTo(bindable);

            if (Page.IsNull()) {
                return;
            }

            //bindable.Icon = this.Page.IconSource;

            //bindable.SetBinding(MasterDetailPage.IconProperty, new Binding(nameof(this.Page.IconSource), BindingMode.OneWay, source: this.Page));
            //bindable.SetBinding(MasterDetailPage.TitleProperty, new Binding(nameof(this.Page.Title), BindingMode.OneWay, source: this.Page));
            //bindable.SetBinding(MasterDetailPage.IsBusyProperty, new Binding(nameof(this.Page.IsBusy), BindingMode.OneWay, source: this.Page));
            //bindable.SetBinding(MasterDetailPage.IsPresentedProperty, new Binding(nameof(this.Page.IsPresented), BindingMode.OneWay, source: this.Page));

            //var dd = Application.Current.MainPage;

            //foreach (var item in this.Page.ToolbarMenu) {
            //    bindable.ToolbarItems.Add(item);
            //}

            //this.Page.Navigation = bindable.Detail.Navigation;
            Page.UpdateNavigation(bindable);
            if (bindable.Detail is NavigationPage nav) {
                Page.UpdateDetail(nav);
            }
        }
    }
}
