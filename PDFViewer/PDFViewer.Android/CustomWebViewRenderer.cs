using Android.Content;
using PDFViewer.Classes;
using AppORCA.Droid;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace AppORCA.Droid
{
    class CustomWebViewRenderer : WebViewRenderer
    {
        private CustomWebView _pdfJsWebView;

        public CustomWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            _pdfJsWebView = Element as CustomWebView;

            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.BuiltInZoomControls = true;
            Control.Settings.AllowContentAccess = true;
            Control.Settings.AllowFileAccess = true;
            Control.Settings.AllowFileAccessFromFileURLs = true;
            Control.Settings.AllowUniversalAccessFromFileURLs = true;

            if (_pdfJsWebView.Uri != null)
                //Control.LoadUrl($"file:///android_asset/pdfjs/web/viewer.html?file={WebUtility.UrlEncode(_pdfJsWebView.Uri)}");
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(_pdfJsWebView.Uri))));
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(CustomWebView.Uri) && _pdfJsWebView.Uri != null)
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(_pdfJsWebView.Uri))));
        }
    }
}