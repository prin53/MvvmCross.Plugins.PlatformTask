[![NuGet version](https://badge.fury.io/nu/Prin53.MvvmCross.Plugins.PlatformTask.svg)](https://badge.fury.io/nu/Prin53.MvvmCross.Plugins.PlatformTask)
[![GitHub version](https://badge.fury.io/gh/Prin53%2FMvvmCross.Plugins.PlatformTask.svg)](https://badge.fury.io/gh/Prin53%2FMvvmCross.Plugins.PlatformTask)
[![Build Status](https://www.bitrise.io/app/5bcfc7d7e2cd5440.svg?token=TsUyjdyXVWeO92MTDzWd6g&branch=master)](https://www.bitrise.io/app/5bcfc7d7e2cd5440)

# Platform Task
The `Platform Task` plugin is a high-level wrapper for iOS background task.

Plugin provides `IMvxPlatformTask` with `Begin` and `End` methods to start and finish backgound task. 

The `Begin` method returns `CancelationTokenSource`, so user can manage the task. User have to listen cancelation token and finish background work when cancelation requested. Otherwise task will be freezed until application will come to the foreground.
#### Note
Note, that background task can be set as expired by OS after some time of background work (180 seconds). Then plugin will call `CancellationTokenSource.Cancel`.
```
var factory = Mvx.Resolve<IMvxPlatformTaskFactory>();
var platformTask = factory.Create();

var source = platformTask.Begin();
/* Some work */
platformTask.End();
```
See sample project to more information.
## iOS
Plugin uses `UIApplication.SharedApplication.BeginBackgroundTask` and `UIApplication.SharedApplication.EndBackgroundTask` on iOS platfrom.

## Android
No actual work. Just to complete the plugin.

## Windows
Not supported.
