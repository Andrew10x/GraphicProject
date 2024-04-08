using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Objects.Shapes;

public class Sphere: IShape
{
    public double MinDistance(CPoint point)
    {
        return 1.9;
    }

    public CPoint HasIntersection(CPoint start, CVector ray)
    {
        return new CPoint(1, 2, 3);
    }
}