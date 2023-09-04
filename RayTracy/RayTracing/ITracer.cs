namespace RayTracing;

public interface ITracer
{
    RGBColor Trace(Ray ray);
}
