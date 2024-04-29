using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;



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

    public IntersectionResult? HasIntersection(CPoint rayStart, CVector ray)
    {
        var k = rayStart - Center;
        var a = ray.DotProduct(ray);
        var b = 2 * ray.DotProduct(k);
        var c = k.DotProduct(k) - Radius * Radius;
        var D = b * b - 4 * a * c;
        
        switch (D)
        {
            case < 0.0d:
                return null;
            case 0:
            {
                var t = (- b) / (2 * a);
                return new IntersectionResult(rayStart + ray * t, (rayStart + ray * t) - Center, t);
            }
        }

        var t1 = (Math.Sqrt(D) - b) / (2 * a);
        var t2 = (- Math.Sqrt(D) - b) / (2 * a);
        if (Math.Abs(t1) < Math.Abs(t2))
        {
            return t1 < 0 ? null : new IntersectionResult(rayStart + ray * t1, (rayStart + ray * t1) - Center, t1);
        }

        return t2 < 0 ? null : new IntersectionResult(rayStart + ray * t2, (rayStart + ray * t2) - Center, t2);
    }
}