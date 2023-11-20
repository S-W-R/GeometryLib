using GeometryLib.Interfaces;

namespace GeometryLib.Figures;

public class Triangle : IPlaneFigure
{
    public Triangle(double a, double b, double c)
    {
        if (a < 0) throw new ArgumentOutOfRangeException(nameof(a));
        if (b < 0) throw new ArgumentOutOfRangeException(nameof(b));
        if (c < 0) throw new ArgumentOutOfRangeException(nameof(c));

        var orderedSides = new double[] { a, b, c }.OrderByDescending(x => x).ToArray();
        if (orderedSides[0] > orderedSides[1] + orderedSides[2])
            throw new ArgumentException("Incorrect triangle");

        var perimeter = orderedSides.Sum();
        var halfPerimeter = perimeter / 2;
        Area = Math.Sqrt(orderedSides.Append(0).Aggregate(1.0, (acc, v) => acc * (halfPerimeter - v)));

        A = orderedSides[2];
        B = orderedSides[1];
        C = orderedSides[0];
    }

    public double A { get; }
    public double B { get; }
    public double C { get; }
    public double Area { get; }
}