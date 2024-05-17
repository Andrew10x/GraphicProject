using CompGraphics.Objects;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;

namespace CompGraphics.Tracer;

public class TracerWithoutLightSource: ITracer
{
    
    public List<IShape> Shapes { get; }
    public TracerWithoutLightSource(List<IShape> shapes, CPoint? rayStartPos = null)
    {
        if (rayStartPos == null)
            Shapes = shapes;
        else if (shapes.Count >= 1)
            Shapes = new List<IShape>() { FindNearestShape(shapes, rayStartPos) };
        else
            Shapes = new List<IShape>();
    }
    public TracingResult RayTrace(CPoint rayStartPos, CVector rayDirection)
    {
        IntersectionResult? nearIntersect = null;

        foreach (var shape in Shapes)
        {
            var curIntersect = shape.HasIntersection(rayStartPos, rayDirection);
            
            if (
                curIntersect != null && (nearIntersect == null || curIntersect.Distance < nearIntersect?.Distance))
            {
                nearIntersect = curIntersect;
            }
        }

        if (nearIntersect == null) 
            return new TracingResult(null, null);

        return new TracingResult(nearIntersect, null, true);
    }
    
    private IShape FindNearestShape(List<IShape> shapes, CPoint rayStartPos)
    {
        var minDistShape = shapes[0];
        for (var i = 1; i < shapes.Count; i++)
        {
            var d = shapes[i].MinDistance(rayStartPos);
            if (minDistShape.MinDistance(rayStartPos) > d)
                minDistShape = shapes[i];
        }

        return minDistShape;
    }
}