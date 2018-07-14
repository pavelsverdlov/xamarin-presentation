using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Presentation.Framework.VSVVM;

namespace Xamarin.Presentation.Auth {
    public class SignInPresenterController : BaseController {
        internal SignInPresenter VM;
        public ICommand LogIn { get; }
        public SignInPresenterController() {
            LogIn = new Command(OnLogIn);
        }

        void OnLogIn(object obj) {
            VM.OnLogIn();
        }
    }

    public class SignInPresenterViewState : BaseViewState {

    }
    public abstract class SignInPresenter : BasePresenter<SignInPresenterViewState, SignInPresenterController> {
        protected SignInPresenter() {
            
        }

        protected override void Init(SignInPresenterViewState vs, SignInPresenterController con) {
            base.Init(vs, con);
            con.VM = this;
        }

        public abstract void OnLogIn();
    }


}
