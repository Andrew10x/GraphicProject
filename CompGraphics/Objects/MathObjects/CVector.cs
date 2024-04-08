namespace CompGraphics.Objects.MathObjects;
using System;
public class CVector
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    
    public CVector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public void Show()
    {
        Console.WriteLine("(" + X + ", " + Y + ", " + Z + ")");
    }
    
    public bool IsEqual(CVector vector2, double eps = 0.005)
    {
        return Math.Abs(X - vector2.X) < eps &&
               Math.Abs(Y - vector2.Y) < eps &&
               Math.Abs(Z - vector2.Z) < eps;
    }
}