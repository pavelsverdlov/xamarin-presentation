using Xamarin.Forms;
using Xamarin.Presentation.Social.States;

namespace Xamarin.Presentation.Social {
    public class ActivityHeaderPresenter<TController> :
        Framework.VSVVM.BasePresenter<ActivityViewState, TController>
        where TController : Framework.VSVVM.BaseController, IActivityHeaderController, new() {

    }

    public interface IActivityHeaderController {
        Command<ButtonModel> ClickCommand { get; }
    }
    //public abstract class ActivityHeaderController : Framework.VSVVM.BaseController {
    //    public ActivityHeaderController() {

    //    }

    //    public Command<ButtonModel> ClickCommand => new Command<ButtonModel>(OnClicked);
    //    protected abstract void OnClicked(ButtonModel btn);
    //}
}
