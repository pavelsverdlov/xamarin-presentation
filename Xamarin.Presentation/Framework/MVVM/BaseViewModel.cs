using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Xamarin.Presentation.Framework.MVVM {

    public class BaseViewModel  : BaseNotify {
        bool isBusy = false;
        public override bool IsBusy {
            get { return isBusy; }
            set { Update(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title {
            get { return title; }
            set { Update(ref title, value); }
        }
    }

    public static class BaseNotifyEx {
        //Just adding some new funk.tionality to System.ComponentModel
        public static bool SetProperty<T>(this PropertyChangedEventHandler handler, object sender, ref T currentValue, T newValue, [CallerMemberName] string propertyName = "") {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue))
                return false;

            currentValue = newValue;

            //var dirty = sender as Mobile.Shared.IDirty;

            //if (dirty != null)
            //    dirty.IsDirty = true;

            if (handler == null)
                return true;

            handler.Invoke(sender, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
