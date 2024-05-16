using CompGraphics.Objects.MathObjects;
using CompGraphics.Results;

namespace CompGraphicsTests.ObjectsTests.ShapesTests.TriangleTests;

public class TriangleIntersectionTests
{
    public static IEnumerable<TestCaseData> HasIntersectionData
    {
        get
        {
            yield return new TestCaseData(new CPoint(0, 0, 0),
                new CVector(0, 0, -1),
                new Triangle(new CPoint(-5, 5, -10), new CPoint(5, 5, -10), new CPoint(0, -2, -10),
                    new CVector(0, 0, -1).MakeUnitVector(), new CVector(0, 0, -1).MakeUnitVector(),
                    new CVector(0, 0, -1)),
                new IntersectionResult(new CPoint(0, 0, -10), new CVector(0, 0, -1), 10));
            
            yield return new TestCaseData(new CPoint(0, 0, 0),
                new CVector(0, 0, -1),
                new Triangle(new CPoint(-5, 5, -8), new CPoint(5, 5, -10), new CPoint(0, -2, -8),
                    new CVector(0, 0, 1).MakeUnitVector(), new CVector(0, 0, 1).MakeUnitVector(),
                    new CVector(0, 0, 1)),
                new IntersectionResult(new CPoint(0, 0, -8.285714286), new CVector(0, 0, 1), 8.285714286));
            
        }
    }
    
    [Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void TriangleHasIntersection(CPoint p, CVector v, Triangle triangle, IntersectionResult interRes)
    {
        var res = triangle.HasIntersection(p, v);
        Assert.That(res, Is.Not.Null);
        Assert.That(res!.IsEqual(interRes), Is.True);
    }
    
    
    public static IEnumerable<TestCaseData> HasNoIntersectionData
    {
        get
        {
            yield return new TestCaseData(new CPoint(0, 0, 0),
                new CVector(0, 0, 1),
                new Triangle(new CPoint(-5, 5, -10), new CPoint(5, 5, -10), new CPoint(0, -2, -10),
                    new CVector(0, 0, -1).MakeUnitVector(), new CVector(0, 0, -1).MakeUnitVector(),
                    new CVector(0, 0, -1)));

                yield return new TestCaseData(new CPoint(0, 0, 0),
                new CVector(0, -1, -1).MakeUnitVector(),
                new Triangle(new CPoint(-5, 5, -8), new CPoint(5, 5, -10), new CPoint(0, -2, -8),
                    new CVector(0, 0, 1).MakeUnitVector(), new CVector(0, 0, 1).MakeUnitVector(),
                    new CVector(0, 0, 1)));
            
        }
    }
    
    [Test]
    [TestCaseSource(nameof(HasNoIntersectionData))]
    public void TriangleHasNoIntersection(CPoint p, CVector v, Triangle triangle)
    {
        var res = triangle.HasIntersection(p, v);
        Assert.That(res, Is.Null);
    }

}