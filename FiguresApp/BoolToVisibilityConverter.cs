using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FiguresApp;

public class BoolToVisibilityConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is FigureTypes type)
            return type is FigureTypes.Rectangle or FigureTypes.Ellipse ? Visibility.Visible : Visibility.Collapsed;
        return 0d;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        
        return 0d;
    }
}