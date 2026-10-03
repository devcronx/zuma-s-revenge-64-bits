using System;
using System.IO;
using Foundation;
using UIKit;
using CoreGraphics;

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
            // SIMPLEST TEST: Just show a red screen. If this works, the app launches.
            // If it crashes, the problem is in iOS/.NET startup, not our code.
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.BackgroundColor = UIColor.Red;
            Window.MakeKeyAndVisible();
            return true;
        }
    }
}
