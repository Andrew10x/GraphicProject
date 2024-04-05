using CompGraphics.Objects.Math;

namespace CompGraphics.Objects.Shapes;

public class Sphere: IShape
{
    public double MinDistance(Point point)
    {
        return 1.9;
    }

    public Point HasIntersection(Point start, Vector ray)
    {
        return new Point();
    }
}