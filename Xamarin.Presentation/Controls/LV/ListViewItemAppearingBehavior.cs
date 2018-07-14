using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Presentation.Controls.LV {
    public sealed class ListItemAppearingBehavior : Behavior<ListView> {

        public static readonly BindableProperty ItemAppearedProperty =
           BindableProperty.CreateAttached(nameof(ItemAppeared), typeof(ICommand), typeof(ListItemAppearingBehavior), null);

        public ICommand ItemAppeared {
            get { return (ICommand)GetValue(ItemAppearedProperty); }
            set { SetValue(ItemAppearedProperty, value); }
        }
        protected override void OnAttachedTo(ListView bindable) {
            bindable.ItemAppearing += OnItemAppearing;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ListView bindable) {
            bindable.ItemAppearing -= OnItemAppearing;
            bindable.RemoveBinding(ItemAppearedProperty);
            base.OnDetachingFrom(bindable);
        }
        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e) {
            ItemAppeared.Invoke(e.Item);
        }
    }
}
