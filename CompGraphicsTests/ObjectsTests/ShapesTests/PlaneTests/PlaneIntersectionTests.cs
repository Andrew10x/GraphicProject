using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;

namespace CompGraphicsTests.ObjectsTests.ShapesTests.PlaneTests;

[TestFixture]
public class PlaneIntersectionTests
{
    public static IEnumerable<TestCaseData> HasIntersectionData
    {
        get
        {
            yield return new TestCaseData(new CPoint(-1, 0, 0), new CVector(1, 0, 0),
                new Plane(new CVector(1, 0, 0), new CPoint(0, 0, 0)),
                new IntersectionResult(new CPoint(0, 0, 0), new CVector(-1, 0, 0), 1));
            
            yield return new TestCaseData(new CPoint(-1, 0, 0), new CVector(1, 1, 0).MakeUnitVector(),
                new Plane(new CVector(1, 0, 0), new CPoint(0, 0, 0)),
                new IntersectionResult(new CPoint(0, 1, 0), new CVector(-1, 0, 0), 1.41421356));
        }
    }

    [Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void PlaneHasIntersection(CPoint p, CVector v, Plane plane, IntersectionResult interRes)
    {
        var res = plane.HasIntersection(p, v);
        Assert.That(res, Is.Not.Null);
        Assert.That(res!.IsEqual(interRes), Is.True);
    }
    
    public static IEnumerable<TestCaseData> HasNoIntersectionData
    {
        get
        {
            yield return new TestCaseData(new CPoint(-1, 2, 4), new CVector(0, 1, 0).MakeUnitVector(),
                new Plane(new CVector(1, 0, 0), new CPoint(0, 0, 0)));
            
            yield return new TestCaseData(new CPoint(-1, 2, 4), new CVector(0, 5, 7).MakeUnitVector(),
                new Plane(new CVector(1, 0, 0), new CPoint(-10, -10, -10)));
        }
    }

    [Test]
    [TestCaseSource(nameof(HasNoIntersectionData))]
    public void PlaneHasNoIntersection(CPoint p, CVector v, Plane plane)
    {
        var res = plane.HasIntersection(p, v);
        Assert.That(res, Is.Null);
    }

}