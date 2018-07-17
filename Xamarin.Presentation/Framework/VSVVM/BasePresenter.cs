using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Presentation.Framework.VSVVM {
    public interface IBaseViewModel {
        BaseController Controller { get; }
    }


    public abstract class BasePresenter<ViewStateType, ControllerType> :  IBaseViewModel 
        where ViewStateType : BaseViewState, new()
        where ControllerType : BaseController, new() {

        public ViewStateType ViewState { get; private set; }
        public ControllerType Controller { get; private set; }

        BaseController IBaseViewModel.Controller => Controller;

        public BasePresenter() {
            ViewState = new ViewStateType();
            Controller = new ControllerType();
             //Controller.Init(ViewState);
            Init(ViewState, Controller);
        }

        protected virtual void Init(ViewStateType vs, ControllerType con) { }
    }
}
