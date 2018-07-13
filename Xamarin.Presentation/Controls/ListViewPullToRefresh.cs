using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Controls {
    public class ListViewPullToRefreshViewModel : BaseNotify {
        public bool IsEnabled { get; set; }
        private bool isRefreshing = false;
        public bool IsRefreshing {
            get { return isRefreshing; }
            set {
                Update(ref isRefreshing, value);
            }
        }
        public ICommand RefreshCommand {
            get {
                return new Command(() => {
                    IsRefreshing = true;
                    Refreshed();
                    IsRefreshing = false;
                });
            }
        }

        public event Action Refreshed = () => { };

        public ListViewPullToRefreshViewModel(bool enabled = true) {
            IsEnabled = enabled;
        }
    }
}
