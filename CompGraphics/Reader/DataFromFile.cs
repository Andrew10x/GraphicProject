using CompGraphics.Objects;
using CompGraphics.Objects.MathObjects;
using CompGraphics.Objects.Shapes;

namespace CompGraphics.Reader;

public class DataFromFile
{
    public List<TriangleFromFile> TrianglesFromFile { get; }
    public List<CPoint> Points { get; }
    public List<CVector> Normals { get; }

    public DataFromFile(List<TriangleFromFile> trianglesFromFile, List<CPoint> points, List<CVector> normals)
    {
        TrianglesFromFile = trianglesFromFile;
        Points = points;
        Normals = normals;
    }

    public List<IShape> GetAllTriangles()
    {
        var triangles = new List<IShape>();
        foreach (var t in TrianglesFromFile)
        {
            triangles.Add(t.GetTriangle(Points, Normals));
        }

        return triangles;
    }
    
    public void Transform(TransformMatrix tm)
    {
        foreach (var normal in Normals)
        {
            normal.Transform(tm);
            normal.MakeUnitVector();
        }
        
        foreach (var vertex in Points)
        {
            vertex.Transform(tm);
        }
    }
}