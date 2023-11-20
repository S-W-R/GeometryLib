using GeometryLib.Interfaces;

namespace GeometryLib.Figures;

public class Circle : IPlaneFigure
{
    public double Radius { get; }
    public double Area { get; }

    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException(nameof(radius));
        Radius = radius;
        Area = Math.PI * Radius * Radius;
    }
}