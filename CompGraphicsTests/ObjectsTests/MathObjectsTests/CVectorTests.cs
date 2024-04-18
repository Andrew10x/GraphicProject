using CompGraphics.Objects.MathObjects;

namespace CompGraphicsTests.ObjectsTests.MathObjectsTests;

[TestFixture]
public class CVectorTests
{
    public static IEnumerable<TestCaseData> AddVectorsData
    {
        get
        {
            yield return new TestCaseData(new CVector(1.0, 2.0, 3.0), new CVector(2.5, 1.5, 3.5),
                new CVector(3.5, 3.5, 6.5));
            yield return new TestCaseData(new CVector(1.2, 2.1, 2.5), new CVector(2.1, 1.5, 3.3),
                new CVector(3.3, 3.6, 5.8));
        }
    }

    [Test]
    [TestCaseSource(nameof(AddVectorsData))] 
    public void AddPointAndVector(CVector v1, CVector v2, CVector resV)
    {
        var res = v1 + v2;
        Assert.That(res.IsEqual(resV), Is.True);
    }
    
    public static IEnumerable<TestCaseData> SubVectorsData
    {
        get
        {
            yield return new TestCaseData(new CVector(1.0, 2.0, 3.0), new CVector(2.5, 1.5, 3.5),
                new CVector(-1.5, 0.5, -0.5));
            yield return new TestCaseData(new CVector(1.2, 2.1, 2.5), new CVector(2.1, 1.5, 3.3),
                new CVector(-0.9, 0.6, -0.8));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(SubVectorsData))] 
    public void SubPointAndVector(CVector p, CVector v, CVector resP)
    {
        var res = p - v;
        Assert.That(res.IsEqual(resP), Is.True);
    }
    
    public static IEnumerable<TestCaseData> MultVectorNumbData
    {
        get
        {
            yield return new TestCaseData(new CVector(1.0, 2.0, 3.0), 2.0,
                new CVector(2.0, 4.0, 6.0));
            yield return new TestCaseData(new CVector(1.2, 2.1, 2.5), 3.0,
                new CVector(3.6, 6.3, 7.5));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(MultVectorNumbData))] 
    public void MultVectorNumb(CVector p, Double d, CVector resP)
    {
        var res = p*d;
        Assert.That(res.IsEqual(resP), Is.True);
    }
    
    public static IEnumerable<TestCaseData> DotProductData
    {
        get
        {
            yield return new TestCaseData(new CVector(1.0, 2.0, 3.0), new CVector(2.5, 1.5, 3.5),
                16.0);
            yield return new TestCaseData(new CVector(1.2, 2.1, 2.5), new CVector(2.1, 1.5, 3.3),
                13.92);
        }
    }

    [Test]
    [TestCaseSource(nameof(DotProductData))] 
    public void DotProduct(CVector v1, CVector v2, Double resV)
    {
        var res = v1.DotProduct(v2);
        Assert.That(resV, Is.EqualTo(res).Within(0.000000000000001));
    }
    
    public static IEnumerable<TestCaseData> CrossProductData
    {
        get
        {
            yield return new TestCaseData(new CVector(1.0, 2.0, 3.0), new CVector(2.5, 1.5, 3.5),
                new CVector(2.5, 4.0, -3.5));
            yield return new TestCaseData(new CVector(1.2, 2.1, 2.5), new CVector(2.1, 1.5, 3.3),
                new CVector(3.18, 1.29, -2.61));
        }
    }

    [Test]
    [TestCaseSource(nameof(CrossProductData))] 
    public void CrossProduct(CVector v1, CVector v2, CVector resV)
    {
        var res = v1.CrossProduct(v2);
        Assert.That(res.IsEqual(resV), Is.True);
    }
    
    
    
}