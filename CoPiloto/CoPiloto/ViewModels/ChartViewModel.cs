using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoPiloto.ViewModels
{
    public class ChartViewModel : BaseViewModel
    {

        private string url;

        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

        public ChartViewModel() { }

        public override Task InitializeAsync(object[] args)
        {
            Url = (string)args[0];

            return base.InitializeAsync(args);
        }
    }
}
