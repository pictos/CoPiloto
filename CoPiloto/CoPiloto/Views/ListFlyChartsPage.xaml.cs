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
    public partial class ListFlyChartsPage : ContentPage
    {
        public ListFlyChartsPage()
        {
            InitializeComponent();
        }

        void Charts_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is LocalChart lc)
                (BindingContext as ListFlyChartsViewModel)?.ChartSelectedCommand.Execute(lc.Uri);

            ((ListView)sender).SelectedItem = null;
        }
    }
}