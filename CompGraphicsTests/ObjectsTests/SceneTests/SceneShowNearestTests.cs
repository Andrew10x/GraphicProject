using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.OtherObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphicsTests.ObjectsTests.SceneTests;

[TestFixture]
public class SceneShowNearestTests
{
    public static IEnumerable<TestCaseData> HasIntersectionData
    {
        get
        {
            yield return new TestCaseData(new Sphere(12, new CPoint(0, 0, 24)),
                new Sphere(14, new CPoint(0, 0, 30)),
                new Sphere(12, new CPoint(0, 0, 24)));
            
            yield return new TestCaseData(new Sphere(12, new CPoint(0, 0, 24)),
                new Sphere(24, new CPoint(0, 0, 30)),
                new Sphere(24, new CPoint(0, 0, 30)));
        }
    }

    /*[Test]
    [TestCaseSource(nameof(HasIntersectionData))]
    public void PlaneHasIntersection(Sphere sh1, Sphere sh2, Sphere resSh)
    {
        Scene scene = CreateScene();
        var l = new List<IShape>() { sh1, sh2 };
        var res = (Sphere) scene.RayTracingNearest(l, new CVector(3, -2, 1));
        Assert.That(resSh.Radius, Is.EqualTo(res.Radius).Within(0.0001));
        Assert.That(res.Center!.IsEqual(resSh.Center), Is.True);
    }
    
    private static Scene CreateScene()
    {
        var cameraStartPos = new CPoint(0, 0, 0);
        const double distFromCameraToScreen = 10.0;
        var cameraDirection = new CVector(0, 0, 1);
        const int width = 22;
        const int height = 22;
        return new Scene(width, height, distFromCameraToScreen, cameraStartPos, cameraDirection);
    }*/
}