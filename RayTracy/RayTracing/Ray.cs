namespace RayTracing;

public class Ray
{
    public Ray(Point3D origin, Vector3D direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public Point3D Origin { get; }
    public Vector3D Direction { get; }
}

