
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.OtherObjects;
using CompGraphics.Objects.Shapes;
using System.Globalization;
using CompGraphics.Image;
using CompGraphics.Tracer;
using CompGraphics.Writer;
using Microsoft.VisualBasic;

namespace CompGraphics.Main; 

public class ProgramStart
{
    public static void Main(string[] args)
    {
        //MainWork();
        //Work2();
        //String s = "0.14922";
        //double d = Convert.ToDouble(s);
        //double d = Convert.ToDouble("855.65", CultureInfo.InvariantCulture);
        //Console.Write(d);

        Work();
    }

    private static void Work()
    {
        Scene scene = new Scene();
        var sphere = new Sphere(12, new CPoint(0, 0, -24));
        var shapes = new List<IShape> { sphere };
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 0, -1)));

        var image = new ConsoleImage(res.GetLength(0), res);
        new ConsoleWriter().Write(image);
    }

    /*private static void MainWork()
    {
        var scene = new Scene();
            
        var sphere = new Sphere(12, new CPoint(0, 0, 24));
        var sphere2 = new Sphere(14, new CPoint(0, 0, 30));
        
        scene.RayTracing(sphere2);
        scene.RayTracing(sphere2, new CVector(-3, -2, 1));
        
        var l = new List<IShape>() { sphere, sphere2 };
        scene.RayTracingNearest(l, new CVector(3, -2, 1));
    }

    private static void Work2()
    {
        var scene = new Scene();
        var plane = new Plane(new CVector(1, 0, 0).MakeUnitVector(), new CPoint(1, 2, 3));
        scene.RayTracing(plane);
        
        
    }*/
}