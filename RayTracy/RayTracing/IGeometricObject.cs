namespace RayTracing;

public interface IGeometricObject
{
    RGBColor GetColor();
    public bool IsHit(Ray ray, ref float tMin, ref HitRecording hitRecording);
}
