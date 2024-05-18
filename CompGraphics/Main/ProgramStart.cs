
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
using CompGraphics.Objects;
using CompGraphics.Reader;
using CompGraphics.Tracer;
using CompGraphics.Writer;
using Microsoft.VisualBasic;

namespace CompGraphics.Main; 

public class ProgramStart
{
    public static void Main(string[] args)
    {
        //ForExeFunc(args);
        //ShowNoLightSource();
        //ShowNearest();
        //ShowCowInConsole();
        //ShowCowInFile();
        //TriangleConsoleTest();
        //TriangleFileTest();
        ShowCowInFileTest();
    }

    public static void T()
    {
        var scene = new Scene(400);
        var plane = new Plane(new CVector(1, 0, 0), new CPoint(4, 0, 0));
        var shapes = new List<IShape> { plane };
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(1, -1, -1).MakeUnitVector()));
        var image = new FileImage(res.GetLength(0), res);
        new FileWriter("D:/objTest/res/plane.ppm").Write(image);
        //var image = new ConsoleImage(res.GetLength(0), res);
        //new ConsoleWriter().Write(image);

    }
    
    
    public static void ShowCowInFileTest()
    {
        var scene = new Scene(100);
        var fr = new FileReader();
        var df = fr.ReadFromFile("D:/objTest/cow.obj");
        var tm = new TransformMatrix();
        tm.CreateScaleMatrix(1.4f, 1.4f, 1.4f);
        df.Transform(tm);
        tm.CreateRotateXMatrix(-90);
        df.Transform(tm);
        tm.CreateRotateYMatrix(-44);
        df.Transform(tm);
        tm.CreateTranslationMatrix(0, 0, -2);
        df.Transform(tm);
        var shapes = df.GetAllTriangles();
        var sphere = new Sphere(0.2, new CPoint(-0.6, 0.6, -2));
        var plane = new Plane(new CVector(0, -1, 0), new CPoint(-1, -1, -1));
        shapes.Add(plane);
        shapes.Add(sphere);
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(1, -1, -1).MakeUnitVector()));
        var image = new FileImage(res.GetLength(0), res);
        new FileWriter("D:/objTest/res/cow1.ppm").Write(image);
        
    }

    public static void ForExeFunc(string[] args)
    {
        var source = args[0].Split('=')[1];
        var output =  args[1].Split('=')[1];
        var s = args[2].Split('=')[1];
        var size = Convert.ToInt32(s, CultureInfo.InvariantCulture);
        
        var scene = new Scene(size);
        var fr = new FileReader();
        var df = fr.ReadFromFile(source);
        var tm = new TransformMatrix();
        tm.CreateScaleMatrix(1.4f, 1.4f, 1.4f);
        df.Transform(tm);
        tm.CreateRotateXMatrix(-90);
        df.Transform(tm);
        tm.CreateRotateYMatrix(-44);
        df.Transform(tm);
        tm.CreateTranslationMatrix(0, 0, -2);
        df.Transform(tm);
        var shapes = df.GetAllTriangles();
        var sphere = new Sphere(0.2, new CPoint(-0.6, 0.6, -2));
        var plane = new Plane(new CVector(0, -1, 0), new CPoint(-1, -1, -1));
        shapes.Add(plane);
        shapes.Add(sphere);
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(1, -1, -1).MakeUnitVector()));
        if (output == "console")
        {
            var im = new ConsoleImage(res.GetLength(0), res);
            new ConsoleWriter().Write(im);
        }
        else
        {
            var image = new FileImage(res.GetLength(0), res);
            new FileWriter(output).Write(image);
        }
    }

    public static void ShowNoLightSource()
    {
        var scene = new Scene(25);
        var shapes = new List<IShape>();
        var sphere = new Sphere(1.6, new CPoint(0, 0, -4));
        shapes.Add(sphere);
        var res = scene.Trace(new TracerWithoutLightSource(shapes));
        var image = new ConsoleImage(res.GetLength(0), res);
        new ConsoleWriter().Write(image);
    }

    public static void ShowNearest()
    {
        var scene = new Scene(400);
        var shapes = new List<IShape>();
        var sphere = new Sphere(0.2, new CPoint(-0.6, 0.6, -4));
        var sphere2 = new Sphere(0.2, new CPoint(0.6, -0.6, -3));
        shapes.Add(sphere);
        shapes.Add(sphere2);
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 0, -1).MakeUnitVector(),
            scene.Camera.StartPos));
        var image = new FileImage(res.GetLength(0), res);
        new FileWriter("D:/objTest/res/nearest.ppm").Write(image);
    }

    public static void ShowCowInConsole()
    {
        var scene = new Scene(50);
        var fr = new FileReader();
        var df = fr.ReadFromFile("D:/objTest/cow.obj");
        var tm = new TransformMatrix();
        tm.CreateScaleMatrix(1.4f, 1.4f, 1.4f);
        df.Transform(tm);
        tm.CreateRotateXMatrix(-90);
        df.Transform(tm);
        tm.CreateRotateYMatrix(-30);
        df.Transform(tm);
        tm.CreateTranslationMatrix(0, 0, -2);
        df.Transform(tm);
        var shapes = df.GetAllTriangles();
        //var sphere = new Sphere(0.2, new CPoint(-0.6, 0.6, -2));
        //var plane = new Plane(new CVector(0, -1, 0), new CPoint(-1, -1, -1));
        //shapes.Add(plane);
       // shapes.Add(sphere);
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(1, -1, -1).MakeUnitVector()));
        //var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 0, -1).MakeUnitVector()));
        var image = new ConsoleImage(res.GetLength(0), res);
        new ConsoleWriter().Write(image);
    }

    public static void ShowCowInFile()
    {
        var scene = new Scene(100);
        var fr = new FileReader();
        var df = fr.ReadFromFile("D:/objTest/cow.obj");
        var tm = new TransformMatrix();
        tm.CreateScaleMatrix(1.4f, 1.4f, 1.4f);
        df.Transform(tm);
        tm.CreateRotateXMatrix(-90);
        df.Transform(tm);
        tm.CreateRotateYMatrix(-30);
        df.Transform(tm);
        tm.CreateTranslationMatrix(0, 0, -2);
        df.Transform(tm);
        var shapes = df.GetAllTriangles();
        var sphere = new Sphere(0.2, new CPoint(-0.6, 0.6, -2));
        var plane = new Plane(new CVector(0, -1, 0), new CPoint(-1, -1, -1));
        shapes.Add(plane);
        shapes.Add(sphere);
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(1, -1, -1).MakeUnitVector()));
        //var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 0, -1).MakeUnitVector()));
        var image = new FileImage(res.GetLength(0), res);
        new FileWriter("D:/objTest/res/cow1.ppm").Write(image);
        
    }
    public static void TriangleConsoleTest()
    {
        var scene = new Scene(20);
        var triangle = new Triangle(new CPoint(-5, 0, -8), new CPoint(5, 0, -8), 
            new CPoint(0, 5, -8), new CVector(0, 0, 1), new CVector(0, 0, 1), new CVector(0, 0, 1));
        var shapes = new List<IShape> { triangle };
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 1, -1)));
        var image = new ConsoleImage(res.GetLength(0), res);
        new ConsoleWriter().Write(image);
    }
    
    public static void TriangleFileTest()
    {
        var scene = new Scene(500);
        var triangle = new Triangle(new CPoint(-5, 5, -10), new CPoint(5, 5, -10), new CPoint(0, -2, -10),
        new CVector(1, 1, 0.2).MakeUnitVector(), new CVector(1, 0, 0.8).MakeUnitVector(), new CVector(0, 0, 1));
        //new CVector(0, 0, -1).MakeUnitVector(), new CVector(0, 0, -1).MakeUnitVector(), new CVector(0, 0, -1));
        var shapes = new List<IShape> { triangle };
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 0, -1)));
        var image = new FileImage(res.GetLength(0), res);
        new FileWriter("D:/objTest/res/triangle.ppm").Write(image);
    }

    public static void SphereInConsole()
    {
        Scene scene = new Scene(30);
        var sphere = new Sphere(8, new CPoint(0, 0, -24));
        var shapes = new List<IShape> { sphere };
        var res = scene.Trace(new TracerWithLightSource(shapes, new CVector(0, 0, -1)));

        var image = new ConsoleImage(res.GetLength(0), res);
        new ConsoleWriter().Write(image);
    }
}