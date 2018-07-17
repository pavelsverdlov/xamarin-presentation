using Xamarin.Forms;

namespace Xamarin.Presentation.Controls.LV {
    public class DeselectListViewItemTriggerAction : TriggerAction<ListView> {
        protected override void Invoke(ListView sender) {
            sender.SelectedItem = null;
        }
    }
}
