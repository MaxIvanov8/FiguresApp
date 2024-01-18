using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FiguresApp;

public class ColorPicker : Control
{
    static ColorPicker()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker),
            new FrameworkPropertyMetadata(typeof(ColorPicker)));
    }

    internal int UserCustomValue
    {
        get => (int)GetValue(UserCustomValueProperty);
        set => SetValue(UserCustomValueProperty, value);
    }

    internal static readonly DependencyProperty UserCustomValueProperty =
        DependencyProperty.Register(nameof(UserCustomValue), typeof(int), typeof(ColorPicker),
            new FrameworkPropertyMetadata(UserCustomValue_Changed));

    public Brush SelectedColor
    {
        get => (Brush)GetValue(SelectedColorProperty);
        set => SetValue(SelectedColorProperty, value);
    }

    public static readonly DependencyProperty SelectedColorProperty =
        DependencyProperty.Register(nameof(SelectedColor), typeof(Brush), typeof(ColorPicker),
            new FrameworkPropertyMetadata(GetDefaultColors().FirstOrDefault()));

    internal Brush DefaultColor
    {
        get => (Brush)GetValue(DefaultColorProperty);
        set => SetValue(DefaultColorProperty, value);
    }

    internal static readonly DependencyProperty DefaultColorProperty =
        DependencyProperty.Register(nameof(DefaultColor), typeof(Brush), typeof(ColorPicker),
            new FrameworkPropertyMetadata(DefaultColor_Changed));

    internal ObservableCollection<Brush> DefaultColors => (ObservableCollection<Brush>)GetValue(DefaultColorsProperty);

    internal static readonly DependencyProperty DefaultColorsProperty =
        DependencyProperty.Register(nameof(DefaultColors), typeof(ObservableCollection<Brush>), typeof(ColorPicker),
            new PropertyMetadata(GetDefaultColors()));

    private static void DefaultColor_Changed(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var cp = (ColorPicker)obj;
        var color = ((SolidColorBrush)e.NewValue).Color;

        cp.SelectedColor = new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));
    }

    private static void UserCustomValue_Changed(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var cp = (ColorPicker)obj;
        var colors = GetUserCustomColors();
        var (item1, item2, item3) = colors[Convert.ToInt32(e.NewValue)];

        cp.SelectedColor =
            new SolidColorBrush(Color.FromRgb(Convert.ToByte(item1), Convert.ToByte(item2), Convert.ToByte(item3)));
    }

    private static List<Tuple<int, int, int>> GetUserCustomColors()
    {
        var list = new List<Tuple<int, int, int>>();

        //#ff0000 -> #ffff00
        for (var i = 0; i <= 255; i++)
            list.Add(Tuple.Create(255, i, 0));

        //#ffff00 -> #00ff00
        for (var i = 255; i >= 0; i--)
            list.Add(Tuple.Create(i, 255, 0));

        //#00ff00 -> #00ffff
        for (var i = 0; i <= 255; i++)
            list.Add(Tuple.Create(0, 255, i));

        //#00ffff -> #0000ff
        for (var i = 255; i >= 0; i--)
            list.Add(Tuple.Create(0, i, 255));

        //#0000ff -> #ff00ff
        for (var i = 0; i <= 255; i++)
            list.Add(Tuple.Create(i, 0, 255));

        //#ff00ff -> #ff0000
        for (var i = 255; i >= 0; i--)
            list.Add(Tuple.Create(255, 0, i));

        return list;
    }

    private static ObservableCollection<Brush> GetDefaultColors() =>
    [
	    Brushes.Black,
	    Brushes.White,
	    Brushes.Red,
	    Brushes.Lime,
	    Brushes.Blue,
	    Brushes.Yellow,

	    Brushes.Teal,
	    Brushes.Purple,


	    new SolidColorBrush(Color.FromRgb(38, 38, 38)),
	    Brushes.Gray,
	    Brushes.Brown,
	    new SolidColorBrush(Color.FromRgb(55, 86, 35)),
	    Brushes.Navy,
	    new SolidColorBrush(Color.FromRgb(255, 217, 102)),

	    Brushes.Olive,
	    new SolidColorBrush(Color.FromRgb(244, 176, 132)),


	    new SolidColorBrush(Color.FromRgb(34, 43, 53)),
	    Brushes.Silver,
	    new SolidColorBrush(Color.FromRgb(237, 125, 49)),
	    new SolidColorBrush(Color.FromRgb(112, 173, 71)),
	    new SolidColorBrush(Color.FromRgb(48, 84, 150)),
	    new SolidColorBrush(Color.FromRgb(255, 192, 0)),

	    new SolidColorBrush(Color.FromRgb(91, 155, 213)),
	    new SolidColorBrush(Color.FromRgb(248, 203, 173)),


	    new SolidColorBrush(Color.FromRgb(58, 56, 56)),
	    new SolidColorBrush(Color.FromRgb(165, 165, 165)),
	    new SolidColorBrush(Color.FromRgb(198, 89, 17)),
	    Brushes.Green,
	    new SolidColorBrush(Color.FromRgb(68, 114, 196)),
	    new SolidColorBrush(Color.FromRgb(191, 143, 0)),

	    new SolidColorBrush(Color.FromRgb(142, 169, 219)),
	    new SolidColorBrush(Color.FromRgb(255, 230, 153)),


	    new SolidColorBrush(Color.FromRgb(68, 84, 106)),
	    new SolidColorBrush(Color.FromRgb(155, 194, 230)),
	    new SolidColorBrush(Color.FromRgb(131, 60, 12)),
	    new SolidColorBrush(Color.FromRgb(84, 130, 53)),
	    new SolidColorBrush(Color.FromRgb(32, 55, 100)),
	    new SolidColorBrush(Color.FromRgb(255, 153, 0)),

	    new SolidColorBrush(Color.FromRgb(169, 208, 142)),
	    new SolidColorBrush(Color.FromRgb(198, 224, 180)),
	    new SolidColorBrush(Color.FromRgb(198, 224, 180))
    ];
}