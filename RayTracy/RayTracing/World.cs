namespace RayTracing
{
    public class World
    {
        public ViewPlane ViewPlane;
        public RGBColor BackgroundColor;
        public Sphere Sphere;

        private float _cameraDistance = 100f;
        private ITracer _tracer;

        private RGBColor[,] _imageBuffer;

        public void Build()
        {
            BackgroundColor = new RGBColor(52, 152, 235);
            ViewPlane = new ViewPlane();
            ViewPlane.SetWidthResolution(256);
            ViewPlane.SetHeightResolution(256);
            _imageBuffer = new RGBColor[256, 256];

            ViewPlane.SetPixelSize(1f);
            ViewPlane.SetGamma(1f);

            _tracer = new SingleSphereTracer(this);

            Sphere = new Sphere(Point3D.Zero(), 100.1f, 0f);
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

                    ray.SetOrigin(new Point3D(viewPlaneX, viewPlaneY, _cameraDistance));

                    var color = _tracer.Trace(ray);
                    _imageBuffer[x, y] = color;
                }
            }
        }

        public RGBColor[,] GetImageBuffer()
        {
            return _imageBuffer;
        }
    }
}
