namespace RayTracing;

public class JitteredSampler : ISampler
{
    public int NumberOfSets { get; set; }

    private int _numberOfSamples;

    public JitteredSampler(int numberOfSamples)
    {
        _numberOfSamples = numberOfSamples;
        NumberOfSets = 1;
    }

    public Point2D[] GenerateSamples()
    {
        var samplePointList = new List<Point2D>();
        var random = new Random();

        int n = (int)MathF.Sqrt(_numberOfSamples);

        for (int pixel = 0; pixel < NumberOfSets; pixel++)
        {
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    var samplePointX = (x + (float)random.NextDouble()) / n;
                    var samplePointY = (y + (float)random.NextDouble()) / n;

                    samplePointList.Add(new Point2D(samplePointX, samplePointY));
                }
            }
        }

        return samplePointList.ToArray();
    }
}
