
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using CompGraphics.Objects.MathObjects;
using Microsoft.VisualBasic;

namespace CompGraphics.Main; 

public class ProgramStart
{
    public static void Main(string[] args)
    {
        var p1 = new CPoint(1.3, 1.2, 1.4);
        var p2 = new CVector(2.5, 2.3, 1.2);
        var p3 = new CVector(1.3, 1.2, 2.5);
        (p1 + p2).Show();
        (p1 - p2).Show();
        Console.WriteLine((p1-p2).IsEqual(new CPoint(-1.2, -1.1, 0.2)));
    }
}