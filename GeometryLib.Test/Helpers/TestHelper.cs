namespace GeometryLib.Test.Helpers;

public static class TestHelper
{
    public static bool IsDoubleEquivalent(double first, double second, double precision = 0.0005) =>
        Math.Abs(first - second) < precision;
}