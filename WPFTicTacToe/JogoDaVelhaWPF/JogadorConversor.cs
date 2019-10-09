using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace JogoDaVelhaWPF
{
    public class JogadorConversor : IValueConverter
    {     
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                int imageIndex;
                if (int.TryParse(value.ToString(), out imageIndex))
                {
                    switch (imageIndex)
                    {
                        case 1:
                            return "Figuras\\x.png";
                        case 2:
                            return "Figuras\\o.png";
                }
                }

                return null;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    }
}
