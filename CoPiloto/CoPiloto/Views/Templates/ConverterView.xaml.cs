using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoPiloto.Views.Templates
{
    public partial class ConverterView : ContentView
    {
        public ConverterView()
        {
            InitializeComponent();
        }



        public static readonly BindableProperty UnitNameProperty = 
            BindableProperty.Create(nameof(UnitName),
                         typeof(string),
                         typeof(ConverterView),
                         default(string));

        public string UnitName { get => (string)GetValue(UnitNameProperty); set => SetValue(UnitNameProperty, value); }



        public static readonly BindableProperty UnitLeftProperty = 
            BindableProperty.Create(nameof(UnitLeft),
                        typeof(string),
                        typeof(ConverterView),
                        default(string),
                        BindingMode.TwoWay);

        public string UnitLeft { get => (string)GetValue(UnitLeftProperty); set => SetValue(UnitLeftProperty, value); }


        public static readonly BindableProperty UnitRightProperty =
            BindableProperty.Create(nameof(UnitRight),
                        typeof(string),
                        typeof(ConverterView),
                        default(string),
                        BindingMode.TwoWay);

        public string UnitRight { get => (string)GetValue(UnitRightProperty); set => SetValue(UnitRightProperty, value); }
        
    }
}