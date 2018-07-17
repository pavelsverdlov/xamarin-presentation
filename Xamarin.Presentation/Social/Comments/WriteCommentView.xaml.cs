
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Social.Comments {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WriteCommentView : Grid {
        public WriteCommentView() {
            InitializeComponent();

            //Test.Completed += Test_Completed;
        }

        private void Test_Completed(object sender, System.EventArgs e) {
            
        }
    }
}