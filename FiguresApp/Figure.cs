using System.Windows;
using System.Windows.Media;

namespace FiguresApp;

public class Figure
{
    public Geometry Data { get; }
    public Brush Color { get; }
    public FigureTypes Type { get; }

    public Figure(int top, int left, int width, int height, Brush color, FigureTypes type)
    {
        Color = color;
        Type = type;
        Data = type switch
        {
            FigureTypes.Square => new RectangleGeometry { Rect = new Rect(left, top, width, width) },
            FigureTypes.Rectangle => new RectangleGeometry { Rect = new Rect(left, top, width, height) },
            FigureTypes.Ellipse => new EllipseGeometry(new Point(left + width, top + height), GetValue(width),
                GetValue(height)),
            FigureTypes.Round => new EllipseGeometry(new Point(left + width, top + width), GetValue(width),
                GetValue(width)),
            _ => Geometry.Empty
        };
    }

    private static double GetValue(int value)=>(double)value / 2;

    public bool IsValid(int canvasHeight, int canvasWidth) => !(Data.Bounds.Left < 0) && !(Data.Bounds.Right > canvasWidth) && !(Data.Bounds.Top<0) && !(Data.Bounds.Bottom>canvasHeight);

    
}