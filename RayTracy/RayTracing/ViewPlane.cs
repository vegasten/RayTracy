namespace RayTracing
{
    public class ViewPlane
    {
        public int WidthRes { get; private set; }
        public int HeightRes { get; private set; }

        public float PixelSize { get; private set; }
        public float Gamma { get; private set; }
        public float InvertedGamma { get; private set; }
        public int NumberOfSamples { get; private set; } // Should be square

        public void SetNumberOfSamples(int numberOfSamples)
        {
            NumberOfSamples = numberOfSamples;
        }

        public void SetWidthResolution(int widthRes)
        {
            WidthRes = widthRes;
        }

        public void SetHeightResolution(int heightRes)
        {
            HeightRes = heightRes;
        }

        public void SetPixelSize(float pixelSize)
        {
            PixelSize = pixelSize;
        }

        public void SetGamma(float gamma)
        {
            Gamma = gamma;
            InvertedGamma = 1f / gamma;
        }
    }
}
