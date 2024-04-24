
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

    public static void MainWork()
    {
        var scene = new Scene();
            
        var sphere = new Sphere(12, new CPoint(0, 0, 24));
            
        scene.RayTracing(sphere);
        
        scene.RayTracing(sphere, new CVector(-3, -2, 1));
    }
}