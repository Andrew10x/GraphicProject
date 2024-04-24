
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphics.Objects.OtherObjects;

public class Scene
{
    public Screen Screen { get;}
    
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
    
    public void RayTracing(Sphere sphere)
    {
        Screen.ClearScreen();
        
        foreach (var cell in GetScreenCells())
        {
            var intersection = sphere.HasIntersection(Camera.StartPos, cell.clCenter - Camera.StartPos);
            char ch = ' ';
            if(intersection != null) 
                ch = '#';
            Screen.SetCell(cell.i, cell.j, ch);

        }

        Screen.Show();
    }
    
    public void RayTracing(Sphere sphere, CVector lightSource)
    {
        Screen.ClearScreen();
        
        foreach (var cell in GetScreenCells())
        {
            
            var intersection = sphere.HasIntersection(Camera.StartPos, cell.clCenter - Camera.StartPos);
            
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
}