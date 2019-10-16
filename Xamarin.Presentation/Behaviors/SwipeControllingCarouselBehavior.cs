using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Presentation.Behaviors;

namespace Xamarin.Presentation.Behaviors {
    public interface ISwipeControllingPage {
        int CurrentPage { get; }
        void MoveNext();
        void MovePrev();
    }
    public class SwipeControllingCarouselBehavior : BindableBehavior<CarouselPage>, ISwipeControllingPage {
        CarouselPage page;
        int currentPage = 0;

        protected override void OnAttachedTo(CarouselPage page) {
            this.page = page;
            page.CurrentPageChanged += OnCurrentPageChanged;
        }
        protected override void OnDetachingFrom(CarouselPage page) {
            page.CurrentPageChanged -= OnCurrentPageChanged;
            this.page = null;
        }


        public static readonly BindableProperty NextRegistrationPageProperty = BindableProperty.Create(nameof(NextRegistrationPage),
            typeof(Command<ISwipeControllingPage>), typeof(SwipeControllingCarouselBehavior), null);

        public static readonly BindableProperty PrevRegistrationPageProperty = BindableProperty.Create(nameof(PrevRegistrationPage),
           typeof(Command<ISwipeControllingPage>), typeof(SwipeControllingCarouselBehavior), null);

        public Command<ISwipeControllingPage> NextRegistrationPage {
            get { return (Command<ISwipeControllingPage>)GetValue(NextRegistrationPageProperty); }
            set { SetValue(NextRegistrationPageProperty, value); }
        }

        public Command<ISwipeControllingPage> PrevRegistrationPage {
            get { return (Command<ISwipeControllingPage>)GetValue(PrevRegistrationPageProperty); }
            set { SetValue(PrevRegistrationPageProperty, value); }
        }

        protected void NextPage(object sender, EventArgs e) {
            NextRegistrationPage?.Execute(this);
            page.CurrentPage = page.Children[currentPage];
        }

        private void OnCurrentPageChanged(object sender, EventArgs e) {
            //currentPage will changed only throuth IRegistrationCarouselPage
            if (page.CurrentPage.TabIndex > currentPage) {
                NextRegistrationPage?.Execute(this);
            } else if (page.CurrentPage.TabIndex < currentPage) {
                PrevRegistrationPage?.Execute(this);
            }
            if (currentPage != page.CurrentPage.TabIndex) {
                page.CurrentPage = page.Children[currentPage];
            }
        }


        int ISwipeControllingPage.CurrentPage => page.CurrentPage.TabIndex;
        public void MoveNext() {
            currentPage += 1;
        }
        public void MovePrev() {
            currentPage -= 1;
        }
    }
}
