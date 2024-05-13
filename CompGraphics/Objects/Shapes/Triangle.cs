using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.ProjConstants;
using CompGraphics.Results;

public class Triangle: IShape
{
    public CPoint P1 { get; }
    public CPoint P2 { get; }
    public CPoint P3 { get; }
    
    public CVector N1 { get; }
    public CVector N2 { get; }
    public CVector N3 { get; }

    public Triangle(CPoint p1, CPoint p2, CPoint p3, CVector n1, CVector n2, CVector n3)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
        N1 = n1;
        N2 = n2;
        N3 = n3;
    }

    public double MinDistance(CPoint point)
    {
        var d = P1 - point;
        if (d.Length() > (P2 - point).Length())
            d = P2 - point;
        if (d.Length() > (P3 - point).Length())
            d = P3 - point;
        return d.Length();
    }

    public IntersectionResult? HasIntersection(CPoint start, CVector ray)
    {
        /*var edge1 = P2 - P1;
        var edge2 = P3 - P1;

        var p = ray.CrossProduct(edge2);
        var det = edge1.DotProduct(p);
        
        if (Math.Abs(det) < ProjConstants.EPSILON)
            return null;
        
        var invDet = 1.0 / det;
        var t = start - P1;
        var u = t.DotProduct(p) * invDet;
        
        if (u is < 0.0 or > 1.0)
            return null;

        var q = t.CrossProduct(edge1);
        var v = ray.DotProduct(q) * invDet;
        
        if (v < 0.0 || u + v > 1.0)
            return null;
        
        var distance = invDet * edge2.DotProduct(q);

        return distance <= ProjConstants.EPSILON ? null :
            new IntersectionResult(start + ray * distance,N1 * (1 - u - v) + N2 * u + N3 * v, distance);
        
        */
        
        
        
        
        
        CPoint vertex0 = P1;
        CPoint vertex1 = P2;
        CPoint vertex2 = P3;
        
        CVector edge1 = vertex1 - vertex0;
        CVector edge2 = vertex2 - vertex0;
        
        CVector p = new CVector(0, 0,0);
        CVector t = new CVector(0, 0,0);
        CVector q = new CVector(0, 0,0);
        
        double det, invDet, u, v;

        p = ray.CrossProduct(edge2);
        det = edge1.DotProduct(p);
        
        if (Math.Abs(det) < ProjConstants.EPSILON)
        {
            return null;
        } 
        
        invDet = 1.0 / det;
        t = start - vertex0;
        u = t.DotProduct(p) * invDet;
        
        if (u is < 0.0 or > 1.0)
        {
            return null;
        }
        
        q = t.CrossProduct(edge1);
        v = ray.DotProduct(q) * invDet;
        
        if (v < 0.0 || u + v > 1.0)
        {
            return null;
        }
        
        var distance = invDet * edge2.DotProduct(q);
        

        if (distance > ProjConstants.EPSILON)
        {
            return new IntersectionResult(
                start + ray * distance,
                N1 * (1 - u - v) + N2 * u + N3 * v,
                distance);
        }
        else
        {
            return null;
        }
    }
}