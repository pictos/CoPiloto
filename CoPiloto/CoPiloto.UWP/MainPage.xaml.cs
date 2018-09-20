using CoPiloto.Services;

namespace CoPiloto.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Const.Root = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            LoadApplication(new CoPiloto.App());
        }
    }
}
