
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Social {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityView : StackLayout {
        public ActivityView() {
            InitializeComponent();
        //    BindingContextChanged += ActivityView_BindingContextChanged;
            activityImage.Success += ActivityImage_Success;
        }

        private void ActivityView_BindingContextChanged(object sender, System.EventArgs e) {
            
        }

        private void ActivityImage_Success(object sender, FFImageLoading.Forms.CachedImageEvents.SuccessEventArgs e) {
            double f = (double)e.ImageInformation.OriginalWidth / (double)e.ImageInformation.OriginalHeight;
            double with = Application.Current.MainPage.Width;
            activityImage.HeightRequest = with / f;
            activityImage.WidthRequest = with;
        }
    }
}