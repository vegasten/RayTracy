using RayTracing;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting creating image...");

        World world = new World();
        world.Build();
        world.RenderScene();
        var result = world.GetImageBuffer();

        PPMFileWriter.Write(result);

        Console.WriteLine("Image done and written to file! :)");
    }
}
