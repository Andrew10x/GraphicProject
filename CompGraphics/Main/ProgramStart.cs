
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.OtherObjects;
using CompGraphics.Objects.Shapes;
using Microsoft.VisualBasic;

namespace CompGraphics.Main; 

public class ProgramStart
{
    public static void Main(string[] args)
    {
        MainWork();
    }

    private static void MainWork()
    {
        var scene = new Scene();
            
        var sphere = new Sphere(12, new CPoint(0, 0, 24));
        var sphere2 = new Sphere(14, new CPoint(0, 0, 30));
        
        scene.RayTracing(sphere2);
        scene.RayTracing(sphere2, new CVector(-3, -2, 1));
        
        var l = new List<IShape>() { sphere, sphere2 };
        scene.RayTracingNearest(l, new CVector(3, -2, 1));
    }
}