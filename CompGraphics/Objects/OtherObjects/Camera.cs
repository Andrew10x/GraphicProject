
using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Objects.OtherObjects;

public class Camera
{
    public CPoint Start { get;}
    public CVector Direction { get;}
    public double DistanceToScreen { get;}

    public Camera(CPoint start, CVector direction, double distanceToScreen)
    {
        Start = start;
        Direction = direction;
        DistanceToScreen = distanceToScreen;
    }
}