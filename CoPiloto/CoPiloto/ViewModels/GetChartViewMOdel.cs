using CoPiloto.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoPiloto.ViewModels
{
    public class GetChartViewModel : BaseViewModel
    {
        #region Properties


        private string airport;

        public string Airport
        {
            get { return airport; }
            set { SetProperty(ref airport, value); }
        }

        public Command SearchCommand { get; }

        #endregion

        public GetChartViewModel()
        {
            SearchCommand = new AsyncCommand(ExecuteSearchCommand, IsBusyStatus);
            Title         = "Pesquisar Cartas";
        }

        protected override void MyChangeCanExecute()
        {
            SearchCommand.ChangeCanExecute();
        }

        async Task ExecuteSearchCommand()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    var (chart, info) = await ChartApi.Current.GetChart(Airport);

                    await Navigation.PushAsync<ListFlyChartsViewModel>(info, chart);
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
    }
}
