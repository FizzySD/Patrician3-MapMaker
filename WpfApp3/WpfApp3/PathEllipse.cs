using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

public class PathEllipse
{
    private Ellipse ellipse;

    public Point Coordinates { get; private set; }

    public PathEllipse(double width, double height, Brush fill, double x, double y)
    {
        ellipse = new Ellipse
        {
            Width = width,
            Height = height,
            Fill = fill
        };
        SetCoordinates(new Point(x,y));
    }

    public void SetCoordinates(Point coordinates)
    {
        Coordinates = coordinates;
        UpdateEllipsePosition();
    }

    public Ellipse GetEllipse()
    {
        return ellipse;
    }

    private void UpdateEllipsePosition()
    {
        Canvas.SetLeft(ellipse, Coordinates.X - ellipse.Width / 2);
        Canvas.SetTop(ellipse, Coordinates.Y - ellipse.Height / 2);
    }
}
