using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Plugins.PlatformTask.Sample.Core;
using UIKit;

namespace MvvmCross.Plugins.PlatformTask.Sample.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
            /* Required constructor */
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}

