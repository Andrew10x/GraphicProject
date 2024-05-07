namespace CompGraphics.Objects;

public class TransformMatrix
{
    public float[,]? Matrix { get; private set; }
    public int Size { get; }


    public TransformMatrix()
    {
        Size = 4;
    }

    public TransformMatrix(float[,] matrix)
    {
        Matrix = matrix;
        Size = 4;
    }

    public void CreateTranslationMatrix(float tx, float ty, float tz)
    {
        Matrix = new float[,]
            {{1, 0, 0, tx},
            {0, 1, 0, ty},
            {0, 0, 1, tz},
            {0, 0, 0, 1}};
    }

    public void CreateScaleMatrix(float sx, float sy, float sz)
    {
        Matrix = new float[,]
            {{sx, 0, 0, 0},
            {0, sy, 0, 0},
            {0, 0, sz, 0},
            {0, 0, 0, 1}};
    }

    public void CreateRotateXMatrix(float angle)
    {
        angle *= (MathF.PI / 180f);
        var sin = MathF.Sin(angle);
        var cos = MathF.Cos(angle);
        Matrix = new float[,]
            {{1, 0, 0, 0},
            {0, cos, -sin, 0},
            {0, sin, cos, 0},
            {0, 0, 0, 1}};
    }
    
    public void CreateRotateYMatrix(float angle)
    {
        angle *= (MathF.PI / 180f);
        var sin = MathF.Sin(angle);
        var cos = MathF.Cos(angle);
        Matrix = new float[,]
            {{cos, 0, sin, 0},
            {0, 1, 0, 0},
            {-sin, 0, cos, 0},
            {0, 0, 0, 1}};
    }
    
    
    public void CreateRotateZMatrix(float angle)
    {
        angle *= (MathF.PI / 180f);
        var sin = MathF.Sin(angle);
        var cos = MathF.Cos(angle);
        Matrix = new float[,]
            {{cos, -sin, 0, 0},
            {sin, cos, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}};
    }

    public static TransformMatrix operator *(TransformMatrix tm1, TransformMatrix tm2)
    {
        var tmRes = new float[tm1.Size, tm1.Size];

        for (var i = 0; i < tm1.Size; i++)
        {
            for (var j = 0; j < tm1.Size; j++)
            {
                tmRes[i, j] = 0;

                for (var k = 0; k < tm1.Size; k++)
                {
                    tmRes[i, j] += tm1.Matrix![i, k] * tm2.Matrix![k, j];
                }
            }
        }

        return new TransformMatrix(tmRes);
    }

    public bool Equals(TransformMatrix tm2)
    {
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                if (Math.Abs(Matrix![i, j] - tm2.Matrix![i, j]) > ProjConstants.ProjConstants.EPSILON)
                    return false;
            }
        }

        return true;
    }
}