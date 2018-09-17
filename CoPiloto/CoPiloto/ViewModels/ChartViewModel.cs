using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoPiloto.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {
        private string _url;
        public string Url
        {
            get => $"{(Device.RuntimePlatform.Equals(Device.Android) ? "file:///android_asset/pdfjs/web/viewer.html?file=" : string.Empty)}{_url}";
            //get => _url;
            set => SetProperty(ref _url, value, () =>
            {
                OnPropertyChanged(nameof(IsPDF));
            });
        }

        public bool IsPDF { get => _url?.EndsWith("pdf", StringComparison.InvariantCultureIgnoreCase) ?? false; }

        public ChartViewModel()
        {
            Title = "Carta";
        }

        public override Task InitializeAsync(object[] args)
        {
            Url = (string)args[0];

            return base.InitializeAsync(args);
        }
    }
}
