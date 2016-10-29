using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvmCross.Plugins.PlatformTask.iOS
{
    public class Plugin : IMvxPlugin
	{
		public void Load()
		{
            Mvx.ConstructAndRegisterSingleton<IMvxPlatformTaskFactory, MvxPlatformTaskFactory>();
		}
	}
}

