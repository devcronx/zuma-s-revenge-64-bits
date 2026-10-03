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

        public override UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            var config = new UISceneConfiguration("Default Configuration", connectingSceneSession.Role);
            config.DelegateClass = ObjCRuntime.Class.GetHandle(typeof(SceneDelegate));
            return config;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            try
            {
                string bundlePath = NSBundle.MainBundle.BundlePath;
                string contentPath = Path.Combine(bundlePath, "Content");
                if (Directory.Exists(contentPath))
                {
                    Directory.SetCurrentDirectory(contentPath);
                }
                
                var game = new GameMain();
                game.Run();
            }
            catch
            {
                // Silently fail - app will show launch screen then close
                // This prevents the ObjC exception crash
            }
            return true;
        }
    }
}
