namespace CompGraphics.Objects.MathObjects;

public class CVector
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    
    public CVector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public void Show()
    {
        Console.WriteLine("(" + X + ", " + Y + ", " + Z + ")");
    }
    
    public static CVector operator +(CVector v1, CVector v2) {
        return new CVector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }
    
    public static CVector operator -(CVector v1, CVector v2) {
        return new CVector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }
    public static CVector operator *(CVector v, double d) {
        return new CVector(v.X * d, v.Y * d, v.Z * d);
    }
    
    public static CVector operator -(CVector v1) {
        return new CVector(-1*v1.X, -1*v1.Y, -1*v1.Z);
    }
    
    public double DotProduct(CVector vector)
    {
        return X * vector.X + Y * vector.Y + Z * vector.Z;
    }
    
    public CVector CrossProduct(CVector vector)
    {
        return new CVector(
            Y * vector.Z - Z * vector.Y,
            Z * vector.X - X * vector.Z,
            X * vector.Y - Y * vector.X
        );
    }

    public bool IsEqual(CVector vector2, double eps = 0.005)
    {
        return Math.Abs(X - vector2.X) < eps &&
               Math.Abs(Y - vector2.Y) < eps &&
               Math.Abs(Z - vector2.Z) < eps;
    }
    
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    
    public CVector MakeUnitVector()
    {
        var length = Length();
        X /= length;
        Y /= length;
        Z /= length;
        return this * (1 / Length());
    }
    
    public void Transform(TransformMatrix tm)
    {
        var x = X;
        var y = Y;
        var z = Z;
        X = tm.Matrix![0,0] * x + tm.Matrix![0,1] * y + tm.Matrix![0,2] * z;
        Y = tm.Matrix![1,0] * x + tm.Matrix![1,1] * y + tm.Matrix![1,2] * z;
        Z = tm.Matrix![2,0] * x + tm.Matrix![2,1] * y + tm.Matrix![2,2] * z;
    }
}