using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace MvvmCross.Plugins.PlatformTask.Sample.iOS.Converters
{
    public class InvertedBoolConverter : MvxValueConverter<bool, bool>
    {
        protected override bool Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }

        protected override bool ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }
    }
}

