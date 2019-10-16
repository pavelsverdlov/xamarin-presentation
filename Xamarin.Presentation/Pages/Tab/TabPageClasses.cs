using Xamarin.Forms;
using Xamarin.Presentation.Framework;

namespace Xamarin.Presentation.Pages.Tab {
    public interface ITabPage {
        int Index { get; }
        void UpdateBindingContext(object bc);
        //object BindingContext { get; set; }
        //IsSelected
    }

    internal class LeftTapContent : ITabPage {
        public int Index => 0;

        public object BindingContext { get; set; }

        public void UpdateBindingContext(object bc) {
        
        }
    }

    public class TabControlTemplateSelector  {
        public ControlTemplate Template0 { get; set; }
        public ControlTemplate Template1 { get; set; }
        public ControlTemplate Template2 { get; set; }
        public ControlTemplate Template3 { get; set; }

        public int Count => 4;

        ControlTemplate GetTemplate(ITabPage tab) {
            switch (tab.Index) {
                case 0:
                    return Template0;
                case 1:
                    return Template1;
                case 2:
                    return Template2;
                case 3:
                    return Template3;
            }
            return null;
        }

        public void ApplyTemplate(TemplatedView view, ITabPage tab) {
            view.ControlTemplate = GetTemplate(tab);
            //var bc = view.BindingContext;
        }
    }

    //public interface ITabControlTemplateSelector {
    //    int Count { get; }

    //    ControlTemplate Template0 { get; set; }
    //    ControlTemplate Template1 { get; set; }
    //    ControlTemplate Template2 { get; set; }
    //    ControlTemplate Template3 { get; set; }

    //    void ApplyTemplate(TemplatedView view, ITabPage tab);
    //}

    public interface ITabController {
        /// <summary>
        /// int - index of selected tab
        /// </summary>
        Command<string> TabSelected { get; }
    }

    public interface ITabPresenter {
        ITabPage Content { get; }
    }

    public interface ITabPageNavigatorUpdating {
        IPageNavigator PageNavigator { set; }
        void NavigatorPageChanged();
    }
    public class TabPageItem<TPresenter> : ITabPage {
        readonly IPageNavigator pageNavigator;

        public TabPageItem(IPageNavigator pageNavigator) {
            this.pageNavigator = pageNavigator;
        }

        public int Index { get; set; }
        public TPresenter Presenter => (TPresenter)bindingContext;
        object bindingContext;

        public void UpdateBindingContext(object bc) {
            if (bc is ITabPageNavigatorUpdating navigator) {
                navigator.PageNavigator = pageNavigator;// new MixipleMasterNavigatorDecorator(pageNavigator);
                navigator.NavigatorPageChanged();                                    //navigator.PageNavigator.UpdateNavigation();
            }
            bindingContext = bc;
        }
    }
}
