namespace RayTracing;

public class HitRecording
{
    public bool DidHit { get; set; }
    public Point3D LocalHitPoint { get; set; }
    public Vector3D Normal { get; set; }
    public Color Color { get; set; }


}

