using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.Presentation {
    public static class ImageSourceEx {
        private static readonly TimeSpan CacheValidity = new TimeSpan(0, 1, 0, 0);
        public static UriImageSource ToCachingSource(this Uri uri) {
            //ImageService.Instance.LoadUrl(uri.ToString(), CacheValidity);
            return new UriImageSource {
                Uri = uri,
                CachingEnabled = true,
                CacheValidity = CacheValidity
            };
        }
    }
}
