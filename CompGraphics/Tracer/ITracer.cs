using System.Drawing;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Results;

namespace CompGraphics.Tracer;

public interface ITracer
{
    public TracingResult RayTrace(CPoint rayStartPos, CVector rayDirection);
}