using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvmCross.Plugins.PlatformTask
{
	public class PluginLoader : IMvxPluginLoader
	{
		public static readonly PluginLoader Instance = new PluginLoader();

		public void EnsureLoaded()
		{
			Mvx.Resolve<IMvxPluginManager>().EnsurePlatformAdaptionLoaded<PluginLoader>();
		}
	}
}

