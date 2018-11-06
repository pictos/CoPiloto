using System;
using System.Collections.Generic;
using System.Text;
using APIFP.Model;
using CoPiloto.Helpers;
using System.Threading.Tasks;

namespace CoPiloto.ViewModels
{
    sealed class FpDetailViewModel : BaseViewModel
    {
        #region Properties


        private string toName;

        public string ToName
        {
            get { return toName; }
            set { SetProperty(ref toName, value); }
        }


        private string fromName;

        public string FromName
        {
            get { return fromName; }
            set { SetProperty(ref fromName, value); }
        }


        private string distance;

        public string Distance
        {
            get { return distance; }
            set { SetProperty(ref distance, value); }
        }


        private string maxAlt;

        public string MaxAlt
        {
            get { return maxAlt; }
            set { SetProperty(ref maxAlt, value); }
        }



        private string metarFrom;

        public string MetarFrom
        {
            get { return metarFrom; }
            set { SetProperty(ref metarFrom, value); }
        }


        private string metarTo;

        public string MetarTo
        {
            get { return metarTo; }
            set { SetProperty(ref metarTo, value); }
        }

        public string InformationFrom { get; private set; }
        public string InformationTo { get; private set; }

        #endregion


        public override async Task InitializeAsync(object[] args)
        {
            var fp = (GenerateResponseFP)args[0];
            
            Title = $"{fp.FromIcao} para {fp.ToIcao}";
            FromName = $"Partida: {fp.FromName}";
            ToName = $"Destino: {fp.ToName}";
            MaxAlt = $"Altitude máxima: {fp.MaxAltitude}";
            var kmDistance = ConvertersValues.DistanceSI(decimal.Parse(fp.Distance.ToString())).ToString("{0:N2}");
            Distance = $"Distância: {fp.Distance.ToString()} nm / {kmDistance} km ";
            
            InformationFrom =fp.FromName;
            InformationTo = fp.ToName;

            var metarFrom = await APIFP.FP.Current.GetWheaterAsync(fp.FromIcao);
            var metarTo = await APIFP.FP.Current.GetWheaterAsync(fp.ToIcao);
            MetarFrom = metarFrom.Metar;
            MetarTo = metarTo.Metar;

            OnPropertyChanged(nameof(InformationFrom));
            OnPropertyChanged(nameof(InformationTo));
            
        }


    }
}
