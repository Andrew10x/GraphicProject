using System.Data.Common;
using CompGraphics.Results;

namespace CompGraphics.Image;

public class Pixel
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Pixel(double darkening, IntersectionResult? intersectionResult)
    {
        if (intersectionResult == null)
        {
            R = 40;
            G = 179;
            B = 170;
        }
        else
        {
            darkening = darkening switch
            {
                0 => 0.01f,
                < 0 => 0,
                _ => darkening
            };
            
            var value = (byte) (darkening * 255);
            R = value;
            G = value;
            B = value;
        }
    }
}