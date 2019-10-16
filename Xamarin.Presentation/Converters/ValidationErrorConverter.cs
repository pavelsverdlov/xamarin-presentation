using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Presentation.Framework.VSVVM;
using Xamarin.Presentation.Validations;

namespace Xamarin.Presentation.Converters {
    public class ValidationErrorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var state = (IValidationState)value;

            return state.GetError(parameter.ToString());

            //var errors = value as ICollection<string>;
            //return errors != null && errors.Count > 0 ? errors.ElementAt(0) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class ValidationIsValidConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var state = (IValidationState)value;

            return state.IsValid(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
