using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoPiloto.Views
{
    public partial class FpDetailPage : ContentPage
    {
        public FpDetailPage()
        {
            InitializeComponent();
            //map.MoveToMapRegion(MapSpan.FromCenterAndRadius(new Position(-19.64, -64), Distance.FromKilometers(2)));
        }
    }
}