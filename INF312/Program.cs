using ScottPlot;
using System.Drawing;

namespace INF312
{
    public class Program
    {
        public static string GetFilename(string path, int firstId)
        {
            string filename = "img"+firstId+".jpg";
            
            filename = Path.Combine(path, filename);

            if (File.Exists(filename))
            {
                firstId += 1;
                return GetFilename(path, firstId);
            }
            Console.WriteLine("Image sauvegardée : img"+firstId+".jpg");
            return filename;

        }
        public static void Main(string[] args)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "INF312_IMG");
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filename = GetFilename(path, 1);

            var plt = new Plot();

            var dataX = new double[] { 1, 2, 3, 4, 5 };
            var dataY = new double[] { 1, 4, 9, 16, 25 };

            plt.Add.Scatter(dataX, dataY);

            plt.Title("Simple Plot");
            plt.XLabel("X");
            plt.YLabel("Y");

            plt.Save(filename, 900, 800);
    
            Console.WriteLine($"Image générée avec succès dans {path}");
        }
    }
}