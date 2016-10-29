namespace MvvmCross.Plugins.PlatformTask.Droid
{
    public class MvxPlatformTaskFactory : IMvxPlatformTaskFactory
    {
        public IMvxPlatformTask Create()
        {
            return new MvxPlatformTask();
        }
    }
}

