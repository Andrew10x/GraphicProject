using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphicsTests.ObjectsTests.ShapesTests.PlaneTests;

[TestFixture]
public class PlaneIntersectionTests
{
  /*  public static IEnumerable<TestCaseData> HasIntersectionData
    {
        get
        {
            yield return new TestCaseData(new CPoint(-1, 0, 0), new CVector(1, 0, 0),
                new Plane(new CVector(1, 0, 0), new CPoint(0, 0, 0)),
            new CPoint(-5, 0, 0));
            
            yield return new TestCaseData(new CPoint(-1, 0, 0), new CVector(1, 1, 0).MakeUnitVector(),
                new Plane(new CVector(1, 0, 0), new CPoint(0, 0, 0)),
                new CPoint(-5, -4, 0));
        }
    }

    [Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void PlaneHasIntersection(CPoint p, CVector v, Plane plane, CPoint intersection)
    {
        var res = plane.HasIntersection(p, v);
        Assert.That(res, Is.Not.Null);
        Assert.That(res!.IsEqual(intersection), Is.True);
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
    }*/

}