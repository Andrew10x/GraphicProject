using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphicsTests.ObjectsTests.ShapesTests.PlaneTests;

[TestFixture]
public class PlaneMinDistanceTests
{
    public static IEnumerable<TestCaseData> MinDistanceData
    {
        get
        {
            yield return new TestCaseData(new Plane(new CVector(1, 0, 0),  new CPoint(1, 2, 3)),
                new CPoint(10, 12, 15), 9);
            
            yield return new TestCaseData(new Plane(new CVector(1, 0, 0),  new CPoint(1, 2, 3)),
                new CPoint(5, 4, 7), 4);

        }
    }

    [Test]
    [TestCaseSource(nameof(MinDistanceData))]
    public void PlaneMinDistance(Plane plane, CPoint p, double d)
    {
        var res = plane.MinDistance(p);
        Assert.That(res, Is.EqualTo(d).Within(0.0001));
    }

}