using Dooz.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Dooz.converters
{
    class TimestampConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var Timestamp = (long)value;
            if (Timestamp.ToString().Length <= 10)
            {
                Timestamp *= 1000;
            }
            return DateTimeHelper.FromUnix(Timestamp).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
