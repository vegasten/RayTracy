namespace RayTracing;

public record Vector3D(float X, float Y, float Z)
{
    public static Vector3D operator +(Vector3D a, Vector3D b) =>
        new Vector3D(b.X + a.X, b.Y + a.Y, b.Z + a.Z);

    public static Vector3D operator -(Vector3D a, Vector3D b) =>
        new Vector3D(b.X - a.X, b.Y - a.Y, b.Z - a.Z);

    public static float operator *(Vector3D a, Vector3D b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

    public static Vector3D operator *(float a, Vector3D b) =>
        new Vector3D(a * b.X, a * b.Y, a * b.Z);

    public static Vector3D operator /(Vector3D a, float b) =>
        new Vector3D(a.X / b, a.Y / b, a.Z / b);
}
