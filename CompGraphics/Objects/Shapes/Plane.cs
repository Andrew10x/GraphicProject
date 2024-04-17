using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Objects.Shapes;
using System;
public class Plane: IShape
{
    public CVector Normal { get; }
    
    public double D { get; }
        
    public CPoint Point { get; }

    public Plane(CVector normal, Double d, CPoint point)
    {
        Normal = normal;
        D = d;
        Point = point;
    }
    public double MinDistance(CPoint point)
    {
        return  Math.Abs(Normal.X * point.X + Normal.Y * point.Y + Normal.Z * point.Z + D)/ 
                Math.Sqrt(Normal.X * Normal.X + Normal.Y * Normal.Y + Normal.Z * Normal.Z);
    }

    public CPoint? HasIntersection(CPoint rayStart, CVector ray)
    {
        var t = -(D + rayStart.Z * Normal.Z + rayStart.Y * Normal.Y + rayStart.X * Normal.X) /
                (ray.Z * Normal.Z + ray.Y * Normal.Y + ray.X * Normal.X);
        return rayStart + ray * t;
    }
}