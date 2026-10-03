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
            var game = new GameMain();
            game.Run();
            return true;
        }
    }
}
