using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin.Presentation {
    public static class MapperEx {
        public static IEnumerable<TOut> Map<TIn, TOut>(this IEnumerable<TIn> source) {
            return source.Select(x => Mapper.Map<TOut>(x));
        }
        public static TOut Map<TOut>(this object source) {
            return Mapper.Map<TOut>(source);
        }
    }
}
