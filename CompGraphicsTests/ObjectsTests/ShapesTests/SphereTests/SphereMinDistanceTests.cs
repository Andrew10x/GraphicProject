using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphicsTests.ObjectsTests.ShapesTests.SphereTests;

[TestFixture]
public class SphereMinDistanceTests
{
    public static IEnumerable<TestCaseData> MinDistanceData
    {
        get
        {
            yield return new TestCaseData(new Sphere(1, new CPoint(1, 2, 3)), new CPoint(2, 2, 3), 0);
            yield return new TestCaseData(new Sphere(1, new CPoint(1, 2, 3)), new CPoint(3, 3, 4), 1.4495);
            yield return new TestCaseData(new Sphere(1, new CPoint(1, 2, 3)), new CPoint(1, 2, 3), 1);
            
        }
    }

    [Test]
    [TestCaseSource(nameof(MinDistanceData))]
    public void SphereMinDistance(Sphere sph, CPoint p, double d)
    {
        var res = sph.MinDistance(p);
        Assert.That(res, Is.EqualTo(d).Within(0.0001));
    }

}