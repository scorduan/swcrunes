using System;
using System.Globalization;


namespace SWCRunes.Components
{
    public class Int3ToPercConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value / 10f).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            return (int)(float.Parse((string)value) * 10f);
        }
    }
}

