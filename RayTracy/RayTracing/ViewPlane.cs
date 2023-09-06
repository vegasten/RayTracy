using System.ComponentModel.DataAnnotations;

namespace RayTracing
{
    public class ViewPlane
    {
        public int WidthRes { get; private set; }
        public int HeightRes { get; private set; }

        public float PixelSize { get; private set; }
        public float Gamma { get; private set; }
        public float InvertedGamma { get; private set; }

        public ISampler Sampler { get; private set; }

        public int NumberOfSamples { get; private set; }

        public void SetNumberOfSamples(int numberOfSamples)
        {
            if (numberOfSamples == 1)
            {
                Sampler = new RegularSampler(1);
            }
            else
            {
                Sampler = new JitteredSampler(numberOfSamples);
            }

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

        public void SetSampler(ISampler sampler)
        {
            Sampler = sampler;
        }

        public void SetSamples(int samples) { }
    }
}
