
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;
using CompGraphics.Results;
using CompGraphics.Tracer;

namespace CompGraphics.Objects.OtherObjects;

public class Scene
{
    public Camera Camera { get; }

    public Scene()
    {
        Camera = new Camera();
    }

    public Scene(int size)
    {
        Camera = new Camera(size);
    }

    public Scene(CPoint cameraStartPos, CVector cameraDirection, int size, int fov)
    {
        Camera = new Camera(cameraStartPos, cameraDirection, size, fov);
    }
    
    public TracingResult[,] Trace(ITracer tracer)
    {
        var size = Camera.Size;
        var trRes = new TracingResult[size, size];
        
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                var ray = Camera.CreateRay(i, j);
                trRes[i, j] = tracer.RayTrace(Camera.StartPos, ray);
            }
        }
        return trRes;
    }
}