namespace RayTracing;

public class Sphere : IGeometricObject
{
    private Point3D _center;
    private float _radius;
    private double _kEpsilon;

    public Sphere(Point3D center, float radius, double kEpsilon)
    {
        _center = center;
        _radius = radius;
        _kEpsilon = kEpsilon;
    }

    public bool IsHit(Ray ray, ref float tMin, ref HitRecording hitRecording)
    {
        float t;
        Vector3D temp = ray.Origin - _center;
        float a = ray.Direction * ray.Direction;
        float b = 2 * temp * ray.Direction;
        float c = temp * temp - _radius * _radius;
        float disc = b * b - 4 * a * c;

        if (disc < 0)
        {
            return false;
        }

        float e = MathF.Sqrt(disc);
        float denom = 2.0f * a;
        t = (-b - e) / denom;

        if (t > _kEpsilon)
        {
            tMin = t;
            hitRecording.Normal = (temp + t * ray.Direction) / _radius;
            hitRecording.LocalHitPoint = ray.Origin + t * ray.Direction;
            return true;
        }

        t = (-b + e) / denom;

        if (t > _kEpsilon)
        {
            tMin = t;
            hitRecording.Normal = (temp + t * ray.Direction) / _radius;
            hitRecording.LocalHitPoint = ray.Origin + t * ray.Direction;
            return true;
        }

        return false;
    }
}
