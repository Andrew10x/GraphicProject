using CompGraphics.Results;

namespace CompGraphics.Image;

public class FileImage: Image<Pixel>
{
    public FileImage(int size, TracingResult[,] tracingResults) : base(size)
    {
        MakeImage(tracingResults);
    }

    protected sealed override void MakeImage(TracingResult[,] tracingResults)
    {
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                var p = new Pixel(tracingResults[i, j].Darckening, tracingResults[i, j].InterRes);
                Chars[i, j] = p;
            }
        }
    }
}