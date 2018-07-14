﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Presentation.Pages.States {
    [ContentProperty("Conditions")]
    public class StateContainer : ContentView {
        public List<StateCondition> Conditions { get; set; } = new List<StateCondition>();

        public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), 
            typeof(object), typeof(StateContainer), null, BindingMode.Default, null, StateChanged);

        public static void Init() {
            //for linker
        }

        private static async void StateChanged(BindableObject bindable, object oldValue, object newValue) {
            var parent = bindable as StateContainer;
            if (parent != null) {
                await parent.ChooseStateProperty(newValue);
            }
        }

        public object State {
            get { return GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        private async Task ChooseStateProperty(object newValue) {
            if (Conditions == null && Conditions?.Count == 0) {
                return;
            }

            try {
                foreach (var stateCondition in Conditions
                    .Where(stateCondition => stateCondition.State != null && stateCondition.State.ToString().Equals(newValue.ToString()))) {
                    if (Content.IsNotNull()) {
                        await Content.FadeTo(0, 100U); //fast animation for hidding
                        Content.IsVisible = false; //hide the prev state
                        //allow UI thred works its queue of messeges and ensure that the prev state will be hidded 
                        await Task.Delay(30); 
                    }

                    // smoothly showing new state
                    stateCondition.Content.Opacity = 0;
                    Content = stateCondition.Content;
                    Content.IsVisible = true;
                    await Content.FadeTo(1);

                    break;
                }
            } catch (Exception e) {
                Debug.WriteLine($"StateContainer ChooseStateProperty {newValue} error: {e}");
            }
        }
    }
}
