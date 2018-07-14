using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Presentation.Framework;
using Xamarin.Presentation.Pages.States;

namespace Xamarin.Presentation.Pages {
    public interface IPageNavigator {
        string Title { get; set; }
        string IconSource { get; }
        bool IsBusy { get; }
        IEnumerable<ToolbarItem> ToolbarMenu { get; }
        INavigation Navigation { get; set; }
    }

    public class PageNavigatorViewModel : BaseNotify, IPageNavigator {
        bool isBusy;
        string title;
        
        public string Title {
            get => title;
            set => Update(ref title, value);
        }
        public string IconSource { get; set; }
        public override bool IsBusy {
            get => isBusy;
            set {
                Update(ref isBusy, value);
            }
        }
        public IEnumerable<ToolbarItem> ToolbarMenu { get; set; }
        public INavigation Navigation { get; set; }
        

        public PageNavigatorViewModel() {
            ToolbarMenu = new ToolbarItem[0];
           
        }
    }
}
