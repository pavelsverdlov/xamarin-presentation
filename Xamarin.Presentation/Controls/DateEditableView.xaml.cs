
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Controls {
    public class DateEditableProperty {
        public DateEditableProperty() { }
        public DateEditableProperty(string property, DateTime value) {
            Property = property;
            Value = value;
        }

        public string Property { get; set; }
        public DateTime Value { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateEditableView : ContentView {

        public string DateFormat { get; set; }

        public static readonly BindableProperty IsEditingProperty =
                  BindableProperty.CreateAttached(nameof(IsEditing), typeof(bool), typeof(DateEditableView), null, propertyChanged: OnItemSelectedPropertyChanged);

        private static void OnItemSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (DateEditableView)bindable;
            var isEditing = Convert.ToBoolean(newValue);
            DispatcherEx.BeginRise(() => {
                _this.WriteLayout.IsVisible = isEditing;
                _this.ReadLayout.IsVisible = !isEditing;
            });
        }

        public bool IsEditing {
            get { return (bool)GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }


        public static readonly BindableProperty HeaderProperty =
          BindableProperty.CreateAttached(nameof(Header), typeof(string), typeof(DateEditableView), null, propertyChanged: OnHeaderPropertyPropertyChanged);

        private static void OnHeaderPropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (DateEditableView)bindable;
            var header = Convert.ToString(newValue);
            DispatcherEx.BeginRise(() => {
                _this.ReadHeader.Text = header;
                _this.WriteHeader.Text = header;
            });
        }

        public string Header {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly BindableProperty ValueProperty =
          BindableProperty.CreateAttached(nameof(Value), typeof(DateTime), typeof(DateEditableView), DateTime.Now, propertyChanged: OnValuePropertyPropertyChanged);

        private static void OnValuePropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (DateEditableView)bindable;
            var val = (DateTime)newValue;
            DispatcherEx.BeginRise(() => {
                _this.ReadValue.Text = val.ToString(_this.DateFormat);
                _this.WriteValue.Date = val;
            });
        }

        public DateTime Value {
            get { return (DateTime)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }



        public DateEditableView() {
            InitializeComponent();
        }

        void OnDateSelected(object sender, DateChangedEventArgs e) {
            var date = e.NewDate;
            ReadValue.Text = date.ToString(DateFormat);
        }
    }
}