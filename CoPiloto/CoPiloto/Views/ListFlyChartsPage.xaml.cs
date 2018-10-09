using CoPiloto.Models;
using CoPiloto.ViewModels;

using Xamarin.Forms;

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