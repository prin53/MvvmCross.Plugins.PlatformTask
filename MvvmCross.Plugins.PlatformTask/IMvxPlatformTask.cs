using System.Threading;

namespace MvvmCross.Plugins.PlatformTask
{
    public interface IMvxPlatformTask
    {
        CancellationTokenSource Begin();

        void End();
    }
}

