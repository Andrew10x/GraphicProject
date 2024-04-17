using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Objects.Shapes;
using System;
public class Sphere: IShape
{
    public double Radius { get; }
    public CPoint Center { get; }


    public Sphere (Double radius, CPoint center)
    {
        Radius = radius;
        Center = center;
    }
    public double MinDistance(CPoint point)
    {
        return Math.Abs(Center.MinDistance(point) - Radius);
    }

    public CPoint? HasIntersection(CPoint rayStart, CVector ray)
    {
        var k = rayStart - Center;
        var a = ray.DotProduct(ray);
        var b = 2 * ray.DotProduct(k);
        var c = k.DotProduct(k) - Radius * Radius;
        var D = b * b - 4 * a * c;
        
        if (D < 0.0d)
        { 
            return null;
        }
        if (D == 0)
        { 
            var t = (- b) / (2 * a);
            return rayStart + ray * t;
        }
            
        var t1 = (Math.Sqrt(D) - b) / (2 * a);
        var t2 = (- Math.Sqrt(D) - b) / (2 * a);
        if (Math.Abs(t1) < Math.Abs(t2)) 
            return rayStart + ray*t1;
        
        return rayStart + ray*t2;
        }
}