using Xamarin.Forms;

namespace Xamarin.Presentation.Pages.States {
    [ContentProperty("Content")]
    public class StateCondition : View {
        public object State { get; set; }
        public View Content { get; set; }
    }
}
