
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Controls.LV {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExtendedListView : ListView {

        #region selected 

        public static readonly BindableProperty ItemSelectedCommandProperty =
          BindableProperty.CreateAttached(nameof(ItemSelectedCommand), typeof(ICommand), typeof(ExtendedListView), null, propertyChanged: OnItemSelectedPropertyChanged);

        private static void OnItemSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (ExtendedListView)bindable;
            DispatcherEx.BeginRise(() => {
                _this.ExdListView.Behaviors.Remove(_this.itemSelectedBehavior);
                _this.itemSelectedBehavior.ItemSelected = (ICommand)newValue;
                _this.ExdListView.Behaviors.Add(_this.itemSelectedBehavior);
            });
        }

        public ICommand ItemSelectedCommand {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        #endregion

        #region pull refresh

        public static readonly BindableProperty PullToRefreshProperty =
                 BindableProperty.CreateAttached(nameof(PullToRefresh), typeof(ListViewPullToRefreshViewModel), typeof(ExtendedListView), null, propertyChanged: OnPullToRefreshPropertyChanged);

        private static void OnPullToRefreshPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (ExtendedListView)bindable;
            DispatcherEx.BeginRise(() => {
                _this.ExdListView.Behaviors.Remove(_this.pullToRefreshBehavior);
                _this.pullToRefreshBehavior.PullToRefresh = (ListViewPullToRefreshViewModel)newValue;
                _this.ExdListView.Behaviors.Add(_this.pullToRefreshBehavior);
            });
        }

        public ListViewPullToRefreshViewModel PullToRefresh {
            get { return (ListViewPullToRefreshViewModel)GetValue(PullToRefreshProperty); }
            set { SetValue(PullToRefreshProperty, value); }
        }

        #endregion

        #region appering

        public static readonly BindableProperty ItemAppearedCommandProperty =
           BindableProperty.CreateAttached(nameof(ItemAppearedCommand), typeof(ICommand), typeof(ExtendedListView), null, propertyChanged: OnItemAppearedPropertyChanged);

        private static void OnItemAppearedPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (ExtendedListView)bindable;
            DispatcherEx.BeginRise(() => {
                _this.ExdListView.Behaviors.Remove(_this.itemAppearingBehavior);
                _this.itemAppearingBehavior.ItemAppeared = (ICommand)newValue;
                _this.ExdListView.Behaviors.Add(_this.itemAppearingBehavior);
            });
        }

        public ICommand ItemAppearedCommand {
            get { return (ICommand)GetValue(ItemAppearedCommandProperty); }
            set { SetValue(ItemAppearedCommandProperty, value); }
        }

        #endregion

        //   public DataTemplate ItemTemplate { set { ExdListView.ItemTemplate = value; } }

        readonly ListViewItemSelectedBehavior itemSelectedBehavior;
        readonly ListViewPullToRefreshBehavior pullToRefreshBehavior;
        readonly ListItemAppearingBehavior itemAppearingBehavior;
        public ExtendedListView() : base(ListViewCachingStrategy.RecycleElement) {
            InitializeComponent();
            itemSelectedBehavior = new ListViewItemSelectedBehavior();
            pullToRefreshBehavior = new ListViewPullToRefreshBehavior();
            itemAppearingBehavior = new ListItemAppearingBehavior();
            // ExdListView.ItemSelected += OnItemSelected;
#if DEBUG
            this.BindingContextChanged += ExtendedListView_BindingContextChanged;
#endif
        }

        private void ExtendedListView_BindingContextChanged(object sender, EventArgs e) {
            var bc = this.BindingContext;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            //this.ScrollTo(, ScrollToPosition.End, true);
        }
    }

    /*     
      <ListView.Behaviors>
        <crl:ListViewItemSelectedBehavior ItemSelected="{Binding Source={x:Reference Name=ExdListView}, Path=ItemSelectedCommand}" />
        <crl:ListViewPullToRefreshBehavior PullToRefresh="{Binding Source={x:Reference Name=ExdListView}, Path=PullToRefresh}" />
    </ListView.Behaviors>

     */
}