using CompGraphics.Results;

namespace CompGraphics.Image;

public abstract class Image<TP>
{
    public int Size { get; }
    public TP[,] Chars { get;}
    
    protected Image(int size)
    {
        Size = size;
        Chars = new TP[size, size];
    } 
    protected abstract void MakeImage(TracingResult[,] tracingResults);
}