using CoPiloto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoPiloto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitsPage : ContentPage
    {
        public UnitsPage()
        {
            InitializeComponent();
            BindingContext = new UnitsViewModel();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (e.NewTextValue.StartsWith("0") || string.IsNullOrEmpty(e.NewTextValue))
                return;

            if (BindingContext is UnitsViewModel vm)
                vm.Calculate(decimal.Parse(e.NewTextValue));
            
        }

        private void SI_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.StartsWith("0") || string.IsNullOrEmpty(e.NewTextValue))
                return;
            if (BindingContext is UnitsViewModel vm)
                vm.Calculate(decimal.Parse(e.NewTextValue), false);
        }
    }
}