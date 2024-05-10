using System.Globalization;
using CompGraphics.Objects.MathObjects;

namespace CompGraphics.Reader;

public class FileReader
{

    public DataFromFile ReadFromFile(string filePath)
    {
        var points = new List<CPoint>();
        var normals = new List<CVector>();
        var trianglesFromFile = new List<TriangleFromFile>();
        
        foreach (var line in File.ReadLines(filePath))
        {  
            var lineParts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (lineParts.Length != 0) {
                if(lineParts[0] == "v")
                    points.Add(GetVertex(lineParts));
                else if(lineParts[0] == "vn")
                    normals.Add(GetNormal(lineParts));
                else if(lineParts[0] == "f")
                    trianglesFromFile.Add(GetTriangleFromFile(lineParts));
            }
        }

        return new DataFromFile(trianglesFromFile, points, normals);
    }

    private CPoint GetVertex(string[] lineParts)
    {
        return new CPoint(Convert.ToDouble(lineParts[1], CultureInfo.InvariantCulture),
            Convert.ToDouble(lineParts[2], CultureInfo.InvariantCulture), Convert.ToDouble(lineParts[3], 
                CultureInfo.InvariantCulture));
    }

    private CVector GetNormal(string[] lineParts)
    {
        return new CVector(Convert.ToDouble(lineParts[1], CultureInfo.InvariantCulture), 
            Convert.ToDouble(lineParts[2], CultureInfo.InvariantCulture), Convert.ToDouble(lineParts[3],
                CultureInfo.InvariantCulture));
    }

    private TriangleFromFile GetTriangleFromFile(string[] lineParts)
    {
        var points = new List<int>();
        var texture = new List<int>();
        var normals = new List<int>();
        for (var i = 1; i < lineParts.Length; i++)
        {
            var triangleParts = lineParts[i].Split("/");
         
            points.Add(Convert.ToInt32(triangleParts[0]) - 1);
            normals.Add(Convert.ToInt32(triangleParts[2]) - 1);
        }
        return new TriangleFromFile(points[0], points[1], points[2], normals[0], normals[1], normals[2]);
    }

}