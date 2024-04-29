using CompGraphics.Objects.MathObjects;
using CompGraphics.Results;

namespace CompGraphics.Objects.Shapes;

public interface IShape
{
    public double MinDistance(CPoint point);
    public IntersectionResult? HasIntersection(CPoint start, CVector ray);
}