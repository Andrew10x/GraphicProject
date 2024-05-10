
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.OtherObjects;
using CompGraphics.Objects.Shapes;
using System.Globalization;
using System.Net;
using CompGraphics.Image;
using CompGraphics.Reader;
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

        //Work();
        Test3();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: CompGraphics.Objects.MathObjects.CVector; size: 494MB")]
    public static void Test3()
    {
        Scene scene = new Scene();
        FileReader fr = new FileReader();
        DataFromFile df = fr.ReadFromFile("D:/objTest/cow.obj");
        var shapes = df.GetAllTriangles();
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(1, -1, -1).MakeUnitVector()));
        var image = new ConsoleImage(res.GetLength(0), res);
        new ConsoleWriter().Write(image);
    }
    public static void TriangleTest()
    {
        Scene scene = new Scene();
        //var triangle = new Triangle(new CPoint(-10, 10, 5), new CPoint(10, 10, 5), new CPoint(0, 0, 1),
        //    new CVector(0, 0, 1), new CVector(0, 0, 1), new CVector(0, 0, 1));
        var triangle = new Triangle(new CPoint(-5, 0, -8), new CPoint(5, 0, -8), 
            new CPoint(0, 5, -8), new CVector(0, 0, 1), new CVector(0, 0, 1), new CVector(0, 0, 1));
        var shapes = new List<IShape> { triangle };
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 1, -1)));
        var image = new ConsoleImage(res.GetLength(0), res);
        new ConsoleWriter().Write(image);
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