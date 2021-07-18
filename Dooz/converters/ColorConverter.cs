using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Dooz.converters
{
    class ColorConverter : IValueConverter
    {
        private Random rnd = new Random();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            int randomInt = rnd.Next(0,10);
            switch (randomInt){
                case 0: return "#6a1b9a";
                case 1: return "#4527a0";
                case 2: return "#ad1457";
                case 3: return "#2e7d32";
                case 4: return "#f9a825";
                case 5: return "#d84315";
                case 6: return "#ffd600";
                case 7: return "#0091ea";
                case 8: return "#bb002f";
                case 9: return "#6a1b9a";
                case 10: return "#6a1b9a";
                default:
                    return "#6a1b9a";
            }
          
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
