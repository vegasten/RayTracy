namespace RayTracing
{
    public class PPMFileWriter
    {
        public static void Write(RGBColor[,] colorBuffer)
        {
            int imageWidth = colorBuffer.GetLength(0);
            int imageHeight = colorBuffer.GetLength(1);

            string fileLocation = "C:\\Output\\test.ppm";
            var writer = new StreamWriter(fileLocation);

            // HEADER
            writer.WriteLine("P3");
            writer.WriteLine($"{imageWidth} {imageHeight}");
            writer.WriteLine(255);

            // BODY
            for (int x = 0; x < imageHeight; x++)
            {
                for (int y = 0; y < imageWidth; y++)
                {
                    writer.WriteLine(colorBuffer[x, y].ToPPMFormat());
                }
            }
            writer.Close();
        }
    }
}
