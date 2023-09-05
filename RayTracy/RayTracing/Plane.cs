namespace RayTracing;

public class Plane : IGeometricObject
{
    private Point3D _point; // point on the plane
    private Vector3D _normal;
    private double _kEpsilon;
    private RGBColor _color;

    public Plane(Point3D point, Vector3D normal, double kEpsilon, RGBColor color)
    {
        _point = point;
        _normal = normal;
        _kEpsilon = kEpsilon;
        _color = color;
    }

    public RGBColor GetColor()
    {
        return _color;
    }

    public bool IsHit(Ray ray, ref float tMin, ref HitRecording hitRecording)
    {
        float t = (_point - ray.Origin) * _normal / (ray.Direction * _normal);

        if (t > _kEpsilon)
        {
            tMin = t;
            hitRecording.Normal = _normal;
            hitRecording.LocalHitPoint = ray.Origin + t * ray.Direction;
            return true;
        }

        return false;
    }
}
