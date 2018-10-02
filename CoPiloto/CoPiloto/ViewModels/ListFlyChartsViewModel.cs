using CoPiloto.Extentions;
using CoPiloto.Models;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using CoPiloto.Helpers;
using Xamarin.Forms.Internals;

namespace CoPiloto.ViewModels
{
    public class SelectedHeaderViewModel
    {
        public bool IsSelected { get; set; }

        public Category Category { get; set; }

        //public Charts Charts { get; set; }
    }


    public class ListFlyChartsViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<Grouping<SelectedHeaderViewModel, LocalChart>> MyCharts { get; }

        public Command<Grouping<SelectedHeaderViewModel, LocalChart>> ShowCommand { get; }

        public Command ChartSelectedCommand { get; }

        ObservableCollection<LocalChart> local;

        Info info;

        #endregion

        public async override Task InitializeAsync(object[] args)
        {
            info      = (Info)args[0];
            var chart = (Charts)args[1];

           


            local = Services.ChartApi.Current.PrepareChart(chart);

            var group = local.OrderBy(x => x.Category.CategoryId)
                             .GroupBy(x => x.Category)
                             .Select(x => new Grouping<SelectedHeaderViewModel, LocalChart>
                             (new SelectedHeaderViewModel { IsSelected = false, Category = x.Key }, x));

            group.ForEach(x => MyCharts.Add(x));
            

            if (chart is null)
            {
                await DisplayAlert("Aviso", $"Nenhuma carta encontrada para o {info.Name}");
                await Navigation.PopAsync();
                return;
            }

            var teste = new ObservableCollection<Approach>(chart.Approach);
        }

        protected override void MyChangeCanExecute() => 
            ChartSelectedCommand.ChangeCanExecute();

        public ListFlyChartsViewModel()
        {
            ChartSelectedCommand = new AsyncCommand<string>(ExecuteSelectedChartCommand, IsBusyStatus);
            ShowCommand          = new Command<Grouping<SelectedHeaderViewModel, LocalChart>>(ExecuteShowCommand);
            MyCharts             = new ObservableCollection<Grouping<SelectedHeaderViewModel, LocalChart>>();

            Title = "Lista de cartas";
        }

        void ExecuteShowCommand(Grouping<SelectedHeaderViewModel, LocalChart> obj)
        {
            if (obj is null) return;

            obj.Key.IsSelected = !obj.Key.IsSelected;

            if (obj.Count == 0)
                local.Where(x => (x.Category.CategoryId.Equals(obj.Key.Category.CategoryId))).ForEach(obj.Add);
            else
                obj.Clear();
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

       
    }
}
