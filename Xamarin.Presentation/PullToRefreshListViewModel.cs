using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Presentation {
    public sealed class PullToRefreshListViewModel : Framework.MVVM.BaseViewModel {
        public bool Enabled { get; set; }
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
                    Refresh();
                    IsRefreshing = false;
                });
            }
        }

        public event Action Refresh = () => { };

        public PullToRefreshListViewModel(bool enabled) {
            Enabled = enabled;
        }
    }
}
