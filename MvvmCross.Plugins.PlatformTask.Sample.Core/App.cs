using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.PlatformTask.Sample.Core.ViewModels;

namespace MvvmCross.Plugins.PlatformTask.Sample.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<TaskViewModel>());
        }
    }
}

