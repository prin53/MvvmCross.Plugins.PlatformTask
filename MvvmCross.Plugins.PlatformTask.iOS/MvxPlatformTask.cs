using System;
using System.Threading;
using Foundation;
using MvvmCross.Platform;
using UIKit;

namespace MvvmCross.Plugins.PlatformTask.iOS
{
    public class MvxPlatformTask : IMvxPlatformTask
    {
        protected string Tag => typeof(MvxPlatformTask).Name;

        protected TimeSpan ForceEndingTime => TimeSpan.FromSeconds(2);

        protected NSTimer Timer
        {
            get;
            private set;
        }

        protected nint Id
        {
            get;
            private set;
        }

        public CancellationTokenSource Begin()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            Id = UIApplication.SharedApplication.BeginBackgroundTask(() => OnBackgroundTimeExpired(cancellationTokenSource));

            cancellationTokenSource.Token.Register(() =>
            {
                End();
            });

            return cancellationTokenSource;
        }

        public void End()
        {
            if (Id == default(nint))
            {
                return;
            }

            UIApplication.SharedApplication.EndBackgroundTask(Id);

            Id = default(nint);
        }

        private void OnBackgroundTimeExpired(CancellationTokenSource cancellationTokenSource)
        {
            Mvx.TaggedWarning(Tag, "Background task expired");

            try
            {
                cancellationTokenSource.Cancel();
            }
            catch (ObjectDisposedException)
            {
            }

            // Task will end after some time to prevent app terminating by OS. 
            Timer = NSTimer.CreateScheduledTimer(ForceEndingTime, timer => End());
        }
    }
}

