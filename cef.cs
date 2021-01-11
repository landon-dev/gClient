using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Event;
using CefSharp.WinForms;
using gClient;
using _Cef = CefSharp.Cef;

namespace gClient
{
    class Cef
    {
        public class Browser
        {
            public static ChromiumWebBrowser gameBrowser;
            public static void Init()
            {
                GlobalRef._clientFm.Invoke(new MethodInvoker(delegate
                {
                    using (CefSettings settings = new CefSettings()
                    {
                        CachePath = $@"{Application.StartupPath}\gClient Cache",
                        LogFile = "gClient-Web.log",
                        BrowserSubprocessPath = $@"{Application.StartupPath}\CefSharp.BrowserSubprocess.exe",
                        IgnoreCertificateErrors = true
                    })
                    {
                        _Cef.EnableHighDPISupport();
                        CefSharpSettings.ShutdownOnExit = true;
                        settings.CefCommandLineArgs.Add("enable-gpu", "1");
                        settings.CefCommandLineArgs.Add("enable-webgl", "1");
                        settings.CefCommandLineArgs.Add("no-proxy-server", "1");
                        if (!_Cef.IsInitialized) _Cef.Initialize(settings);
                    }

                    gameBrowser = new ChromiumWebBrowser(mainFm.ServerUrl);
                    GlobalRef._clientFm.bodyPnl.Controls.Add(gameBrowser);
                    gameBrowser.Dock = DockStyle.Fill;


                    gameBrowser.FrameLoadEnd += (sender, args) =>
                    {
                        if (args.Frame.IsMain)
                        {

                            args.Browser.MainFrame.ExecuteJavaScriptAsync("document.getElementById('tabs').remove();");
                            args.Browser.MainFrame.ExecuteJavaScriptAsync("document.getElementById('temp').remove();");
                            args.Browser.MainFrame.ExecuteJavaScriptAsync("$('iframe').remove();");
                            args.Browser.MainFrame.ExecuteJavaScriptAsync("document.body.style.overflow = 'hidden'");
                        }
                    };

                }));

            }


            public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
            {
                callback.Continue(true);
                return true;
            }

        }
    }
}