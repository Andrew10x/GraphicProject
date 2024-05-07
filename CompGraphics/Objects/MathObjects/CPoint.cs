namespace CompGraphics.Objects.MathObjects;

public class CPoint
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    
    public CPoint(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public static CVector operator -(CPoint point1, CPoint point2)
    {
        return new CVector(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);
    }
    
    public static CPoint operator +(CPoint point, CVector vector)
    {
        return new CPoint(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);
    }

    public static CPoint operator -(CPoint point, CVector vector)
    {
        return new CPoint(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
    }

    public void Show()
    {
        Console.WriteLine("(" + X + ", " + Y + ", " + Z + ")");
    }
    
    public bool IsEqual(CPoint point2, double eps = 0.005)
    {
        return Math.Abs(X - point2.X) < eps &&
               Math.Abs(Y - point2.Y) < eps &&
               Math.Abs(Z - point2.Z) < eps;
    }

    public double MinDistance(CPoint point)
    {
        return Math.Sqrt((point.X - X)*(point.X - X) + (point.Y - Y)*(point.Y - Y) + (point.Z - Z)*(point.Z - Z));
    }

}