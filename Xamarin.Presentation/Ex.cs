using System;
using System.Collections.Generic;

namespace Xamarin.Presentation {
    public static class Ex {
        public static bool IsNull(this object source) {
            return source == null;
        }
        public static bool IsNotNull(this object source) {
            return source != null;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var s in source) {
                action(s);
            }
        }
    }
}
