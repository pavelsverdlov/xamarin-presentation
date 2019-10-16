using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Presentation.Social.States {
    public abstract class ActivityImageViewModel : Framework.MVVM.BaseViewModel {
        public FormattedString Header {
            get {
                return new FormattedString {
                    Spans = {
                        new Span { Text = ActorName, FontAttributes = FontAttributes.Bold },
                        new Span { Text = " • " },
                        new Span { Text = Verb },
                        new Span { Text = " " },
                        new Span { Text = Title, FontAttributes = FontAttributes.Bold },
                    }
                };
            }
        }

        public string Title { get; set; }
        public string ActorImage { get; set; }
        public string ActorName { get; set; }
        public string Verb { get; set; }
        public ActivityDatesState Dates { get; set; }
        public string Body { get; set; }
        public ImageSource ActivityImage { get; set; }

        public ButtonModel Left { get; set; }
        public ButtonModel Middle { get; set; }
        public ButtonModel Right { get; set; }

        public ICommand ClickCommand { get; protected set; }

        public ActivityImageViewModel() {
            //ActorImage = "person.png";
            Left = new ButtonModel { IsVisible = true, Image = "Like.png" };
            Middle = new ButtonModel { IsVisible = true, Image = "Comments.png" };
            Right = new ButtonModel { IsVisible = true, Image = "Share.png" };
        }
        
        public bool IsVideo => Title == "video";
    }

    public class ActivityVideoViewState : Framework.VSVVM.BaseViewState {

    }

}
