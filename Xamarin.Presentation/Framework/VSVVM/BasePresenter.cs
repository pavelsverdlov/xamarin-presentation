using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Presentation.Framework.VSVVM {
    public interface IBaseViewModel {
        BaseController Controller { get; }
    }

    public interface IVSVVMPresenter<TViewStateType, TControllerType> : IBaseViewModel
        where TViewStateType : BaseViewState, new()
        where TControllerType : BaseController, new() {
        TViewStateType ViewState { get; }
    }

    public abstract class BasePresenter<TViewStateType, TControllerType> : IVSVVMPresenter<TViewStateType, TControllerType>
        where TViewStateType : BaseViewState, new()
        where TControllerType : BaseController, new() {

        public TViewStateType ViewState { get; private set; }
        public TControllerType Controller { get; private set; }

        BaseController IBaseViewModel.Controller => Controller;

        public BasePresenter() {
            ViewState = new TViewStateType();
            Controller = new TControllerType();
            //Controller.Init(ViewState);
            Init(ViewState, Controller);
        }

        protected virtual void Init(TViewStateType vs, TControllerType con) { }
    }
}
