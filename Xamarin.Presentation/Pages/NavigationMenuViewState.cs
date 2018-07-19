using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.Presentation.Pages {
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
}
