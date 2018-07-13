using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Presentation.Controls;
using Xamarin.Presentation.Social.States;

namespace Xamarin.Presentation.Social {
    public interface IActivityDetailsView<TDetailController, THeaderController>
       where TDetailController : Framework.VSVVM.BaseController, IActivityDetailController, new()
       where THeaderController : Framework.VSVVM.BaseController, IActivityHeaderController, new() {
        ActivityDetailPresenter<TDetailController> DetailViewModel { get; }
        ActivityHeaderPresenter<THeaderController> HeaderViewModel { get; }

        ListViewPullToRefreshViewModel PullToRefresh { get; }
    }

    public class ActivityDetailPresenter<TDetailController> :
        Framework.VSVVM.BasePresenter<ActivityDetailsViewState, TDetailController>
        where TDetailController : Framework.VSVVM.BaseController, IActivityDetailController, new() {
        //public ListViewPullToRefreshViewModel PullToRefresh { get; }
        //public ActivityDetailPresenter() {
        //    PullToRefresh = new ListViewPullToRefreshViewModel();
        //    PullToRefresh.Refreshed += OnPullToRefreshed;
        //}

        protected virtual void OnPullToRefreshed() {
            
        }
    }
    public class ActivityDetailsViewState : Framework.VSVVM.BaseViewState {
        public ObservableCollection<MessageViewState> Comments { get; set; }
        public ActivityDetailsViewState() {
            //Comments.
        }
    }

    //public abstract class ActivityDetailController : Framework.VSVVM.BaseController {
    //    public Command<ButtonModel> CommentsRefreshCommand;

    //}
    public interface IActivityDetailController {
        Command<MessageViewState> ItemSelectedCommand { get; }
    }
}
