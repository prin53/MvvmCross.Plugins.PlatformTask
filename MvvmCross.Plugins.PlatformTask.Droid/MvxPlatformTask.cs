using System.Threading;

namespace MvvmCross.Plugins.PlatformTask.Droid
{
    public class MvxPlatformTask : IMvxPlatformTask
    {
        public CancellationTokenSource Begin()
        {
            return new CancellationTokenSource();
        }

        public void End()
        {
            /* Nothing to do */
        }
    }
}

