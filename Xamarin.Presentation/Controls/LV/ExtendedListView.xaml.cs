
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Controls.LV {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExtendedListView : ContentView {

        public static readonly BindableProperty ItemSelectedCommandProperty =
           BindableProperty.CreateAttached(nameof(ItemSelectedCommand), typeof(ICommand), typeof(ExtendedListView), null, propertyChanged: OnItemSelectedPropertyChanged);

        private static void OnItemSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (ExtendedListView)bindable;
            _this.ExdListView.Behaviors.Remove(_this.itemSelectedBehavior);
            _this.itemSelectedBehavior.ItemSelected = (ICommand)newValue;
            _this.ExdListView.Behaviors.Add(_this.itemSelectedBehavior);
        }

        public ICommand ItemSelectedCommand {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(PullToRefreshProperty, value); }
        }

        public static readonly BindableProperty PullToRefreshProperty =
                  BindableProperty.CreateAttached(nameof(PullToRefresh), typeof(ListViewPullToRefreshViewModel), typeof(ExtendedListView), null, propertyChanged: OnPullToRefreshPropertyChanged);

        private static void OnPullToRefreshPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (ExtendedListView)bindable;
            _this.ExdListView.Behaviors.Remove(_this.pullToRefreshBehavior);
            _this.pullToRefreshBehavior.PullToRefresh =(ListViewPullToRefreshViewModel) newValue;
            _this.ExdListView.Behaviors.Add(_this.pullToRefreshBehavior);
        }

        public ListViewPullToRefreshViewModel PullToRefresh {
            get { return (ListViewPullToRefreshViewModel)GetValue(PullToRefreshProperty); }
            set { SetValue(PullToRefreshProperty, value); }
        }

        public DataTemplate ItemTemplate { set { ExdListView.ItemTemplate = value; } }

        readonly ListViewItemSelectedBehavior itemSelectedBehavior;
        readonly ListViewPullToRefreshBehavior pullToRefreshBehavior;
        public ExtendedListView() {
            InitializeComponent();
            itemSelectedBehavior = new ListViewItemSelectedBehavior();
            pullToRefreshBehavior = new ListViewPullToRefreshBehavior();
        }
    }

    /*     
      <ListView.Behaviors>
        <crl:ListViewItemSelectedBehavior ItemSelected="{Binding Source={x:Reference Name=ExdListView}, Path=ItemSelectedCommand}" />
        <crl:ListViewPullToRefreshBehavior PullToRefresh="{Binding Source={x:Reference Name=ExdListView}, Path=PullToRefresh}" />
    </ListView.Behaviors>

     */
}