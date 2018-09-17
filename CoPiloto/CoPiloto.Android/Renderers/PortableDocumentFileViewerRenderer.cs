using Android.Content;
using CoPiloto.Controls;
using CoPiloto.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PortableDocumentFileViewer), typeof(PortableDocumentFileViewerRenderer))]

namespace CoPiloto.Droid.Renderers
{
    class PortableDocumentFileViewerRenderer : WebViewRenderer
    {
        public PortableDocumentFileViewerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Settings.AllowFileAccessFromFileURLs = true;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
            }

            //Control.LoadUrl($"file:///android_asset/pdfjs/web/viewer.html?file={Control.Url}");
        }
    }
}