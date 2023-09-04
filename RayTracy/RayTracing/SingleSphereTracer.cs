namespace RayTracing;

public class SingleSphereTracer : ITracer
{
    private World _world;
    private float _tMin = 0;
    private HitRecording _recording;

    public SingleSphereTracer(World world)
    {
        _world = world;
        _recording = new HitRecording();
    }

    public RGBColor Trace(Ray ray)
    {
        if (_world.Sphere.IsHit(ray, ref _tMin, ref _recording))
        {
            return new RGBColor(255, 0, 0);
        }
        else
        {
            return _world.BackgroundColor;
        }
    }
}
