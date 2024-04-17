namespace CompGraphics.Objects.OtherObjects;

public class Screen
{
    public char[,] Cells { get; private set; }
    public int Width { get; }
    public int Height { get; }
    
    public Screen(int width, int height)
    {
        Width = width;
        Height = height;
        Cells = new char[height, width];
    }
    
    public void SetCell(int i, int j, char ch)
    {
        Cells[i, j] = ch;
    }
    
    public void Draw()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                Console.Write(Cells[i, j] + " ");
            } 
            Console.WriteLine();
        }
    }
}