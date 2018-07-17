using System.Collections.Generic;
using System.Windows.Input;

namespace Xamarin.Presentation.Social.Profiles {
    public interface IProfilePreviewViewState {
        string IconSource { get; set; }
        string ProfileName { get; set; }

        List<ProfilePeopertyItem> ProfileProperties { get; }
    }

    public interface IEditProfileViewState {
        string IconSource { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
    }
    public interface IEditProfileController {
        ICommand ChangePassword { get; }
        ICommand ChangeImage { get; }
    }
}
