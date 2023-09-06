using System;

namespace RayTracing;

public class RegularSampler : ISampler
{
    public int NumberOfSets { get; set; }

    private int _numberOfSamples = 0;

    public RegularSampler(int numberOfSamples)
    {
        _numberOfSamples = numberOfSamples;
        NumberOfSets = 1;
    }

    public Point2D[] GenerateSamples()
    {
        var samplePointList = new List<Point2D>();

        int n = (int)MathF.Sqrt(_numberOfSamples);

        for (int pixel = 0; pixel < NumberOfSets; pixel++)
        {
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    var samplePointX = (x + 0.5f) / n;
                    var samplePointY = (y + 0.5f) / n;

                    samplePointList.Add(new Point2D(samplePointX, samplePointY));
                }
            }
        }

        return samplePointList.ToArray();
    }
}
