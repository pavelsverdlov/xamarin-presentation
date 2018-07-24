using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Pages.Tab {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : ContentPage {
        public static readonly BindableProperty TabControlSelectorProperty = BindableProperty.CreateAttached(nameof(TabControlSelector),
            typeof(ITabControlTemplateSelector), typeof(TabPage), null, propertyChanged: OnTabControlSelectorChanged);

        public ITabControlTemplateSelector TabControlSelector {
            get { return (ITabControlTemplateSelector)GetValue(TabControlSelectorProperty); }
            set { SetValue(TabControlSelectorProperty, value); }
        }

        private static void OnTabControlSelectorChanged(BindableObject bindable, object oldValue, object newValue) {
            TabPage _this = (TabPage)bindable;
            int btnCount = _this.TabControlSelector.Count;
            //todo
        }

        //private TabPresenter pr;
        public TabPage() {
            //pr = new TabPresenter();
            //BindingContext = pr;
            InitializeComponent();
        }

        private void cv_BindingContextChanged(object sender, EventArgs e) {
            ITabPage tab = cv.BindingContext as ITabPage;
            if (tab.IsNull() || TabControlSelector.IsNull()) {
                return;
            }
            cv.ControlTemplate = TabControlSelector.GetTemplate(tab);

        }
    }
}