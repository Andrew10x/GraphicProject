using CompGraphics.Objects.MathObjects;
using CompGraphics.Tracer;

namespace CompGraphics.Results;

public class TracingResult
{
    public double Darckening { get; }
    public IntersectionResult? InterRes { get; }
    public CVector? LightSource { get; }

    public TracingResult(IntersectionResult? interRes, CVector? lightSource)
    {
        InterRes = interRes;
        LightSource = lightSource;
    }
}