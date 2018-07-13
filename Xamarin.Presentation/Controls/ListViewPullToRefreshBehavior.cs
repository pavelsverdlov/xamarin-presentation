using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Presentation.Controls {
    public class ListViewPullToRefreshBehavior : Behavior<ListView> {
        public static readonly BindableProperty PullToRefreshProperty =
                   BindableProperty.CreateAttached(nameof(PullToRefresh), typeof(ListViewPullToRefreshViewModel), typeof(ListViewPullToRefreshBehavior), null);
        public ListViewPullToRefreshViewModel PullToRefresh {
            get { return (ListViewPullToRefreshViewModel)GetValue(PullToRefreshProperty); }
            set {
                SetValue(PullToRefreshProperty, value);
            }
        }

        ListView bindable;
        protected override void OnAttachedTo(ListView bindable) {
            base.OnAttachedTo(bindable);
            this.bindable = bindable;
            var source = PullToRefresh; 
            if (source.IsNull()) {
                return;
            }
            UpdateBinding(source);
        }
        protected override void OnDetachingFrom(ListView bindable) {
            bindable.RemoveBinding(ListView.IsPullToRefreshEnabledProperty);
            bindable.RemoveBinding(ListView.RefreshCommandProperty);
            bindable.RemoveBinding(ListView.IsRefreshingProperty);
            base.OnAttachedTo(bindable);
        }

        void UpdateBinding(ListViewPullToRefreshViewModel source) {
            bindable.SetBinding(ListView.IsPullToRefreshEnabledProperty,
                           new Binding { Source = source, Path = nameof(source.IsEnabled), Mode = BindingMode.OneWay });
            bindable.SetBinding(ListView.RefreshCommandProperty,
                           new Binding { Source = source, Path = nameof(source.RefreshCommand), Mode = BindingMode.OneWay });
            bindable.SetBinding(ListView.IsRefreshingProperty,
                           new Binding { Source = source, Path = nameof(source.IsRefreshing), Mode = BindingMode.OneWay });
        }
    }
}
