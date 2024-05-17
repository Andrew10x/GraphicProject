using System.Numerics;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;

namespace CompGraphics.Tracer;

public class TracerWithLightSource: ITracer
{
    public List<IShape> Shapes { get; }
    public CVector LightSource { get; }
    
    public TracerWithLightSource(List<IShape> shapes, CVector lightSource, CPoint? rayStartPos = null)
    {  
        LightSource = lightSource;
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
            return new TracingResult(null, LightSource);

        var rayFromNormal = nearIntersect.Point + nearIntersect.Normal * ProjConstants.ProjConstants.EPSILON;
        
		
        foreach (var shape in Shapes) {
            var intersect2 = shape.HasIntersection(rayFromNormal, -LightSource);
            if(intersect2 != null) {
                return new TracingResult(nearIntersect, null);
            }
        }

        return new TracingResult(nearIntersect, LightSource);
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