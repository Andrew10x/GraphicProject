
using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Objects.OtherObjects;

public class Camera
{
    public CPoint StartPos { get;}
    public CVector Direction { get; }
    public int Size { get; }
    public int Fov { get; }
    

    public Camera(CPoint startPos, CVector direction, int size, int fov)
    {
        StartPos = startPos;
        Direction = direction;
        Size = size;
        Fov = fov;
    }

    public Camera()
    {
        StartPos = new CPoint(0, 0, 0);
        Direction = new CVector(0, 0, -1);
        Size = 200;
        Fov = 65;
    }

    public CVector CreateRay(int i, int j)
    {
        return GetCell(i, j) - StartPos;
    }

    private CPoint GetCell(int i, int j)
    {
        var fScale = MathF.Tan(MathF.PI / 180f * Fov / 2);
        var x = (2 * (i + 0.5f) / Size - 1) * fScale;
        var y = (1 - 2 * (j + 0.5f) / Size) * fScale;

        return new CPoint(x, y, Direction.Z);
    }
    
}