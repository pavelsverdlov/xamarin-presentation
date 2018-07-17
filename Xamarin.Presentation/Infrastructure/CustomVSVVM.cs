using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Presentation.Controls;
using Xamarin.Presentation.Framework.VSVVM;

namespace Xamarin.Presentation.Infrastructure {
    public interface IItemSelectedController<TItem> {
        Command<TItem> ItemSelectedCommand { get; }
    }
    public class CollectionViewState<TItem> : BaseViewState {
        public List<TItem> ViewCollection { get; set; }
        public CollectionViewState() {
            ViewCollection = new List<TItem>();
        }
    }

    public interface IExtendedListViewSupported<TViewState, TViewItem> 
        where TViewState : CollectionViewState<TViewItem> {
        TViewState ViewState { get; }
    }

    public interface IExtendedListPullToRefreshSupported {
        ListViewPullToRefreshViewModel PullToRefresh { get; }
    }
}
