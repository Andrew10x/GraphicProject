using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Results;

public class IntersectionResult
{
    public CPoint Point { get; }
    public CVector Normal { get; }
    public double Distance { get; }

    public IntersectionResult(CPoint point, CVector normal, double distance)
    {
        Point = point;
        Normal = normal;
        Distance = distance;
    }

    public bool IsEqual(IntersectionResult res2)
    {
        return Point.IsEqual(res2.Point, ProjConstants.ProjConstants.EPSILON) && 
               Normal.IsEqual(res2.Normal, ProjConstants.ProjConstants.EPSILON) &&
               Math.Abs(Distance - res2.Distance) <= ProjConstants.ProjConstants.EPSILON;
    }
}