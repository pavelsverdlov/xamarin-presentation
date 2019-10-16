using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Presentation.Framework.VSVVM;
using Xamarin.Presentation.Pages.States;

namespace Xamarin.Presentation.Auth {
    public class SignInPresenterController : BaseController {
        internal SignInPresenter VM;
        public ICommand LogIn { get; }
        public ICommand CreateNewAccount { get; }
        public SignInPresenterController() {
            LogIn = new Command(OnLogIn);
            CreateNewAccount = new Command(OnCreateNewAccount);
        }

        void OnCreateNewAccount(object obj) {
            VM.OnCreateNewAccount();
        }

        void OnLogIn(object obj) {
            VM.OnLogIn();
        }
    }

    public class SignInPresenterViewState : BaseViewState {
        public Color BackgroundColor { get; set; }
        public string EmailLogin { get; set; }
        public string Pass { get; set; }

        public SignInPresenterViewState() {
            BackgroundColor = Color.White;
        }
    }
    public abstract class SignInPresenter : BasePresenter<SignInPresenterViewState, SignInPresenterController>, IPageStates {

        public PageStates State { get; protected set; }

        protected SignInPresenter() {
            
        }

        protected override void Init(SignInPresenterViewState vs, SignInPresenterController con) {
            base.Init(vs, con);
            con.VM = this;
        }

        public abstract void OnLogIn();
        public abstract void OnCreateNewAccount();
    }


}
