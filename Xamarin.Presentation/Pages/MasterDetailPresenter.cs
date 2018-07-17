using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Presentation.Framework.VSVVM;

namespace Xamarin.Presentation.Pages {
    public abstract class MasterDetailPresenter : BasePresenter<MasterDetailViewState, MasterDetailController> {
        public IMasterDetailPageNavigator Page { get; }

        public MasterDetailPresenter() {
            Page = new PageNavigatorViewModel();
        }

        protected override void Init(MasterDetailViewState vs, MasterDetailController con) {
            base.Init(vs, con);
            con.Presenter = this;
        }

        public abstract void OnMenuSelected(NavPageMenuItem item);

    }

    public class MasterDetailController : BaseController {
        internal MasterDetailPresenter Presenter;

        public Command<NavPageMenuItem> ItemSelectedCommand { get; }
        public MasterDetailController() {
            ItemSelectedCommand = new Command<NavPageMenuItem>(OnItemSelected);
        }

        private void OnItemSelected(NavPageMenuItem item) {
            Presenter.OnMenuSelected(item);
        }
    }

    public class MasterDetailViewState : BaseViewState {
        public string AccountImage { get; }
        public string AccountName { get; }
        public string AccountStatus { get; }

        public List<NavPageMenuItem> MenuItems { get; set; }
        public MasterDetailViewState() {
            AccountImage = "person.png";
            AccountName = "Some user";
            AccountStatus = "online";
            MenuItems = new List<NavPageMenuItem>();
        }
    }

}
