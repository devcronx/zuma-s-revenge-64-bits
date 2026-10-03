using System;
using System.IO;
using Foundation;
using UIKit;

namespace ZumasRevenge
{
    public class Application
    {
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }

    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            
            try
            {
                string bundlePath = NSBundle.MainBundle.BundlePath;
                string contentPath = Path.Combine(bundlePath, "Content");
                
                string msg = "Bundle: " + bundlePath + "\n";
                msg += "Content exists: " + Directory.Exists(contentPath) + "\n";
                msg += "Content path: " + contentPath;
                
                // Show diagnostic alert
                var alert = UIAlertController.Create("Debug", msg, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                
                var vc = new UIViewController();
                Window.RootViewController = vc;
                Window.MakeKeyAndVisible();
                vc.PresentViewController(alert, true, null);
                
                // Don't start game yet, just show the debug info
                return true;
            }
            catch (Exception ex)
            {
                var alert = UIAlertController.Create("Error", ex.ToString(), UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                var vc = new UIViewController();
                Window.RootViewController = vc;
                Window.MakeKeyAndVisible();
                vc.PresentViewController(alert, true, null);
                return true;
            }
        }
    }
}
