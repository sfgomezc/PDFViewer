using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDFViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDFViewerPage : ContentPage
    {
        public PDFViewerPage()
        {
            InitializeComponent();

            CustomWebView.Uri = "PDFSample.pdf";
        }
    }
}