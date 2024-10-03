using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebView2WinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        string uriString = "https://myradar-ai-dev.onrender.com/?userid=c10ee51f50c0b4ebeeea0e3f9e33f136644e7fbc&lat=28.54&lon=-81.37&units=us&routecast=false&personalize=false";
        public MainWindow()
        {
            this.InitializeComponent();
#if NOTIMPORTANT
                this.Activated += MainWindow_Activated;
#endif
            gotoChatBotTextBox.Text = uriString;
        }

        private void GotoChatBotClick(object sender, RoutedEventArgs e)
        {
            webView2.Source = new Uri(uriString);
        }

        private async void ExecuteJavaScriptClick(object sender, RoutedEventArgs e)
        {
            string script = "alert('Hello from WebView2!');";
            await this.webView2.CoreWebView2.ExecuteScriptAsync(script);

            //string script = "window.location.href = 'https://myradar-ai-dev.onrender.com/?userid=c10ee51f50c0b4ebeeea0e3f9e33f136644e7fbc&lat=28.54&lon=-81.37&units=us&routecast=false&personalize=false&id=dGhyZWFkX2tuSmdnd09SQXFIcVVmeHdZZDR6NTlkZ1';";
            //await webView2.CoreWebView2.ExecuteScriptAsync(script);
        }

        private void GotoGoogleClick(object sender, RoutedEventArgs e)
        {
            webView2.Source = new Uri("https://www.google.com");
        }

        private void GotoSpecificLinkClick(object sender, RoutedEventArgs e)
        {
            webView2.Source = new Uri(spcTxtbox.Text);
        }

        private void webView2_NavigationStarting(WebView2 sender
    , Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs args)
        {
            Debug.WriteLine($"NEW URI NAVIGATING : {args.Uri.ToString()}");
        }

        private void webView2_NavigationCompleted(WebView2 sender
    , Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            Debug.WriteLine($"NAVIGATION COMPLETED");
        }

#if NOTIMPORTANT

        bool isLoaded = false;
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        private async void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                if (isLoaded)
                    return;
                isLoaded = true;

                await webView2.EnsureCoreWebView2Async();

                this.webView2.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
                this.webView2.CoreWebView2.ClientCertificateRequested += CoreWebView2_ClientCertificateRequested;
                this.webView2.CoreWebView2.ContentLoading += CoreWebView2_ContentLoading;
                this.webView2.ContextRequested += Sender_ContextRequested;

                webView2.WebMessageReceived += WebView2_WebMessageReceived;
                webView2.CoreWebView2Initialized += WebView2_CoreWebView2Initialized;
                webView2.ContextRequested += WebView2_ContextRequested;
                webView2.ContextCanceled += WebView2_ContextCanceled;
                webView2.BringIntoViewRequested += WebView2_BringIntoViewRequested;
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }



        private void WebView2_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
        {

        }

        private void WebView2_ContextCanceled(UIElement sender, RoutedEventArgs args)
        {

        }

        private void WebView2_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
        {

        }

        private void WebView2_CoreWebView2Initialized(WebView2 sender, CoreWebView2InitializedEventArgs args)
        {

        }

        private void Sender_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
        {

        }

        private void CoreWebView2_ContentLoading(Microsoft.Web.WebView2.Core.CoreWebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs args)
        {

        }

        private void CoreWebView2_ClientCertificateRequested(Microsoft.Web.WebView2.Core.CoreWebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2ClientCertificateRequestedEventArgs args)
        {

        }

        private void CoreWebView2_WebResourceRequested(Microsoft.Web.WebView2.Core.CoreWebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceRequestedEventArgs args)
        {

        }

        private void WebView2_WebMessageReceived(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs args)
        {

        }
#endif
    }
}
