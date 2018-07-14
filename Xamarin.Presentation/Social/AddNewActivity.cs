using System.Windows.Input;
using Xamarin.Presentation.Social.States;

namespace Xamarin.Presentation.Social {
    public interface IAddNewActivityViewState {
        string IconSource { get; }
        string UserName { get; }
        string Info { get; }
        ButtonModel Add { get; }
    }
    public interface IAddNewActivityController {
        ICommand AddClickCommand { get; }
    }
}
