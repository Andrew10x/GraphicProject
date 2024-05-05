using CompGraphics.Results;

namespace CompGraphics.Image;

public class ConsoleImage: Image<char>
{

    public ConsoleImage(int size, TracingResult[,] tracingResults) : base(size)
    {
        MakeImage(tracingResults);
    }
    
    protected sealed override void MakeImage(TracingResult[,] tracingResults)
    {
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                var n = tracingResults[i, j].Darckening;
                var ch = n switch
                {
                    < 0 => ' ',
                    >= 0 and <= 0.2 => '.',
                    > 0.2 and <= 0.5 => '*',
                    > 0.5 and <= 0.8 => 'O',
                    > 0.8 => '#',
                    _ => throw new Exception("Ray Tracing switch out of range")
                };
                Chars[i, j] = ch;
            }
        }
    }
    
}