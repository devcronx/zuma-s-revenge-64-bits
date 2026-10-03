using System;
using System.IO;
using Foundation;
using UIKit;

namespace ZumasRevenge
{
    // iOS entry point
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
            try
            {
                // Set current directory to the Content folder in the app bundle
                // so the game's ResourceManager can find the assets
                string bundlePath = NSBundle.MainBundle.BundlePath;
                string contentPath = Path.Combine(bundlePath, "Content");
                if (Directory.Exists(contentPath))
                {
                    Directory.SetCurrentDirectory(contentPath);
                }
                
                var game = new GameMain();
                game.Run();
            }
            catch (Exception ex)
            {
                // Log the exception to help debugging
                Console.WriteLine("FATAL: " + ex.ToString());
                throw;
            }
            return true;
        }
    }
}
