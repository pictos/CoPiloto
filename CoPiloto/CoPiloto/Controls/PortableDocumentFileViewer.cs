using Xamarin.Forms;

namespace CoPiloto.Controls
{
    public class PortableDocumentFileViewer : WebView
    {

        public static readonly BindableProperty UriProperty = 
            BindableProperty.Create(nameof(Uri),
                        typeof(string),
                        typeof(PortableDocumentFileViewer),
                        default(string));

        public string Uri { get => (string)GetValue(UriProperty); set => SetValue(UriProperty, value); }
        
    }
}
