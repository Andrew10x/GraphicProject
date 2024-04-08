using CompGraphics.Objects.MathObjects;

namespace CompGraphicsTests.MathObjectsTests;


[TestFixture]
public class CPointTests
{
    public static IEnumerable<TestCaseData> AddPointAndVectorData
    {
        get
        {
            yield return new TestCaseData(new CPoint(1.0, 2.0, 3.0), new CVector(2.5, 1.5, 3.5),
                new CPoint(3.5, 3.5, 6.5));
            yield return new TestCaseData(new CPoint(1.2, 2.1, 2.5), new CVector(2.1, 1.5, 3.3),
                new CPoint(3.3, 3.6, 5.8));
        }
    }

    [Test]
    [TestCaseSource(nameof(AddPointAndVectorData))] 
    public void AddPointAndVector(CPoint p, CVector v, CPoint resP)
    {
        var res = p + v;
        Assert.That(res.IsEqual(resP), Is.True);
    }
    
    public static IEnumerable<TestCaseData> SubPointAndVectorData
    {
        get
        {
            yield return new TestCaseData(new CPoint(1.0, 2.0, 3.0), new CVector(2.5, 1.5, 3.5),
                new CPoint(-1.5, 0.5, -0.5));
            yield return new TestCaseData(new CPoint(1.2, 2.1, 2.5), new CVector(2.1, 1.5, 3.3),
                new CPoint(-0.9, 0.6, -0.8));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(SubPointAndVectorData))] 
    public void SubPointAndVector(CPoint p, CVector v, CPoint resP)
    {
        var res = p - v;
        Assert.That(res.IsEqual(resP), Is.True);
    }
    
    public static IEnumerable<TestCaseData> SubPointsData
    {
        get
        {
            yield return new TestCaseData(new CPoint(1.0, 2.0, 3.0), new CPoint(2.5, 1.5, 3.5),
                new CVector(-1.5, 0.5, -0.5));
            yield return new TestCaseData(new CPoint(1.2, 2.1, 2.5), new CPoint(2.1, 1.5, 3.3),
                new CVector(-0.9, 0.6, -0.8));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(SubPointsData))] 
    public void SubPoints(CPoint p, CPoint v, CVector resP)
    {
        var res = p - v;
        Assert.That(res.IsEqual(resP), Is.True);
    }
    
}