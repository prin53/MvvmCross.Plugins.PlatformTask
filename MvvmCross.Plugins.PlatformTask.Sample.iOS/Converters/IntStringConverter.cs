using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace MvvmCross.Plugins.PlatformTask.Sample.iOS.Converters
{
    public class IntStringConverter : MvxValueConverter<int, string>
    {
        protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        protected override int ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = default(int);

            int.TryParse(value, out result);

            return result;
        }
    }
}

