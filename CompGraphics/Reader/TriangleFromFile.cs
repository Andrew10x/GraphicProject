using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Reader;

public class TriangleFromFile
{
    public int P1Pos { get; }
    public int P2Pos { get; }
    public int P3Pos { get; }
    
    public int N1Pos { get; }
    public int N2Pos { get; }
    public int N3Pos { get; }

    public TriangleFromFile(int p1Pos, int p2Pos, int p3Pos, int n1Pos, int n2Pos, int n3Pos)
    {
        P1Pos = p1Pos;
        P2Pos = p2Pos;
        P3Pos = p3Pos;
        
        N1Pos = n1Pos;
        N2Pos = n2Pos;
        N3Pos = n3Pos;
    }

    public Triangle GetTriangle(List<CPoint> points, List<CVector> normals)
    {
        return new Triangle(points[P1Pos], points[P2Pos], points[P3Pos], normals[N1Pos], 
            normals[N2Pos], normals[N3Pos]);
    }
}