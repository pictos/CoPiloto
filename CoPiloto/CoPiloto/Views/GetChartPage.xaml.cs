using CoPiloto.Models;
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
    public partial class GetChartPage : ContentPage
    {
        public GetChartPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item is AiportHistory ar)
            {
                if (BindingContext is GetChartViewModel vm)
                {
                    vm.Airport = ar.Icao;
                    vm.SearchCommand.Execute(null);
                }

            }

            (sender as ListView).SelectedItem = null;
        }
    }
}