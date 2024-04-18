
using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Objects.OtherObjects;

public class Camera
{
    public CPoint StartPos { get;}
    public CVector Direction { get;}
    public double DistanceToScreen { get;}

    public Camera(CPoint startPos, CVector direction, double distanceToScreen)
    {
        StartPos = startPos;
        Direction = direction;
        DistanceToScreen = distanceToScreen;
    }
    
}