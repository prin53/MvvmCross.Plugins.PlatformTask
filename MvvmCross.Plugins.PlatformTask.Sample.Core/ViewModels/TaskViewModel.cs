using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Threading;

namespace MvvmCross.Plugins.PlatformTask.Sample.Core.ViewModels
{
    public class TaskViewModel : MvxViewModel
    {
        protected string Tag => typeof(TaskViewModel).Name;

        protected IMvxPlatformTaskFactory Factory
        {
            get;
            private set;
        }

        protected CancellationTokenSource CancellationTokenSource
        {
            get;
            private set;
        }

        public TaskViewModel(IMvxPlatformTaskFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            Factory = factory;
        }

        public void Init()
        {
            TaskLength = 200;
        }

        #region Task Length

        private int _taskLength;

        public int TaskLength
        {
            get
            {
                return _taskLength;
            }
            set
            {
                _taskLength = value;
                RaisePropertyChanged(() => TaskLength);
            }
        }

        #endregion

        #region Task Is Running

        private bool _taskIsRunning;

        public bool TaskIsRunning
        {
            get
            {
                return _taskIsRunning;
            }
            set
            {
                _taskIsRunning = value;
                RaisePropertyChanged(() => TaskIsRunning);
            }
        }

        #endregion

        #region Begin Task Command

        MvxCommand _beginTaskCommand;

        public ICommand BeginTaskCommand
        {
            get
            {
                return _beginTaskCommand = _beginTaskCommand ?? new MvxCommand(DoBeginTaskCommand);
            }
        }

        private async void DoBeginTaskCommand()
        {
            Mvx.TaggedTrace(Tag, "Task started");

            TaskIsRunning = true;

            var platformTask = Factory.Create();

            try
            {
                CancellationTokenSource = platformTask.Begin();

                var token = CancellationTokenSource.Token;

                var result = await Task.Run(() =>
                {
                    var taskLength = TaskLength;

                    for (var seconds = 1; seconds <= taskLength; seconds++)
                    {
                        token.ThrowIfCancellationRequested();

                        Task.Delay(TimeSpan.FromSeconds(1)).Wait();

                        Mvx.TaggedTrace(Tag, $"Task runs : {seconds}");
                    }

                    return taskLength;
                });

                platformTask.End();

                Mvx.TaggedTrace(Tag, $"Task finished. Result = {result}");
            }
            catch (OperationCanceledException)
            {
                Mvx.TaggedTrace(Tag, $"Task was cancelled.");
            }
            finally
            {
                TaskIsRunning = false;
            }
        }

        #endregion

        #region Cancel Task Command

        MvxCommand _cancelTaskCommand;

        public ICommand CancelTaskCommand
        {
            get
            {
                return _cancelTaskCommand = _cancelTaskCommand ?? new MvxCommand(DoCancelTaskCommand);
            }
        }

        private void DoCancelTaskCommand()
        {
            if (CancellationTokenSource == null)
            {
                return;
            }

            Mvx.TaggedTrace(Tag, "Task will be canceled");

            CancellationTokenSource.Cancel();

            TaskIsRunning = false;
        }

        #endregion
    }
}

