using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CoPiloto.Views
{
    public class MDPage : MasterDetailPage
    {
        ViewModels.GetChartViewModel Vm = new ViewModels.GetChartViewModel();

        public MDPage()
        {
            Detail = new NavigationPage(new GetChartPage() { BindingContext = Vm });
            Master = new MasterPage();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Vm.InitializeAsync(null);
        }
    }
}
