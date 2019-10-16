using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Presentation.Pages {
    public class XamToolbarItem : ToolbarItem {
        public static readonly BindableProperty IsVisibleProperty =
            BindableProperty.Create(nameof(IsVisible),
                                    typeof(bool),
                                    typeof(XamToolbarItem),
                                    true, propertyChanged: OnPropertyChanged);

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var newvalue = (bool)newValue;
            var item = bindable as XamToolbarItem;

            if (item.Parent == null)
                return;

            var items = item.Parent;//.ToolbarItems;

            //if (newvalue && !items.Contains(item)) {
            //    items.Add(item);
            //} else if (!newvalue && items.Contains(item)) {
            //    items.Remove(item);
            //}
        }

        public bool IsVisible {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }



        //ICommand temp;
        //FileImageSource Icontemp;
        //void TurnOff() {
        //    Icontemp = Icon;
        //    Icon = null;
        //    temp = Command;
        //    Command = null;
        //}
        //void TurnOn() {
        //    Icon = Icontemp;
        //    Command = temp;
        //}
    }
}
