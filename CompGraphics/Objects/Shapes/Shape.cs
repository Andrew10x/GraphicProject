using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Objects.Shapes;

public interface IShape
{
    public double MinDistance(CPoint point);
    public CPoint? HasIntersection(CPoint start, CVector ray);
}