using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoPiloto.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartPage : ContentPage
	{
		public ChartPage ()
		{
			InitializeComponent ();
		}

        private void Chart_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains(".pdf"))
            {
                var pdf = new Uri(e.Url);

                Device.OpenUri(pdf);

                e.Cancel = true;
            }
        }
    }
}