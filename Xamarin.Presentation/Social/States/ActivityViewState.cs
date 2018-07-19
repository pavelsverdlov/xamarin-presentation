namespace Xamarin.Presentation.Social.States {
    public class ActivityViewState : Framework.VSVVM.BaseViewState {
        public string Title { get; set; }
        public string ActorName { get; set; }
        public string Verb { get; set; }
        public ActivityDatesState Dates { get; set; }
        public string Body { get; set; }

        public ButtonModel Left { get; set; }
        public ButtonModel Middle { get; set; }
        public ButtonModel Right { get; set; }

        public ActivityViewState() {
            Left = new ButtonModel { IsVisible = true, Image = "Like.png" };
            Middle = new ButtonModel { IsVisible = true, Image = "Comments.png" };
            Right = new ButtonModel { IsVisible = true, Image = "Share.png" };
        }

        public void Push(ActivityViewState state) {
            base.Push(
                (nameof(Title), state.Title),
                (nameof(ActorName), state.ActorName),
                (nameof(Body), state.Body),
                (nameof(Dates), new ActivityDatesState {
                        DateCreated = state.Dates.DateCreated,
                        DateClosed = state.Dates.DateClosed,
                }),
                (nameof(Verb), state.Verb));
        }
    }
}
