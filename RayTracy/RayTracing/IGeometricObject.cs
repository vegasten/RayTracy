namespace RayTracing;

public interface IGeometricObject
{
    public bool IsHit(Ray ray, ref float tMin, ref HitRecording hitRecording);
}

