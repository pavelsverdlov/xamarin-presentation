﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Presentation.Controls {
    public class ListViewItemSelectedBehavior : Behavior<ListView> {
        public static readonly BindableProperty ItemSelectedProperty = 
            BindableProperty.CreateAttached(nameof(ItemSelected), typeof(ICommand), typeof(ListViewItemSelectedBehavior), null);

        public ICommand ItemSelected {
            get { return (ICommand)GetValue(ItemSelectedProperty); }
            set { SetValue(ItemSelectedProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable) {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += OnItemSelected;
        }
        protected override void OnDetachingFrom(ListView bindable) {
            bindable.ItemSelected -= OnItemSelected;
            bindable.RemoveBinding(ItemSelectedProperty);
            base.OnAttachedTo(bindable);            
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var selected = e.SelectedItem;
            if (selected.IsNull()) {
                return;
            }
            ItemSelected.Invoke(selected);
            ((ListView)sender).SelectedItem = null;
        }
    }
}
