using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Presentation.Controls;
using Xamarin.Presentation.Social.Comments;
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
            //Button.ButtonContentLayout.ImagePosition.Left
        }
    }
    public class ActivityDetailsViewState : Framework.VSVVM.BaseViewState, ICommentAddingViewState {
        public ObservableCollection<CommentViewState> Comments { get; set; }

        public string CommenterIconSource { get; set; }
        public string AddCommentEntryPlaceholder { get; set; }

        public ActivityDetailsViewState() {
            CommenterIconSource = "person.png";
            AddCommentEntryPlaceholder = "Write a comment ...";
            Comments = new ObservableCollection<CommentViewState>();
        }
    }

    //public abstract class ActivityDetailController : Framework.VSVVM.BaseController {
    //    public Command<ButtonModel> CommentsRefreshCommand;

    //}
    public interface IActivityDetailController : ICommentAddingController {
        Command<CommentViewState> ItemSelectedCommand { get; }
    }
}
