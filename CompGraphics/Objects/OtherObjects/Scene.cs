
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphics.Objects.OtherObjects;

public class Scene
{
    public Screen Screen { get;}
    
    public Camera Camera { get; }
    
    public Scene()
    {
        Screen = new Screen(24, 24);

        var cameraStartPos = new CPoint(0, 0, 0);
        const double distFromCameraToScreen = 9.0;
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
}