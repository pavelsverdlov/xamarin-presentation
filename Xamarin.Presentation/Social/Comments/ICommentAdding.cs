using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Presentation.Social.Comments {
    public interface ICommentAddingController {
        Command<Entry> CommentAdded { get; }
        Command CameraActivated { get; }
        //Command SendComment { get; }
        
    }

    public interface ICommentAddingViewState {
        string CommenterIconSource { get; set; }
        string AddCommentEntryPlaceholder { get; set; }

    }
}
