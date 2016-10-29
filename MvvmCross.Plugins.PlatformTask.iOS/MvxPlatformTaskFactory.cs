namespace MvvmCross.Plugins.PlatformTask.iOS
{
    public class MvxPlatformTaskFactory : IMvxPlatformTaskFactory
    {
        public IMvxPlatformTask Create()
        {
            return new MvxPlatformTask();
        }
    }
}

