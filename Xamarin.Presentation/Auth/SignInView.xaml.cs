using Xamarin.Forms.Xaml;
using Xamarin.Presentation.Pages.States;

namespace Xamarin.Presentation.Auth {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInView : StateContainer {
        public SignInView() {
            InitializeComponent();
        }
    }
}