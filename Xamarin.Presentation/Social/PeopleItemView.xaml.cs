using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Presentation.Social.States;

namespace Xamarin.Presentation.Social {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleItemView : Grid {

        public static readonly BindableProperty RemoveCommandProperty =
   BindableProperty.CreateAttached(nameof(RemoveCommand), typeof(ICommand), typeof(PeopleItemView), null, propertyChanged: OnRemoveCommandPropertyChanged);

        private static void OnRemoveCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (PeopleItemView)bindable;
            _this.RemoveFriendBtn.Command = _this.RemoveCommand;
        }

        public ICommand RemoveCommand {
            get { return (ICommand)GetValue(RemoveCommandProperty); }
            set { SetValue(RemoveCommandProperty, value); }
        }

        public static readonly BindableProperty IsActionsVisibleProperty =
          BindableProperty.CreateAttached(nameof(IsActionsVisible), typeof(bool), typeof(PeopleItemView), true,
              propertyChanged: OnIsActionsVissiblePropertyChanged);

        private static void OnIsActionsVissiblePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (PeopleItemView)bindable;
            var vis = (bool)newValue;
            _this.AddFriendBtn.IsVisible = _this.RemoveFriendBtn.IsVisible = vis;
        }

        public bool IsActionsVisible {
            get { return (bool)GetValue(IsActionsVisibleProperty); }
            set { SetValue(IsActionsVisibleProperty, value); }
        }
        public PeopleItemView() {
            InitializeComponent();
        }
    }
}