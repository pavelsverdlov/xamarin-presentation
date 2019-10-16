using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Social.Profiles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileView : ScrollView {
		public ProfileView ()
		{
			InitializeComponent ();
		}
	}
}