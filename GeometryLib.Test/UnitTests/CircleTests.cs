using FluentAssertions;
using GeometryLib.Figures;
using GeometryLib.Test.Helpers;

namespace GeometryLib.Test.UnitTests;

public class CircleTests
{
    [TestCase(-1)]
    [TestCase(-0.00000001)]
    [TestCase(-int.MaxValue)]
    [TestCase(double.NegativeInfinity)]
    public void CircleShouldThrowErrorWhenIncorrectRadius(double radius)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }

    [TestCase(0, 0)]
    [TestCase(1, Math.PI)]
    [TestCase(2, 12.566370614)]
    public void CircleShouldCorrectCalcArea(double radius, double expected)
    {
        var precision = 0.05;
        var circle = new Circle(radius);
        TestHelper.IsDoubleEquivalent(circle.Area, expected, precision).Should().BeTrue();
    }
}