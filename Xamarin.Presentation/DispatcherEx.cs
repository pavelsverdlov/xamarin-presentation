using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Presentation {
    public static class DispatcherEx {
        public static void BeginRise(this Action action) {
            Device.BeginInvokeOnMainThread(action);
        }
        public static void BeginRise<T>(this Task<T> task, Action<T> action) {
            task.ContinueWith(x => {
                var res = x.Result;
                Device.BeginInvokeOnMainThread(() => action(res));
            });
        }
        public static void BeginRise<T>(this Task<T> task, Action<T> action, Action<Exception> error) {
            task.ContinueWith(x => {
                if (x.Exception != null) {
                    error(x.Exception);
                    return;
                }
                var res = x.Result;
                Device.BeginInvokeOnMainThread(() => action(res));
            });
        }
    }
}
