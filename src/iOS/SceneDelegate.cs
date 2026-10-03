using Foundation;
using UIKit;

namespace ZumasRevenge
{
    [Register("SceneDelegate")]
    public class SceneDelegate : UIResponder, IUIWindowSceneDelegate
    {
        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("scene:willConnectToSession:options:")]
        public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
        {
            // The AppDelegate will handle the actual game initialization
            // This just satisfies the scene lifecycle requirement
        }
    }
}
