namespace RayTracing;

public record Point3D(float X, float Y, float Z)
{
    public static Vector3D operator -(Point3D a, Point3D b) =>
        new Vector3D(b.X - a.X, b.Y - a.Y, b.Z - a.Z);

    public static Point3D operator +(Point3D a, Vector3D b) =>
        new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

    public static Point3D Zero()
    {
        return new Point3D(0.0f, 0.0f, 0.0f);
    }
}
