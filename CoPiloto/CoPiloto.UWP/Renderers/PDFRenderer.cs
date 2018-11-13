using CoPiloto.Controls;
using CoPiloto.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(PortableDocumentFileViewer), typeof(PDFRenderer))]

namespace CoPiloto.UWP.Renderers
{
    public class PDFRenderer : WebViewRenderer
    {
        string url;
        protected async override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                var control = (PortableDocumentFileViewer)Element;
                url = control.Uri;
                Control.Settings.IsJavaScriptEnabled = true;
                await OpenPDF(url);
            }
        }

        protected async override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(PortableDocumentFileViewer.UriProperty.PropertyName))
            {
                var control = (PortableDocumentFileViewer)Element;
                url = control.Uri;
                await OpenPDF(url);
            }
        }

        async Task OpenPDF(string url)
        {
            if (string.IsNullOrEmpty(url)) return;

            await DownloadPDF();

            string source = string.Format("ms-appx-web:///Assets/pdfjs/web/viewer.html?file=ms-appx-web:///Assets/chart.pdf");
            Control.Navigate(new Uri(source));
        }

        async Task DownloadPDF()
        {
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);

                var appFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                var assetsFolder = await appFolder.GetFolderAsync("Assets");

                var pdfFolder = ApplicationData.Current.LocalCacheFolder;
                var pdf = await pdfFolder.CreateFileAsync("chart.pdf", CreationCollisionOption.ReplaceExisting);

                using (var pdfStream = await pdf.OpenStreamForWriteAsync())
                {
                    await stream.CopyToAsync(pdfStream);
                    await pdf.MoveAsync(assetsFolder, "chart.pdf", NameCollisionOption.ReplaceExisting);
                }
            }
        }
    }
}
