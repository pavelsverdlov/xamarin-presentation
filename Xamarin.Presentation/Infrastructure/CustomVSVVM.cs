using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Presentation.Controls;
using Xamarin.Presentation.Framework.VSVVM;

namespace Xamarin.Presentation.Infrastructure {
    public interface IItemSelectedController<TItem> {
        Command<TItem> ItemSelectedCommand { get; }
    }
    public class CollectionViewState<TItem> : BaseViewState {
        /// <summary>
        /// No needed to PUSH ObservableCollection because it supports notification to View itself
        /// </summary>
        public ObservableCollection<TItem> ViewCollection { get; }
        public CollectionViewState() {
            ViewCollection = new ObservableCollection<TItem>();
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
