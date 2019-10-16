using System;
using System.Collections.Generic;
using Xamarin.Presentation.Validations;

namespace Xamarin.Presentation.Framework.VSVVM {
    public abstract class BaseViewState : BaseNotify {
        private readonly object _lock = new object();
        public void Push(params (string name, object value)[] properties) {
            foreach ((string name, object value) in properties) {
                var property = GetType().GetProperty(name);
                object prev = property.GetValue(this);
                if (Update(ref prev, value, name)) {
                    property.SetValue(this, value);
                }
            }
        }

        internal void Push<T>(Action<T> update) where T : BaseViewState {
            var state = Activator.CreateInstance<T>();

            update(state);

            foreach (var pr in GetType().GetProperties()) {
                var name = pr.Name;
                var property = GetType().GetProperty(name);
                object newone = property.GetValue(state);
                object currentValue = property.GetValue(this);
                if (newone == null) continue;
                if (Update(ref currentValue, newone, name) && property.CanWrite) {
                    property.SetValue(this, newone);
                }
            }
        }

        public void ForcePush(params string[] names) {
            foreach (string name in names) {
                SetPropertyChanged(name);
            }
        }

        void PushAll() {
            foreach (var pr in GetType().GetProperties()) {
                if (pr.CanRead) {
                    SetPropertyChanged(pr.Name);
                }
            }
        }
    }
    public interface IValidatableStateProperty<TValue> {
        List<string> Errors { get; }
        TValue Value { get; }
        bool IsValid { get; }
    }

   

    public static class ViewStateEx {
        public static void Push<T>(this T vs, Action<T> update) where T : BaseViewState {
            vs.Push(update);
        }
    }
}
