using CoPiloto.Models;
using CoPiloto.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoPiloto.ViewModels
{
    public class MasterPageViewModel : BaseViewModel
    {
        public ObservableCollection<PageType> Pages { get; }

        public Command NavigateCommand { get; }

        public MasterPageViewModel()
        {
            Pages = new ObservableCollection<PageType>();
            NavigateCommand = new AsyncCommand<ViewModelType>(ExecuteNavigateCommand);
            PopulateMaster();
        }

        async Task ExecuteNavigateCommand(ViewModelType arg)
        {
            try
            {
                await Navigate(arg);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro!", ex.Message);
            }
        }

        async Task Navigate(ViewModelType type)
        {
            switch (type)
            {
                case ViewModelType.GetChartViewModel:
                    await Navigation.PushAsync<GetChartViewModel>(true);
                    break;
                case ViewModelType.UnitsViewModel:
                    await Navigation.PushAsync<UnitsViewModel>(true);
                    break;
                case ViewModelType.FPViewViewModel:
                    await Navigation.PushAsync<CreateFPViewModel>(true);
                    break;

                default:
                    return;
            }
        }

        void PopulateMaster()
        {
            try
            {
                var pages = new[]
                {
                    new PageType { Name = "Pesquisar Cartas", TypePage = ViewModelType.GetChartViewModel},
                    new PageType { Name = "Conversor de Unidades", TypePage = ViewModelType.UnitsViewModel},
                    new PageType { Name = "Criar plano de voo", TypePage = ViewModelType.FPViewViewModel},
                };

                foreach (var item in pages)
                    Pages.Add(item);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }
    }
}
