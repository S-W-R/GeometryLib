using FluentAssertions;
using GeometryLib.Extensions;
using GeometryLib.Figures;
using GeometryLib.Test.Helpers;

namespace GeometryLib.Test.UnitTests;

public class TriangleTests
{
    [TestCase(-1, 0, 1)]
    [TestCase(2, double.MinValue, 1)]
    [TestCase(-1, -1, -1)]
    [TestCase(double.NegativeInfinity, double.PositiveInfinity, double.PositiveInfinity)]
    public void TriangleShouldThrowErrorWhenNegativeLegs(double a, double b, double c)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
    }

    [TestCase(0, 0, 1)]
    [TestCase(0, 8, 9)]
    [TestCase(1, 1, 3)]
    [TestCase(2, 2, 999999)]
    public void TriangleShouldThrowErrorWhenTriangleWithIncorrectSizes(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [TestCase(0, 0, 0, 0)]
    [TestCase(0, 1000000, 1000000, 0)]
    [TestCase(3, 4, 5, 6)]
    [TestCase(13, 15, 21, 96.789397)]
    public void TriangleShouldCorrectCalculateArea(double a, double b, double c, double expected)
    {
        var precision = 0.05;
        var circle = new Triangle(a, b, c);
        TestHelper.IsDoubleEquivalent(circle.Area, expected, precision).Should().BeTrue();
    }


    [TestCase(3, 4, 5)]
    [TestCase(48, 55, 73)]
    [TestCase(115, 252, 277)]
    public void TriangleShouldCorrectBeRightAngled(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        triangle.IsRightAngled(precision: 0.05).Should().BeTrue();
    }

    [TestCase(555, 555, 555)]
    [TestCase(1, 1, 2)]
    [TestCase(12, 255, 257)]
    public void TriangleShouldCorrectBeNotRightAngled(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        triangle.IsRightAngled(precision: 0.05).Should().BeFalse();
    }

    [TestCase(1, 2, 3)]
    [TestCase(9, 8, 7)]
    public void LegsShouldBeCorrectOrdered(double a, double b, double c)
    {
        var sides = new List<double>() { a, b, c };
        var max = sides.Max();
        var min = sides.Min();
        var middle = sides.First(x => x != max && x != min);
        var triangle = new Triangle(a, b, c);
        triangle.A.Should().Be(min);
        triangle.B.Should().Be(middle);
        triangle.C.Should().Be(max);
    }
}