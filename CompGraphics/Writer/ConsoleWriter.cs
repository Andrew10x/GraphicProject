namespace CompGraphics.Writer;

public class ConsoleWriter: IWriter<char>
{
    public void Write(Image.Image<char> image)
    {
        for (var i = 0; i < image.Size; i++)
        {
            for (var j = 0; j < image.Size; j++)
            {
                Console.Write(image.Chars[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}