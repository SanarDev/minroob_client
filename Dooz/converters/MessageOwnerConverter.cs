using Dooz.socket.models;
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
    class MessageOwnerConverter : IValueConverter
    {
        private LoggedUser LoggedUser = FileUtility.GetLoginData();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((long)value == LoggedUser.Id)
            {
                return "You :";
            }
            else
            {
                return "Player :";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
