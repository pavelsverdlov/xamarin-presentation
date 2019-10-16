using Xamarin.Forms.Xaml;
using Xamarin.Presentation.Pages.States;

namespace Xamarin.Presentation.Auth {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationView : StateContainer {
        public RegistrationView() {
            InitializeComponent();
        }
    }
}