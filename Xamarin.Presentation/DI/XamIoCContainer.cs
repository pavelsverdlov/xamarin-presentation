using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Xamarin.Presentation.DI {
    public abstract class ViewModelContainer {
        readonly Dictionary<Type, Type> mapperToVM;
        readonly Dictionary<Type, Type> mapperToView;
        protected ViewModelContainer() {
            mapperToVM = new Dictionary<Type, Type>();
            mapperToView = new Dictionary<Type, Type>();
            Registration();
        }

        protected abstract void Registration();
        protected void Map<TView, TViewModel>() where TView : Page {
            mapperToVM.Add(typeof(TView), typeof(TViewModel));
            mapperToView.Add(typeof(TViewModel), typeof(TView));
        }
        public object GetViewModel<TVM>() where TVM : class {
            return Activator.CreateInstance(typeof(TVM));
        }
        public object GetViewModel(Type type) {
            return Activator.CreateInstance(mapperToVM[type]);
        }
        public Type GetViewType<TVM>() where TVM : class {
            return mapperToView[typeof(TVM)];
        }

        public TView GetView<TVM, TView>() where TVM : class {
            var tview = mapperToView[typeof(TVM)];
            return (TView)Activator.CreateInstance(tview);
        }

        public Page GetView(Type type) {
            return (Page)Activator.CreateInstance(type);
        }

    }
    public abstract class XamIoCContainer {
        private readonly Dictionary<Type, Func<object>> dictionary;
        private readonly Dictionary<Type, Type> typeMapper;
        public XamIoCContainer() {
            dictionary = new Dictionary<Type, Func<object>>();
            typeMapper = new Dictionary<Type, Type>();
            Registration();
        }

        protected abstract void Registration();

        protected void Register<T, TI>() where T : class where TI : class, T {
            DependencyService.Register<T, TI>();
        }
        protected void Register<T, TImpl>(Action<TImpl> init, DependencyFetchTarget target) where T : class where TImpl : class, T {
            DependencyService.Register<T, TImpl>();
            init((TImpl)DependencyService.Get<T>(target));
        }
        protected void Register<TImpl>(Action<TImpl> init, DependencyFetchTarget target) where TImpl : class {
            DependencyService.Register<TImpl>();
            init(DependencyService.Get<TImpl>(target));
        }
        protected void Register<T>() where T : class {
            DependencyService.Register<T>();
        }
        protected void RegisterWithType<T>() where T : class {
            DependencyService.Register<T>();

            dictionary.Add(typeof(T), () => DependencyService.Get<T>());
        }
        public T Get<T>() where T : class {
            try {
                return DependencyService.Get<T>();
            } catch (Exception ex) {
                var inner = ex.Unwrap();
                Debug.WriteLine(inner.ToString());
                throw inner;
            }
        }
        public T GetAsSingleton<T>() where T : class {
            try {
                return DependencyService.Get<T>(DependencyFetchTarget.GlobalInstance);
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
                throw ex;
            }
        }
        public object Get(Type type) {
            try {
                return dictionary[type]();
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
