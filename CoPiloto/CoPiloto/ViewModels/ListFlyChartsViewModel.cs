using CoPiloto.Extentions;
using CoPiloto.Models;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using CoPiloto.Helpers;

namespace CoPiloto.ViewModels
{
    public class ListFlyChartsViewModel : BaseViewModel
    {
        #region Properties

        public CustomCollection<ChartType> MyCharts { get; }

        public Command ChartSelectedCommand { get; }

        Info info;

        #endregion

        public async override Task InitializeAsync(object[] args)
        {
            info      = (Info)args[0];
            var chart = (Charts)args[1];

            

            if (chart is null)
            {
                await DisplayAlert("Aviso", $"Nenhuma carta encontrada para o {info.Name}");
                await Navigation.PopAsync();
                return;
            }

            var teste = new ObservableCollection<Approach>(chart.Approach);

            //MyCharts.Add(new ChartType { Type = "General" , Charts = chart.General , IsVisible = false });
            //MyCharts.Add(new ChartType { Type = "Sid"     , Charts = chart.Sid     , IsVisible = false });
            MyCharts.Add(new ChartType { Type = "Approach", Charts = teste, IsVisible = false });
            //MyCharts.Add(new ChartType { Type = "Star"    , Charts = chart.Star    , IsVisible = false });

        }

        protected override void MyChangeCanExecute() => 
            ChartSelectedCommand.ChangeCanExecute();

        public ListFlyChartsViewModel()
        {
            ChartSelectedCommand = new AsyncCommand<string>(ExecuteSelectedChartCommand, IsBusyStatus);
            MyCharts             = new CustomCollection<ChartType>();
        }

        async Task ExecuteSelectedChartCommand(string url)
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    await Navigation.PushAsync<ChartViewModel>(url);
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Erro", $"Erro:{ex.Message}", "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            }
            return;
        }

        public void ExpandList(ChartType myChart)
        {
            var item = MyCharts.SingleOrDefault(x => x.Type == myChart.Type);
            item.IsVisible = !item.IsVisible;
            MyCharts.ReportItemChanged(item);
        }
    }
}
