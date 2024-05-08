
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
                var a3 = 5;
                if (i == 5 && j == 5)
                    a3 = 5;
                var ray = Camera.CreateRay(i, j);
                trRes[i, j] = tracer.RayTrace(Camera.StartPos, ray);
            }
        }
        return trRes;
    }
    
    
    /*public Screen Screen { get;}
    
    public Camera Camera { get; }
    
    public Scene()
    {
        Screen = new Screen(22, 22);

        var cameraStartPos = new CPoint(0, 0, 0);
        const double distFromCameraToScreen = 10.0;
        var cameraDirection = new CVector(0, 0, 1);
        
        Camera = new Camera(
            cameraStartPos,
            cameraDirection,
            distFromCameraToScreen);
        
    }

    public Scene(int width, int height, double distFromCameraToScreen, CPoint cameraStartPos, CVector cameraDirection)
    {
        Screen = new Screen(width, height);

        Camera = new Camera(
            cameraStartPos,
            cameraDirection,
            distFromCameraToScreen);
    }
    
    public List<(CPoint clCenter, int i, int j)> GetScreenCells()
    {
        var clCenters = new List<(CPoint clCenter, int i, int j)>();
        var screenCenter = Camera.StartPos + Camera.Direction * Camera.DistanceToScreen;

        var lX = screenCenter.X - Screen.Height / 2.0;
        var lY = screenCenter.Y - Screen.Width / 2.0;
        
        for (var i = 0; i < Screen.Height; i++)
        {
            for (var j = 0; j < Screen.Width; j++)
            {
                var clCenter = new CPoint(i + lX, j + lY, screenCenter.Z);

                clCenters.Add((clCenter, i, j));
            }
        }

        return clCenters;
    }
    
    public void RayTracing(IShape shape)
    {
        Screen.ClearScreen();
        
        foreach (var cell in GetScreenCells())
        {
            if (cell.i == 1 && cell.j == 1)
            {
                int a = 1;
            }
            var intersection = shape.HasIntersection(Camera.StartPos, cell.clCenter - Camera.StartPos);
            char ch = ' ';
            if(intersection != null) 
                ch = '#';
            Screen.SetCell(cell.i, cell.j, ch);

        }

        Screen.Show();
    }
    
    public void RayTracing(IShape shape, CVector lightSource)
    {
        Screen.ClearScreen();
        
        foreach (var cell in GetScreenCells())
        {
            
            var intersection = shape.HasIntersection(Camera.StartPos, cell.clCenter - Camera.StartPos);
            
            if (intersection != null)
            {
                var n = (cell.clCenter - Camera.StartPos).MakeUnitVector().DotProduct(lightSource);
                var ch = n switch
                {
                    < 0 => ' ',
                    >= 0 and <= 0.2 => '.',
                    > 0.2 and <= 0.5 => '*',
                    > 0.5 and <= 0.8 => 'O',
                    > 0.8 => '#',
                    _ => throw new Exception("Ray Tracing switch out of range")
                };

                Screen.SetCell(cell.i, cell.j, ch);

            }
            else
            {
                Screen.SetCell(cell.i, cell.j, ' ');
            }
        }
        
        Screen.Show();
    }

    public IShape RayTracingNearest(List<IShape> shapes, CVector lightSource)
    {
        shapes.Sort((s1, s2) => s1.MinDistance(Camera.StartPos).CompareTo(s2.MinDistance(Camera.StartPos)));
        var shape = shapes.First();
        RayTracing(shape, lightSource);
        return shape;
    }*/
}