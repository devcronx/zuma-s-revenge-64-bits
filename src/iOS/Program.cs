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
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            var label = new UILabel(new CGRect(10, 50, Window.Bounds.Width - 20, Window.Bounds.Height - 100));
            label.Lines = 0;
            label.Font = UIFont.SystemFontOfSize(12);
            label.Text = "Iniciando...";
            label.TextColor = UIColor.Black;
            label.BackgroundColor = UIColor.White;
            Window.AddSubview(label);
            Window.BackgroundColor = UIColor.White;
            Window.MakeKeyAndVisible();

            try
            {
                label.Text = "Paso 1: Bundle path...";
                string bundlePath = NSBundle.MainBundle.BundlePath;
                label.Text = "Bundle: " + bundlePath;
                
                string contentPath = Path.Combine(bundlePath, "Content");
                bool contentExists = Directory.Exists(contentPath);
                label.Text += "\nContent existe: " + contentExists;
                
                if (contentExists)
                {
                    Directory.SetCurrentDirectory(contentPath);
                    label.Text += "\nDir actual: " + Directory.GetCurrentDirectory();
                }
                
                label.Text += "\n\nPaso 2: Creando GameMain...";
                
                // Force UI update
                NSRunLoop.Current.RunUntil(NSDate.FromTimeIntervalSinceNow(0.5));
                
                var game = new GameMain();
                label.Text += "\nGameMain creado OK";
                NSRunLoop.Current.RunUntil(NSDate.FromTimeIntervalSinceNow(0.5));
                
                label.Text += "\n\nPaso 3: Ejecutando game.Run()...";
                NSRunLoop.Current.RunUntil(NSDate.FromTimeIntervalSinceNow(0.5));
                
                game.Run();
            }
            catch (Exception ex)
            {
                label.Text = "ERROR:\n" + ex.ToString();
            }
            
            return true;
        }
    }
}
