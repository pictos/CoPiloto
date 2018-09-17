using CoPiloto.ViewModels;
using Xamarin.Forms;

namespace CoPiloto.Views
{
    public partial class ChartPage : ContentPage
    {
        ChartViewModel ViewModel { get => (ChartViewModel)BindingContext; }

        public ChartPage()
        {
            InitializeComponent();

            pdfWebView.Navigating += PortableDocumentFileViewer_Navigating;
            pdfWebView.Navigated += PortableDocumentFileViewer_Navigated;
        }

        private void PortableDocumentFileViewer_Navigating(object sender, WebNavigatingEventArgs e)
        {
            ViewModel.IsBusy = true;
        }

        private void PortableDocumentFileViewer_Navigated(object sender, WebNavigatedEventArgs e)
        {
            ViewModel.IsBusy = false;
        }
    }
}