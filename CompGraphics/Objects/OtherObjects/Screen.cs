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
    
    public void Show()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                Console.Write(Cells[i, j] + " ");
            } 
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void Show2()
    {
        for (var i = 0; i < Height; i++)
        {
            Console.Write("{");
            for (var j = 0; j < Width; j++)
            {
                if(j != Width -1)
                    Console.Write("'" + Cells[i, j] + "'" + ", ");
                else
                    Console.Write("'" + Cells[i, j] + "'" + " ");
            } 
            if(i != Height -1)
                Console.WriteLine("},");
            else
                Console.WriteLine('}');
        }
        Console.WriteLine();
    }

    public void ClearScreen()
    {
        Cells = new char[Height, Width];
    }
}