using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace FiguresApp;

public class Figure:INotifyPropertyChanged
{
    public Geometry Data { get; }
    public Brush Color { get; }
    public FigureTypes Type { get; }

    public Figure(int top, int left, int width, int height, Brush color, FigureTypes type)
    {
        Color = color;
        Type = type;
        switch (type)
        {
            case FigureTypes.Square:
                Data = new RectangleGeometry
                {
                    Rect = new Rect(left, top, width, width)
                };
                break;
            case FigureTypes.Rectangle:
                Data = new RectangleGeometry
                {
                    Rect = new Rect(left, top, width, height)
                };
                break;
            case FigureTypes.Ellipse:
                Data = new EllipseGeometry(new Point(GetValue(left, width), GetValue(top, height)), GetValue(0,width),
                    GetValue(0, height));
                break;
            case FigureTypes.Round:
                Data = new EllipseGeometry(new Point(GetValue(left, width), GetValue(top, height)), GetValue(0, width),
                    GetValue(0, width));
                break;
            default:
                Data = Geometry.Empty;
                break;
        }
    }

    private static double GetValue(int value1, int value2)=>(double)(value1 + value2) / 2;

    public bool IsValid(int canvasHeight, int canvasWidth) => !(Data.Bounds.Left < 0) && !(Data.Bounds.Right > canvasWidth) && !(Data.Bounds.Top<0) && !(Data.Bounds.Bottom>canvasHeight);


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}