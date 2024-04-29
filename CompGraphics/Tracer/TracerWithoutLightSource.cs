using CompGraphics.Objects.MathObjects;
using CompGraphics.Results;

namespace CompGraphics.Tracer;

public class TracerWithoutLightSource: ITracer
{
    public TracingResult RayTrace(CPoint rayStartPos, CVector rayDirection)
    {
        throw new NotImplementedException();
    }
}