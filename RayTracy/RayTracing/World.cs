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
            ViewPlane.SetNumberOfSamples(25);
            _imageBuffer = new RGBColor[300, 200];

            ViewPlane.SetPixelSize(1f);
            ViewPlane.SetGamma(1f);

            BackgroundColor = new RGBColor(20, 20, 20);

            _tracer = new MultipleObjectsTracer(this);

            var sphere1 = new Sphere(new Point3D(0, 0, 0), 40, 0, RGBColor.Red);
            var sphere2 = new Sphere(new Point3D(0, -50, -20), 40, 0, RGBColor.Yellow);
            var plane = new Plane(Point3D.Zero(), new Vector3D(0, 1, 1), 0, RGBColor.Green);

            AddObject(sphere1);
            //AddObject(sphere2);
            //AddObject(plane);
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
            var random = new Random();

            int n = (int)MathF.Sqrt(ViewPlane.NumberOfSamples);

            for (int y = 0; y < ViewPlane.HeightRes; y++)
            {
                for (int x = 0; x < ViewPlane.WidthRes; x++)
                {
                    var pixelColorSum = RGBColor.Black;

                    var samplePointsUnitBox = ViewPlane.Sampler.GenerateSamples();

                    for (int j = 0; j < ViewPlane.NumberOfSamples; j++)
                    {
                        var samplePointX =
                            ViewPlane.PixelSize
                            * (x - 0.5f * ViewPlane.WidthRes + samplePointsUnitBox[j].X);
                        var samplePointY =
                            ViewPlane.PixelSize
                            * (y - 0.5f * ViewPlane.HeightRes + samplePointsUnitBox[j].Y);

                        ray.SetOrigin(new Point3D(samplePointX, samplePointY, -_cameraDistance));

                        pixelColorSum += _tracer.Trace(ray);
                    }

                    var averagePixelColor = pixelColorSum / ViewPlane.NumberOfSamples;
                    _imageBuffer[x, y] = averagePixelColor;
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
