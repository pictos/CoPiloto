
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CoPiloto.Views.Templates
{
    public partial class FPView : ContentView
    {
        public FPView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty AltitudeTextProperty =
            BindableProperty.Create(nameof(AltitudeText),
                        typeof(string),
                        typeof(FPView),
                        default(string),
                        BindingMode.TwoWay);

        public string AltitudeText { get => (string)GetValue(AltitudeTextProperty); set => SetValue(AltitudeTextProperty, value); }

      //  private static void OnAltitudeTextChanged(BindableObject bindable, object oldValue, object newValue)
      //{
      //      var view = (FPView)bindable;
      //      view.Altitude.Text = (string)newValue;
      //  }


        public static readonly BindableProperty PlaceholderAltitudeProperty = 
            BindableProperty.Create(nameof(PlaceholderAltitude),
                        typeof(string),
                        typeof(FPView),
                        default(string),
                        propertyChanged: OnPlaceholderAltitudeChanged);

        public string PlaceholderAltitude { get => (string)GetValue(PlaceholderAltitudeProperty); set => SetValue(PlaceholderAltitudeProperty, value); }

        private static void OnPlaceholderAltitudeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (FPView)bindable;
            view.Altitude.Placeholder = (string)newValue;
        }


        public static readonly BindableProperty SpeedTextProperty = 
            BindableProperty.Create(nameof(SpeedText),
                        typeof(string),
                        typeof(FPView),
                        default(string),
                        BindingMode.TwoWay);

        public string SpeedText { get => (string)GetValue(SpeedTextProperty); set => SetValue(SpeedTextProperty, value); }

        //private static void OnSpeedTextChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var view = (FPView)bindable;
        //    view.Speed.Text = (string)newValue;
        //}


        public static readonly BindableProperty PlaceholderSpeedProperty = 
            BindableProperty.Create(nameof(PlaceholderSpeed),
                        typeof(string),
                        typeof(FPView),
                        default(string),
                        propertyChanged: OnPlaceholderSpeedChanged);

        public string PlaceholderSpeed { get => (string)GetValue(PlaceholderSpeedProperty); set => SetValue(PlaceholderSpeedProperty, value); }

        private static void OnPlaceholderSpeedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (FPView)bindable;
            view.Speed.Placeholder = (string)newValue;
        }


        public static readonly BindableProperty LabelTextProperty = 
            BindableProperty.Create(nameof(LabelText),
                        typeof(string),
                        typeof(FPView),
                        default(string),
                        propertyChanged: OnLabelTextChanged);

        public string LabelText { get => (string)GetValue(LabelTextProperty); set => SetValue(LabelTextProperty, value); }

        private static void OnLabelTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (FPView)bindable;
            view.MyLabel.Text = (string)newValue;
        }
    }
}