using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace MvvmCross.Plugins.PlatformTask.Sample.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        protected string Tag => typeof(AppDelegate).Name;

        protected NSTimer BackgroundTimeTimer
        {
            get;
            private set;
        }

        public override UIWindow Window
        {
            get;
            set;
        }

        private static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        private void OnBackgroundTimeTimerAction(NSTimer timer)
        {
            var backgroundTimeRemaining = (int)UIApplication.SharedApplication.BackgroundTimeRemaining;

            if (backgroundTimeRemaining == int.MinValue)
            {
                return;
            }

            Mvx.TaggedTrace(Tag, $"BackgroundTimeRemaining: {backgroundTimeRemaining}");
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            new Setup(this, Window).Initialize();

            Mvx.Resolve<IMvxAppStart>().Start();

            Window.MakeKeyAndVisible();

            return true;
        }

        public override void DidEnterBackground(UIApplication application)
        {
            Mvx.TaggedTrace(Tag, "DidEnterBackground");

            BackgroundTimeTimer = NSTimer.CreateRepeatingScheduledTimer(1, OnBackgroundTimeTimerAction);
            BackgroundTimeTimer.Fire();
        }

        public override void WillEnterForeground(UIApplication application)
        {
            Mvx.TaggedTrace(Tag, "WillEnterForeground");

            BackgroundTimeTimer.Invalidate();
            BackgroundTimeTimer.Dispose();
        }
    }
}

