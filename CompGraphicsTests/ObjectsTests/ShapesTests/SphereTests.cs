using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphicsTests.ObjectsTests.ShapesTests;

[TestFixture]
public class SphereTests
{
    public static IEnumerable<TestCaseData> HasIntersectionData
    {
        get
        {
            yield return new TestCaseData(new CPoint(2, 3, 5),
                new CVector(0, 0, 1),
                new Sphere(2, new CPoint(2, 4, 10)),
                new CPoint(2, 3, 8.2679));
            
            yield return new TestCaseData(new CPoint(-1, -1, -1),
                new CVector(1, 1, 0).MakeUnitVector(),
                new Sphere(1, new CPoint(0, 0, 0)),
                new CPoint(0, 0, -1));
            
            yield return new TestCaseData(new CPoint(4, 1, 4),
                new CVector(0, 1, 1).MakeUnitVector(),
                new Sphere(1, new CPoint(4, 2, 5)),
                new CPoint(4, 1.29, 4.29));
        }
    }

    [Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void SphereHasIntersection(CPoint p, CVector v, Sphere sph, CPoint intersection)
    {
        var res = sph.HasIntersection(p, v);
        Assert.That(res, Is.Not.Null);
        Assert.That(res!.IsEqual(intersection), Is.True);
    }
    
    public static IEnumerable<TestCaseData> HasNoIntersectionData
    {
        get
        {
            yield return new TestCaseData(new CPoint(2, 3, 5),
                new CVector(1, 0, 1).MakeUnitVector(),
                new Sphere(1, new CPoint(10, 10, 10)));
            
            yield return new TestCaseData(new CPoint(1, 2, 4),
                new CVector(0, 0, 1),
                new Sphere(1, new CPoint(2, 5, 2)));
            
            yield return new TestCaseData(new CPoint(4, 1, 7),
                new CVector(0, 1, 1).MakeUnitVector(),
                new Sphere(1, new CPoint(3, 6, 2)));
        }
        
    }
    
    [Test]
    [TestCaseSource(nameof(HasNoIntersectionData))]
    public void SphereHasNoIntersection(CPoint p, CVector v, Sphere sph)
    {
        var res = sph.HasIntersection(p, v);
        Assert.That(res, Is.Null);
    }
    
    
}