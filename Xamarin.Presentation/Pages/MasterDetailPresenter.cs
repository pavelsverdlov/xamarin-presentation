using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Presentation.Framework.VSVVM;
using Xamarin.Presentation.Pages.Menu;

namespace Xamarin.Presentation.Pages {
    public abstract class MasterDetailPresenter<TController> :
        BasePresenter<MasterDetailViewState, TController> where TController : MasterDetailController, new() {
        public IPageNavigator PageNavigator { get; }

        public MasterDetailPresenter() {
            PageNavigator = new PageNavigatorAdapter();
        }

        //protected override void Init(MasterDetailViewState vs, MasterDetailController con) {
        //    base.Init(vs, con);
        //    con.Presenter = this;
        //}

    }

    public abstract class MasterDetailController : BaseController {
        //internal MasterDetailPresenter Presenter;

        public Command<NavPageMenuItem> ItemSelectedCommand { get; }
        public MasterDetailController() {
            ItemSelectedCommand = new Command<NavPageMenuItem>(OnItemSelected);
        }

        protected abstract void OnItemSelected(NavPageMenuItem item);
    }

    public class MasterDetailViewState : BaseViewState {
        public string AccountImage { get; set; }
        public string AccountName { get; set; }
        public string AccountStatus { get; set; }

        public ObservableCollection<NavPageMenuItem> MenuItems { get; }
        public MasterDetailViewState() {
            AccountImage = "person.png";
            AccountName = "Some user";
            AccountStatus = "online";
            MenuItems = new ObservableCollection<NavPageMenuItem>();
        }
    }

}
