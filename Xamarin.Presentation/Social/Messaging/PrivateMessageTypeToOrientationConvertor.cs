using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Presentation.Social.Messaging {
    public class PrivateMessageTypeToOrientationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var type = (PrivateMessageTypes)value;
            switch (type) {
                case PrivateMessageTypes.Incoming:
                    return LayoutOptions.EndAndExpand;
                case PrivateMessageTypes.Outgoing:
                    return LayoutOptions.StartAndExpand;
            }
            return LayoutOptions.FillAndExpand;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
