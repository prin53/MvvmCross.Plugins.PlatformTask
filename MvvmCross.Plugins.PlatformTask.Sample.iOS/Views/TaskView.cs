using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Plugins.PlatformTask.Sample.Core.ViewModels;
using MvvmCross.Plugins.PlatformTask.Sample.iOS.Converters;
using UIKit;

namespace MvvmCross.Plugins.PlatformTask.Sample.iOS.Views
{
    public class TaskView : MvxViewController
    {
        protected UILabel BackgroundTaskLengthLabel
        {
            get;
            private set;
        }

        protected UITextField BackgroundTaskLengthText
        {
            get;
            private set;
        }

        protected UIButton BeginBackgroundTaskButton
        {
            get;
            private set;
        }

        protected UIButton CancelBackgroundTaskButton
        {
            get;
            private set;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitView();

            InitBindings();
        }

        private void InitView()
        {
            View.BackgroundColor = UIColor.White;

            NavigationController.NavigationBar.Translucent = false;

            Title = "Platform task sample";

            BackgroundTaskLengthLabel = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Text = "Platform task length in seconds:"
            };

            BackgroundTaskLengthText = new UITextField
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                KeyboardType = UIKeyboardType.NumberPad,
                BorderStyle = UITextBorderStyle.RoundedRect
            };

            BeginBackgroundTaskButton = UIButton.FromType(UIButtonType.System);
            BeginBackgroundTaskButton.TranslatesAutoresizingMaskIntoConstraints = false;
            BeginBackgroundTaskButton.SetTitle("Begin Platform task", UIControlState.Normal);

            CancelBackgroundTaskButton = UIButton.FromType(UIButtonType.System);
            CancelBackgroundTaskButton.TranslatesAutoresizingMaskIntoConstraints = false;
            CancelBackgroundTaskButton.SetTitle("Cancel Platform task", UIControlState.Normal);

            View.AddSubviews(BackgroundTaskLengthLabel, BackgroundTaskLengthText, BeginBackgroundTaskButton, CancelBackgroundTaskButton);

            NSLayoutConstraint.ActivateConstraints(new[]
            {
                BackgroundTaskLengthLabel.TopAnchor.ConstraintEqualTo(View.TopAnchor, 16),
                BackgroundTaskLengthLabel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16),
                BackgroundTaskLengthLabel.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16),
                BackgroundTaskLengthText.TopAnchor.ConstraintEqualTo(BackgroundTaskLengthLabel.BottomAnchor, 8),
                BackgroundTaskLengthText.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16),
                BackgroundTaskLengthText.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16),
                BeginBackgroundTaskButton.TopAnchor.ConstraintEqualTo(BackgroundTaskLengthText.BottomAnchor, 16),
                BeginBackgroundTaskButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16),
                BeginBackgroundTaskButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16),
                CancelBackgroundTaskButton.TopAnchor.ConstraintEqualTo(BeginBackgroundTaskButton.BottomAnchor, 16),
                CancelBackgroundTaskButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16),
                CancelBackgroundTaskButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16)
            });
        }

        private void InitBindings()
        {
            var set = this.CreateBindingSet<TaskView, TaskViewModel>();
            set.Bind(BeginBackgroundTaskButton).To(vm => vm.BeginTaskCommand);
            set.Bind(BeginBackgroundTaskButton).For(v => v.Enabled).To(vm => vm.TaskIsRunning).WithConversion(new InvertedBoolConverter());
            set.Bind(CancelBackgroundTaskButton).To(vm => vm.CancelTaskCommand);
            set.Bind(CancelBackgroundTaskButton).For(v => v.Enabled).To(vm => vm.TaskIsRunning);
            set.Bind(BackgroundTaskLengthText).To(vm => vm.TaskLength).WithConversion(new IntStringConverter());
            set.Apply();
        }
    }
}

