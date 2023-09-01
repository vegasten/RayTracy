namespace RayTracing;

public record Color(float R, float G, float B)
{

    public static Color operator +(Color a, Color b) => new Color(a.R + b.R, a.G + b.G, a.B + b.B);
    public static Color operator *(Color a, Color b) => new Color(a.R * b.R, a.G * b.G, a.B * b.B);

    public static Color operator *(float a, Color b) => new Color(a * b.R, a * b.G, a * b.B);
    public static Color operator /(Color a, float b) => new Color(a.R / b, a.G / b, a.B / b);

}

public static class ColorExtensions
{
    public static bool Equal(this Color c1, Color c2) => c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
}

