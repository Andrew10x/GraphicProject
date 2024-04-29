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
}