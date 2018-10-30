using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIFP;
using APIFP.Model;
using Xamarin.Forms;

namespace CoPiloto.ViewModels
{
    sealed class CreateFPViewModel : BaseViewModel
    {
        #region Properties

        private string departue;

        public string Departue
        {
            get { return departue; }
            set { SetProperty(ref departue, value); }
        }


        private string destination;

        public string Destination
        {
            get { return destination; }
            set { SetProperty(ref destination, value); }
        }



        private string altitudeA;

        public string AltitudeA
        {
            get { return altitudeA; }
            set { SetProperty(ref altitudeA, value); }
        }


        private string speedA;

        public string SpeedA
        {
            get { return speedA; }
            set { SetProperty(ref speedA, value); }
        }


        private string altitudeC;

        public string AltitudeC
        {
            get { return altitudeC; }
            set { SetProperty(ref altitudeC, value); }
        }   


        private string speedC;

        public string SpeedC
        {
            get { return speedC; }
            set { SetProperty(ref speedC, value); }
        }


        private string AltitudeD;

        public string altitudeD
        {
            get { return AltitudeD; }
            set { SetProperty(ref AltitudeD, value); }
        }


        private string speedD;

        public string SpeedD
        {
            get { return speedD; }
            set { SetProperty(ref speedD, value); }
        }

        #endregion

        public Command CreateFPCommand { get; }

        public override Task InitializeAsync(object[] args)
        {
            AltitudeC = "35000";
            FP.Current.Init();
            return base.InitializeAsync(args);
        }

        public CreateFPViewModel()
        {
            CreateFPCommand = new AsyncCommand(ExecuteCreateFPCommand);
        }

        async Task ExecuteCreateFPCommand()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    var fp = new GenerateFP
                    {
                        FromIcao    = Departue,
                        ToIcao      = Destination,
                        MaxAlt      = AltitudeC,
                        CruiseSpeed = SpeedC
                    };

                    var result = await FP.Current.GenerateRouteAsync(fp);

                    await Navigation.PushAsync<FpDetailViewModel>(false,result);
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
