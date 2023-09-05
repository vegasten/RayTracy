namespace RayTracing
{
    public class World
    {
        public ViewPlane ViewPlane;
        public RGBColor BackgroundColor;
        public Sphere Sphere;
        public List<IGeometricObject> GeometricObjects = new List<IGeometricObject>();

        private float _cameraDistance = 200f;
        private ITracer _tracer;

        private RGBColor[,] _imageBuffer;

        public void Build()
        {
            ViewPlane = new ViewPlane();
            ViewPlane.SetWidthResolution(300);
            ViewPlane.SetHeightResolution(200);
            _imageBuffer = new RGBColor[300, 200];

            ViewPlane.SetPixelSize(1f);
            ViewPlane.SetGamma(1f);

            BackgroundColor = new RGBColor(20, 20, 20);

            _tracer = new MultipleObjectsTracer(this);

            var sphere1 = new Sphere(new Point3D(0, 0, 0), 40, 0, new RGBColor(255, 0, 0));
            var sphere2 = new Sphere(new Point3D(0, -50, -20), 40, 0, new RGBColor(255, 255, 0));

            AddObject(sphere1);
            AddObject(sphere2);
        }

        private void BuildSingleRedSphere()
        {
            BackgroundColor = new RGBColor(52, 152, 235);
            ViewPlane = new ViewPlane();
            ViewPlane.SetWidthResolution(256);
            ViewPlane.SetHeightResolution(256);
            _imageBuffer = new RGBColor[256, 256];

            ViewPlane.SetPixelSize(1f);
            ViewPlane.SetGamma(1f);

            _tracer = new SingleSphereTracer(this);

            Sphere = new Sphere(Point3D.Zero(), 100.1f, 0f, new RGBColor(255, 0, 0));
        }

        public void RenderScene()
        {
            var ray = new Ray(Point3D.Zero(), new Vector3D(0, 0, -1f));

            for (int y = 0; y < ViewPlane.HeightRes; y++)
            {
                for (int x = 0; x < ViewPlane.WidthRes; x++)
                {
                    float viewPlaneX =
                        ViewPlane.PixelSize * (x - 0.5f * (ViewPlane.WidthRes - 1.0f));

                    float viewPlaneY =
                        ViewPlane.PixelSize * (y - 0.5f * (ViewPlane.HeightRes - 1.0f));

                    ray.SetOrigin(new Point3D(viewPlaneX, viewPlaneY, -_cameraDistance)); // TODO, Minus here?????

                    var color = _tracer.Trace(ray);
                    _imageBuffer[x, y] = color;
                }
            }
        }

        public void AddObject(IGeometricObject geometricObject)
        {
            GeometricObjects.Add(geometricObject);
        }

        public RGBColor[,] GetImageBuffer()
        {
            return _imageBuffer;
        }

        public HitRecording HitBareBonesObjects(Ray ray)
        {
            float t = 0;
            float tmin = float.MaxValue;
            HitRecording hitRecording = new HitRecording();

            for (int i = 0; i < GeometricObjects.Count; i++)
            {
                if (GeometricObjects[i].IsHit(ray, ref t, ref hitRecording) && t < tmin)
                {
                    hitRecording.DidHit = true;
                    tmin = t;
                    hitRecording.Color = GeometricObjects[i].GetColor();
                }
            }

            return hitRecording;
        }
    }
}
