using GeometryLib.Figures;

namespace GeometryLib.Extensions;

public static class TriangleExtensions
{
    public static bool IsRightAngled(this Triangle triangle, double precision = 1e-6)
    {
        var c = triangle.C * triangle.C;
        var b = triangle.B * triangle.B;
        var a = triangle.A * triangle.A;
        var delta = Math.Abs(c - (b + a));
        return delta < precision;
    }
}