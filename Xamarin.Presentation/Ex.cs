using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.Presentation {
    public static class Ex {

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (T s in source) {
                action(s);
            }
        }
    }

    public static class BindEx {
        public static void DoBindingContext<T>(this object sender, Action<T> action) {            var bo = (BindableObject)sender;            if (bo.BindingContext.IsNull() || !(bo.BindingContext is T)) {                return;
            }            var bc = (T)bo.BindingContext;            action(bc);        }
    }

    public static class MonadExtentions {
        public static bool IsNull<T>(this T source) where T : class { return source == null; }
        public static bool IsNotNull<T>(this T source) where T : class { return source != null; }

        public static T AsDo<T>(this object _source, Action<T> action) where T : class {
            T source = _source as T;
            if (source == null) {
                return null;
            }

            action(source);
            return source;
        }

        public static TInput Do<TInput>(this TInput source, Action<TInput> action)
            where TInput : class {
            if (source == null) {
                return null;
            }

            action(source);
            return source;
        }

        public static TInput If<TInput>(this TInput source, Predicate<TInput> predicate)
            where TInput : class {
            if (source == null) {
                return null;
            }

            return predicate(source) ? source : null;
        }

        public static TReturn Return<TInput, TReturn>(this TInput source,
                                                       Func<TInput, TReturn> getter,
                                                      TReturn def = default(TReturn)) where TInput : class {
            if (source == null) {
                return def;
            }

            return getter(source);
        }

        public static TReturn Return<TInput, TReturn>(this TInput source,
                                                       Func<TInput, TReturn> getter,
                                                      Func<TReturn> defaultFactory) where TInput : class {
            if (source == null) {
                return defaultFactory();
            }

            return getter(source);
        }
    }

    public static class ExLikeAKotlin {
        public static T Apply<T>(this T _this, Action<T> apply) where T : new() {
            apply(_this);
            return _this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TThis">receiver</typeparam>
        /// <typeparam name="TIt">argument</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="it"></param>
        /// <param name="let"></param>
        /// <returns></returns>
        public static TResult Let<TThis, TIt, TResult>(this TIt it, TThis _this, Func<TThis, TIt, TResult> let) where TIt : new() {
            return let(_this, it);
        }
    }

    public static class ExceptonEx {
        public static Exception Unwrap(this Exception ex) {
            var next = ex;
            while (next.InnerException.IsNull()) {
                next = next.InnerException;
            }
            return next;
        }
    }
}
