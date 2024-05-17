using CompGraphics.Objects;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.OtherObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.ProjConstants;
using CompGraphics.Results;
using CompGraphics.Tracer;

namespace CompGraphicsTests.ObjectsTests.SceneTests;

[TestFixture]
public class SceneShowNearestTests
{
    public static IEnumerable<TestCaseData> HasIntersectionData
    {
        get
        {
            yield return new TestCaseData(new Sphere(12, new CPoint(0, 0, 24)),
                new Sphere(12, new CPoint(0, 0, -30)), new CPoint(0, 0, 0),
                new CVector(0, 0, 1), new CVector(0, 0, -1));
            
            yield return new TestCaseData(new Sphere(11, new CPoint(0, 0, -24)),
                new Sphere(14, new CPoint(0, 0, 30)), new CPoint(0, 0, 0),
                new CVector(0, 0, -1), new CVector(0, 0, 1));
            
            yield return new TestCaseData(new Sphere(20, new CPoint(0, 0, 30)),
                new Sphere(12, new CPoint(0, 0, -28)), new CPoint(0, 0, 0),
                new CVector(0, 0, 1), new CVector(0, 0, -1));
        }
    }

    [Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void PlaneHasIntersectionWithLightSource(Sphere sh1, Sphere sh2, CPoint rayStart, CVector ray1, CVector ray2)
    {
       var rayTracer = new TracerWithLightSource(new List<IShape>() { sh1, sh2 },
            new CVector(1, -1, -1).MakeUnitVector(), rayStart);
        var tr1 = rayTracer.RayTrace(rayStart, ray1);
        var tr2 = rayTracer.RayTrace(rayStart, ray2);
        Assert.That(tr2.InterRes, Is.Null);
        Assert.That(tr1.InterRes, Is.Not.Null);
        Assert.That(tr1.InterRes!.Distance, Is.EqualTo(sh1.MinDistance(rayStart)).Within(ProjConstants.EPSILON));
    }
    
    [Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void PlaneHasIntersectionWithoutLightSource(Sphere sh1, Sphere sh2, CPoint rayStart, CVector ray1, CVector ray2)
    {
        var rayTracer = new TracerWithoutLightSource(new List<IShape>() { sh1, sh2 }, rayStart);
        var tr1 = rayTracer.RayTrace(rayStart, ray1);
        var tr2 = rayTracer.RayTrace(rayStart, ray2);
        Assert.That(tr2.InterRes, Is.Null);
        Assert.That(tr1.InterRes, Is.Not.Null);
        Assert.That(tr1.InterRes!.Distance, Is.EqualTo(sh1.MinDistance(rayStart)).Within(ProjConstants.EPSILON));
    }
}