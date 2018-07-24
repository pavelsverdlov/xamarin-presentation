using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Social.Activities {
    public class NewActivitySnapshot : BindableObject {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(NewActivitySnapshot), default(string));
        public static readonly BindableProperty RubricProperty = BindableProperty.Create(nameof(Rubric), typeof(string), typeof(NewActivitySnapshot), default(string));
        public static readonly BindableProperty FinishDateProperty = BindableProperty.Create(nameof(FinishDate), typeof(DateTime), typeof(NewActivitySnapshot), DateTime.Now);
        public static readonly BindableProperty BodyProperty = BindableProperty.Create(nameof(Body), typeof(string), typeof(NewActivitySnapshot), default(string));

        public string Title {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public string Rubric {
            get => (string)GetValue(RubricProperty);
            set => SetValue(RubricProperty, value);
        }
        public DateTime FinishDate {
            get => (DateTime)GetValue(FinishDateProperty);
            set => SetValue(FinishDateProperty, value);
        }
        public string Body {
            get => (string)GetValue(BodyProperty);
            set => SetValue(BodyProperty, value);
        }
    }

    [ContentProperty("Data")]
    [AcceptEmptyServiceProvider]
    public class ActivitySnapshotMarkup : IMarkupExtension<NewActivitySnapshot> {
        public NewActivitySnapshot Data { get; set; }

        public NewActivitySnapshot ProvideValue(IServiceProvider serviceProvider) {
            return Data;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) {
            return (this as IMarkupExtension<NewActivitySnapshot>).ProvideValue(serviceProvider);
          
        }
        
    }
}
