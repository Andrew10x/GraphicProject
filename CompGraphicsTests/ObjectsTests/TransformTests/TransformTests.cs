using CompGraphics.Objects;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;

namespace CompGraphicsTests.ObjectsTests.TransformTests;

[TestFixture]
public class TransformTests
{
    public static IEnumerable<TestCaseData> ScaleData
    {
        get
        {
            yield return new TestCaseData(new CPoint(-1, 0, 0), new CVector(1, 0, 3),
                new TransformMatrix(), 2f, new CPoint(-2, 0, 0), new CVector(2, 0, 6));
            
            yield return new TestCaseData(new CPoint(-1, 0, 0), new CVector(1, 0, 3),
                new TransformMatrix(), 4f, new CPoint(-4, 0, 0), new CVector(4, 0, 12));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(ScaleData))]
    public void Scale(CPoint p, CVector v, TransformMatrix tm, float sl, CPoint p2, CVector v2)
    {
        tm.CreateScaleMatrix(sl, sl, sl);
        p.Transform(tm);
        v.Transform(tm);
        Assert.Multiple(() =>
        {
            Assert.That(p.IsEqual(p2), Is.True);
            Assert.That(v.IsEqual(v2), Is.True);
        });
    }
    
    public static IEnumerable<TestCaseData> TranslationData
    {
        get
        {
            yield return new TestCaseData(new CPoint(-1, 1, 0), new CVector(1, 0, 3),
                new TransformMatrix(), 2f, 3f, 1f, new CPoint(1, 4, 1), new CVector(1, 0, 3));
            
            yield return new TestCaseData(new CPoint(-1, 1, 0), new CVector(1, 0, 3),
                new TransformMatrix(), 4f, 2f, 3f, new CPoint(3, 3, 3), new CVector(1, 0, 3));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(TranslationData))]
    public void Translation(CPoint p, CVector v, TransformMatrix tm, float t1, float t2, float t3, CPoint p2, CVector v2)
    {
        tm.CreateTranslationMatrix(t1, t2, t3);
        p.Transform(tm);
        v.Transform(tm);
        Assert.Multiple(() =>
        {
            Assert.That(p.IsEqual(p2), Is.True);
            Assert.That(v.IsEqual(v2), Is.True);
        });
    }
    
    public static IEnumerable<TestCaseData> RotationData
    {
        get
        {
            yield return new TestCaseData(new CPoint(0, 1, 0), new CVector(0, 1, 0),
                new TransformMatrix(), 90, 0, 0, new CPoint(0, 0, 1), new CVector(0, 0, 1));
            
            yield return new TestCaseData(new CPoint(0, 1, 0), new CVector(0, 1, 0),
                new TransformMatrix(), 90, 90, 0, new CPoint(1, 0, 0), new CVector(1, 0, 0));
            
            yield return new TestCaseData(new CPoint(0, 1, 0), new CVector(0, 1, 0),
                new TransformMatrix(), 90, 90, 90, new CPoint(0, 1, 0), new CVector(0, 1, 0));
        }
    }
    
    [Test]
    [TestCaseSource(nameof(RotationData))]
    public void Rotation(CPoint p, CVector v, TransformMatrix tm, float ax, float ay, float az,  CPoint p2, CVector v2)
    {
        tm.CreateRotateXMatrix(ax);
        p.Transform(tm);
        v.Transform(tm);
        tm.CreateRotateYMatrix(ay);
        p.Transform(tm);
        v.Transform(tm);
        tm.CreateRotateZMatrix(az);
        p.Transform(tm);
        v.Transform(tm);
        Assert.Multiple(() =>
        {
            Assert.That(p.IsEqual(p2), Is.True);
            Assert.That(v.IsEqual(v2), Is.True);
        });
    }
}

