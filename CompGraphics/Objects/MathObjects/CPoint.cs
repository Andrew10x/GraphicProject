namespace CompGraphics.Objects.MathObjects;

public class CPoint
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    
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
    
    public bool IsEqual(CPoint point2, double eps=ProjConstants.ProjConstants.EPSILON)
    {
        return Math.Abs(X - point2.X) < eps &&
               Math.Abs(Y - point2.Y) < eps &&
               Math.Abs(Z - point2.Z) < eps;
    }

    public double MinDistance(CPoint point)
    {
        return Math.Sqrt((point.X - X)*(point.X - X) + (point.Y - Y)*(point.Y - Y) + (point.Z - Z)*(point.Z - Z));
    }
    
    public void Transform(TransformMatrix tm)
    {
        var x = X;
        var y = Y;
        var z = Z;
        X = tm.Matrix![0,0] * x + tm.Matrix![0,1] * y + tm.Matrix![0,2] * z + tm.Matrix[0, 3];
        Y = tm.Matrix![1,0] * x + tm.Matrix![1,1] * y + tm.Matrix![1,2] * z + tm.Matrix[1, 3];
        Z = tm.Matrix![2,0] * x + tm.Matrix![2,1] * y + tm.Matrix![2,2] * z + tm.Matrix[2, 3];
    }

}