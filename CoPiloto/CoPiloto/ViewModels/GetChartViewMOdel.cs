using CoPiloto.Models;
using CoPiloto.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoPiloto.ViewModels
{
    public class GetChartViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<AiportHistory> Histories { get; }

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
            Histories     = new ObservableCollection<AiportHistory>();
        }

        public override Task InitializeAsync(object[] args)
        {
            Histories.Clear();
            var items = BdService.Current.GetItems<AiportHistory>();

            foreach (var item in items)
                Histories.Add(item);

            return base.InitializeAsync(args);
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

                    var item = new AiportHistory { Icao = Airport };

                    if (VerifyRepeated())
                    {
                        BdService.Current.SaveItem(item);
                        Histories.Add(item); 
                    }

                    await Navigation.PushAsync<ListFlyChartsViewModel>(false, info, chart);
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

        private bool VerifyRepeated()
        {
            var repeated = Histories.Where(x => x.Icao == Airport).ToList();
            return (repeated.Count > 0) ? false : true;
        }
    }
}
