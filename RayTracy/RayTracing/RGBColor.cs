namespace RayTracing;

public record RGBColor(float R, float G, float B)
{
    public static RGBColor Yellow = new RGBColor(255, 255, 0);
    public static RGBColor Red = new RGBColor(255, 0, 0);
    public static RGBColor Green = new RGBColor(0, 255, 0);
    public static RGBColor Blue = new RGBColor(0, 0, 255);
    public static RGBColor Black = new RGBColor(0, 0, 0);
    public static RGBColor White = new RGBColor(255, 255, 255);

    public string ToPPMFormat()
    {
        return $"{R} {G} {B}";
    }

    public static RGBColor operator +(RGBColor a, RGBColor b) =>
        new RGBColor(a.R + b.R, a.G + b.G, a.B + b.B);

    public static RGBColor operator *(RGBColor a, RGBColor b) =>
        new RGBColor(a.R * b.R, a.G * b.G, a.B * b.B);

    public static RGBColor operator *(float a, RGBColor b) =>
        new RGBColor(a * b.R, a * b.G, a * b.B);

    public static RGBColor operator /(RGBColor a, float b) =>
        new RGBColor(a.R / b, a.G / b, a.B / b);
}

public static class ColorExtensions
{
    public static bool Equal(this RGBColor c1, RGBColor c2) =>
        c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
}
