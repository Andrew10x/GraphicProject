using System.Numerics;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;

namespace CompGraphics.Tracer;

public class TracerWithLightSource: ITracer
{
    public List<IShape> Shapes { get; }
    public CVector LightSource { get; }
    
    public TracerWithLightSource(List<IShape> shapes, CVector lightSource)
    {
        Shapes = shapes;
        LightSource = lightSource;
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
}