using Xamarin.Presentation.Controls;
using Xamarin.Presentation.Framework.VSVVM;
using Xamarin.Presentation.Navigation;
using Xamarin.Presentation.Pages;

namespace Xamarin.Presentation.Infrastructure {
    public abstract class DefaultCollectionPresenter<TViewState, TController, TCollectionViewItem> :
       BasePresenter<TViewState, TController>,
       IPageNavigatorSupporting
       where TViewState : CollectionViewState<TCollectionViewItem>, new()
       where TController : BaseController, IItemSelectedController<TCollectionViewItem>, new() {

        protected readonly ICommutator commutator;
        protected readonly IXamLogger logger;

        public IPageNavigator PageNavigator { get; }
        public ListViewPullToRefreshViewModel PullToRefresh { get; }

        protected DefaultCollectionPresenter(IXamLogger logger, ICommutator commutator) {
            this.logger = logger;
            this.commutator = commutator;
            PageNavigator = new PageNavigatorAdapter ();
            PullToRefresh = new ListViewPullToRefreshViewModel();
            PullToRefresh.Refreshed += _OnListRefreshed;
        }
        private void _OnListRefreshed() {
            ViewState.ViewCollection.Clear();
            OnListRefreshed();
        }

        protected abstract void OnListRefreshed();
    }
}
