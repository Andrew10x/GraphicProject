using CompGraphics.Objects.Math;

namespace CompGraphics.Objects.Shapes;

public interface IShape
{
    public double MinDistance(Point point);
    public Point HasIntersection(Point start, Vector ray);
}