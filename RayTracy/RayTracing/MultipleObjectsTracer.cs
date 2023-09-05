namespace RayTracing;

public class MultipleObjectsTracer : ITracer
{
    private World _world;

    public MultipleObjectsTracer(World world)
    {
        _world = world;
    }

    public RGBColor Trace(Ray ray)
    {
        var hitRecording = _world.HitBareBonesObjects(ray);

        if (hitRecording.DidHit)
        {
            return hitRecording.Color;
        }
        else
        {
            return _world.BackgroundColor;
        }
    }
}
