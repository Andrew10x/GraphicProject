namespace CompGraphics.Writer;

public interface IWriter<TP>
{
    public void Write(Image.Image<TP> image);
}