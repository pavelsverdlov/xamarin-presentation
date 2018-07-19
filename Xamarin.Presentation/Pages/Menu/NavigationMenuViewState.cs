using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.Presentation.Pages.Menu {
    public class NavMenuPageViewState {
        public string AccountStatus { get; set; }
        public string AccountName { get; set; }
        public ImageSource AccountImage { get; set; }
        public ImageSource AppLogo { get; set; }
        public List<NavPageMenuItem> Items { get; set; }
    }
    public class NavPageMenuItem {
        public NavPageMenuItem() {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

        public Type TargetType { get; set; }
    }

    public class GroupNavMenuItem : List<NavPageMenuItem> { //https://xamarinhelp.com/xamarin-forms-listview-grouping/
        public string GroupHeader { get; set; }
        public List<NavPageMenuItem> Items => this;
        public GroupNavMenuItem() {
        }
    }
}
