using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;

namespace CompGraphicsTests.ObjectsTests.ShapesTests.SphereTests;

[TestFixture]
public class SphereIntersectionTests
{
    public static IEnumerable<TestCaseData> HasIntersectionData
    {
        get
        {

            yield return new TestCaseData(new CPoint(-1, -1, -1),
                new CVector(1, 1, 0).MakeUnitVector(),
                new Sphere(1, new CPoint(0, 0, 0)),
                new IntersectionResult(new CPoint(0, 0, -1), new CVector(0, 0, -1), 1.41421356));
            
            yield return new TestCaseData(new CPoint(0, 0, 0),
                new CVector(0, 0, -1).MakeUnitVector(),
                new Sphere(1, new CPoint(0, 0, -5)),
                new IntersectionResult(new CPoint(0, 0, -4), new CVector(0, 0, 1), 4));

        }
    }

   [Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void SphereHasIntersection(CPoint p, CVector v, Sphere sph, IntersectionResult interRes)
    {
        var res = sph.HasIntersection(p, v);
        Assert.That(res, Is.Not.Null);
        Assert.That(res!.IsEqual(interRes), Is.True);
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