using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Pages {
    public interface IPageNavigatorSupporting {
        IPageNavigator PageNavigator { get; }
    }

    public interface IPageNavigator {
        string Title { get; set; }
        string IconSource { get; set; }
        bool IsBusy { get; }
        IEnumerable<ToolbarItem> ToolbarMenu { get; }
        INavigation Navigation { get; set; }
    }
    public interface IMasterDetailPageNavigator : IPageNavigator {
        bool IsPresented { get; set; }
    }

    public class PageNavigatorViewModel : BaseNotify, IPageNavigator, IMasterDetailPageNavigator {
        bool isBusy;
        bool isPresented;
        string title;
        string iconSource;

        public string Title {
            get => title;
            set => Update(ref title, value);
        }
        public string IconSource {
            get => iconSource;
            set => Update(ref iconSource, value);
        }
        public override bool IsBusy {
            get => isBusy;
            set {
                Update(ref isBusy, value);
            }
        }
        public bool IsPresented {
            get => isPresented;
            set {
                Update(ref isPresented, value);
            }
        }
        public IEnumerable<ToolbarItem> ToolbarMenu { get; set; }
        public INavigation Navigation { get; set; }


        public PageNavigatorViewModel() {
            ToolbarMenu = new ToolbarItem[0];

        }
    }
}
