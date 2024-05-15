using CompGraphics.Objects.MathObjects;
using CompGraphics.Results;

namespace CompGraphics.Objects.Shapes;

public class Plane: IShape
{
    public CVector Normal { get; }
    
    public double D { get; }
        
    public CPoint Point { get; }

    public Plane(CVector normal, CPoint point)
    {
        Normal = normal.MakeUnitVector();
        Point = point;
        D = -(normal.X*point.X + normal.Y*point.Y + normal.Z*point.Z);
    }
    public double MinDistance(CPoint point)
    {
        return  Math.Abs(Normal.X * point.X + Normal.Y * point.Y + Normal.Z * point.Z + D)/ 
                Math.Sqrt(Normal.X * Normal.X + Normal.Y * Normal.Y + Normal.Z * Normal.Z);
    }

    public IntersectionResult? HasIntersection(CPoint rayStart, CVector ray)
    {
        if (ray.DotProduct(Normal)  <= 1e-6)
            return null;
        
        var t = -(D + rayStart.Z * Normal.Z + rayStart.Y * Normal.Y + rayStart.X * Normal.X) / ray.DotProduct(Normal);
            return new IntersectionResult(rayStart + ray * t, -Normal, t);
        }
}