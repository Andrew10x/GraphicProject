using CompGraphics.Objects.MathObjects;
using CompGraphics.Tracer;

namespace CompGraphics.Results;

public class TracingResult
{
    public double Darckening { get; }
    public IntersectionResult? InterRes { get; }
    public CVector? LightSource { get; }

    public TracingResult(IntersectionResult? interRes, CVector? lightSource, bool noLightSource = false)
    {
        InterRes = interRes;
        LightSource = lightSource;
        if (interRes != null && lightSource != null)
        {
            Darckening = (-LightSource!).DotProduct(interRes.Normal);
        }
        else if (interRes == null)
        {
            Darckening = -1;
        }
        else if (lightSource == null)
        {
            if (noLightSource)
                Darckening = 1;
            else
                Darckening = 0;
        }
        
    }
}