
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Presentation.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditableView : ContentView {

        public static readonly BindableProperty IsEditingProperty =
          BindableProperty.CreateAttached(nameof(IsEditing), typeof(bool), typeof(EditableView), null, propertyChanged: OnItemSelectedPropertyChanged);

        private static void OnItemSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (EditableView)bindable;
            var isEditing = Convert.ToBoolean(newValue);
            DispatcherEx.BeginRise(() => {
                _this.WriteLayout.IsVisible = isEditing;
                _this.ReadLayout.IsVisible = !isEditing;

                //if (_this.WriteLayout.IsVisible) {
                //    _this.WriteHeader.Text = _this.Header;
                //    _this.WriteValue.Text = _this.Value;
                //}
                //if (_this.ReadLayout.IsVisible) {
                //    _this.ReadValue.Text = _this.Value;
                //    _this.ReadHeader.Text = _this.Header;
                //}
            });
        }

        public bool IsEditing {
            get { return (bool)GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }


        public static readonly BindableProperty HeaderProperty =
          BindableProperty.CreateAttached(nameof(Header), typeof(string), typeof(EditableView), null, propertyChanged: OnHeaderPropertyPropertyChanged);

        private static void OnHeaderPropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (EditableView)bindable;
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
          BindableProperty.CreateAttached(nameof(Value), typeof(string), typeof(EditableView), null, propertyChanged: OnValuePropertyPropertyChanged);

        private static void OnValuePropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            var _this = (EditableView)bindable;
            var header = Convert.ToString(newValue);
            DispatcherEx.BeginRise(() => {
                _this.ReadValue.Text = header;
                _this.WriteValue.Text = header;
            });
        }

        public string Value {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }



        public EditableView() {
            InitializeComponent();
        }
    }
}