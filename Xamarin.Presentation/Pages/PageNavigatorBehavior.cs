using Xamarin.Forms;

namespace Xamarin.Presentation.Pages {
    public class PageNavigatorBehavior : Behavior<ContentPage> {
        public static readonly BindableProperty PageProperty = BindableProperty.CreateAttached(nameof(Page), typeof(IPageNavigator), typeof(PageNavigatorBehavior), null);

        public IPageNavigator Page {
            get { return (IPageNavigator)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }
        protected override void OnAttachedTo(ContentPage bindable) {
            base.OnAttachedTo(bindable);

            if (this.Page.IsNull()) {
                return;
            }

            bindable.Icon = this.Page.IconSource;
            
            bindable.SetBinding(ContentPage.TitleProperty, new Binding(nameof(this.Page.Title), BindingMode.OneWay, source: this.Page));
            bindable.SetBinding(ContentPage.IsBusyProperty, nameof(this.Page.IsBusy), BindingMode.OneWay);

            foreach (var item in this.Page.ToolbarMenu) {
                bindable.ToolbarItems.Add(item);
            }

            this.Page.Navigation = bindable.Navigation;
        }
    }
}
