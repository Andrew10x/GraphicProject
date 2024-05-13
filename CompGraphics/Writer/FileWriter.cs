using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using CompGraphics.Image;

namespace CompGraphics.Writer;

public class FileWriter: IWriter<Pixel>
{
    public string FilePath { get; }
    
    public FileWriter(string filePath)
    {
        FilePath = filePath;
    }
    
    public void Write(Image<Pixel> image)
    {
        var fileWriter = new StreamWriter(FilePath);
        fileWriter.WriteLine("P3");
        fileWriter.WriteLine($"{image.Size}  {image.Size}");
        fileWriter.WriteLine("255");
        
        for (var i = 0; i < image.Size; i++)
        {
            for (var j = 0; j < image.Size; j++)
            {
                fileWriter.WriteLine(image.Chars[i, j].R + " " + image.Chars[i, j].G + " " + image.Chars[i, j].B);
            }
        }
        fileWriter.Flush();
        fileWriter.Close();
    }
}