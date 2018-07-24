using Xamarin.Forms;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Pages.Tab {
    public interface ITabPage {
        int Index { get; }
        //IsSelected

    }

    internal class LeftTapContent : ITabPage {
        public int Index => 0;
    }
    internal class RightTapContent : ITabPage {
        public int Index => 1;
    }


    public class TestSelector : ITabControlTemplateSelector {
        public ControlTemplate Template0 { get; set; }
        public ControlTemplate Template1 { get; set; }
        public ControlTemplate Template2 { get; set; }
        public ControlTemplate Template3 { get; set; }

        public int Count => 4;

        public ControlTemplate GetTemplate(ITabPage tab) {
            switch (tab.Index) {
                case 0:
                    return Template0;
                case 1:
                    return Template1;
            }
            return null;
        }
    }

    public interface ITabControlTemplateSelector {
        int Count { get; }

        ControlTemplate Template0 { get; set; }
        ControlTemplate Template1 { get; set; }
        ControlTemplate Template2 { get; set; }
        ControlTemplate Template3 { get; set; }

        ControlTemplate GetTemplate(ITabPage page);
    }

    public interface ITabController {
        /// <summary>
        /// int - index of selected tab
        /// </summary>
        Command<string> TabSelected { get; }
    }

    public interface ITabPresenter {
        ITabPage Content { get; }
    }

    public class TabPresenter : BaseNotify, ITabController {
        private object content;
        public object Content {
            get => content;
            set => Update(ref content, value);
        }

        public Command<string> TabSelected { get; }
        public Command Right { get; }

        public TabPresenter() {
            TabSelected = new Command<string>(OnLeft);
            Right = new Command(OnRight);
        }

        private void OnRight(object obj) {

        }

        private void OnLeft(string obj) {
            switch (obj) {
                case "0":
                    Content = new LeftTapContent();
                    break;
                case "1":
                    Content = new RightTapContent();
                    break;
            }
        }
    }
}
