namespace RayTracing;

public class Ray
{
    public Point3D Origin { get; private set; }
    public Vector3D Direction { get; }

    public Ray(Point3D origin, Vector3D direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public void SetOrigin(Point3D origin)
    {
        Origin = origin;
    }

    public void SetOrigin(Point2D origin, float Z)
    {
        Origin = new Point3D(origin.X, origin.Y, Z);
    }
}
