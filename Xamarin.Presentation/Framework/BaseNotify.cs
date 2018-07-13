using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Xamarin.Presentation.Framework {
    public class BaseNotify : INotifyPropertyChanged {
        public virtual bool IsBusy { get; set; }


        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        protected bool Update<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "") {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue)) {
                return false;
            }
            currentValue = newValue;
            SetPropertyChanged(propertyName);
            //return PropertyChanged.SetProperty(this, ref currentValue, newValue, propertyName);
            return true;
        }

        protected void SetPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
