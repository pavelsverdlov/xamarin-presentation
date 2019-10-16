using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Pages.Tab {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : ContentPage {
        //BindingContext="{Binding Content}" BindingContextChanged="cv_BindingContextChanged"

        public static readonly BindableProperty TabControlSelectorProperty = BindableProperty.CreateAttached(nameof(TabControlSelector),
            typeof(TabControlTemplateSelector), typeof(TabPage), null, propertyChanged: OnTabControlSelectorChanged);

        public TabControlTemplateSelector TabControlSelector {
            get { return (TabControlTemplateSelector)GetValue(TabControlSelectorProperty); }
            set { SetValue(TabControlSelectorProperty, value); }
        }

        private static void OnTabControlSelectorChanged(BindableObject bindable, object oldValue, object newValue) {
            TabPage _this = (TabPage)bindable;
            int btnCount = _this.TabControlSelector.Count;
            //todo
        }

        public static readonly BindableProperty TabContentProperty = BindableProperty.CreateAttached(nameof(TabContentProperty),
            typeof(ITabPage), typeof(TabPage), null, propertyChanged: OnTabContentPropertyChanged);

        public ITabPage TabContent {
            get { return (ITabPage)GetValue(TabContentProperty); }
            set { SetValue(TabContentProperty, value); }
        }

        private static void OnTabContentPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            TabPage _this = (TabPage)bindable;
            ITabPage tab = _this.TabContent;
            var selector = _this.TabControlSelector;
            if (tab.IsNull() || selector.IsNull()) {
                return;
            }
            selector.ApplyTemplate(_this.cv, tab);
        }

        //private TabPresenter pr;
        public TabPage() {
            //pr = new TabPresenter();
            //BindingContext = pr;
            InitializeComponent();
            //cv.ControlTemplate = TabControlSelector.GetTemplate(new LeftTapContent());
            cv.ChildAdded += Cv_ChildAdded;
            line0.BackgroundColor = Color.White;
        }

        private void Cv_ChildAdded(object sender, ElementEventArgs e) {
            if (TabContent.IsNull()) { return; }
            var ele = e.Element; 
            TabContent.UpdateBindingContext(ele.BindingContext);
        }

        private void btn_Clicked(object sender, EventArgs e) {
            var btn = (Button)sender;
            UnSelectAll();
            switch (btn.CommandParameter.ToString()) {
                case "0":
                    line0.BackgroundColor = Color.White;
                    break;
                case "1":
                    line1.BackgroundColor = Color.White;
                    break;
                case "2":
                    line2.BackgroundColor = Color.White;
                    break;
                case "3":
                    line3.BackgroundColor = Color.White;
                    break;
            }
        }

        void UnSelectAll() {
            line0.BackgroundColor = Color.Transparent;
            line1.BackgroundColor = Color.Transparent;
            line2.BackgroundColor = Color.Transparent;
            line3.BackgroundColor = Color.Transparent;
        }
    }
}