using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            

            long totalTime = 0;
            int times = 10;
            for (int i = 0; i < times; i++)
            {
                ImageProcess imageProcess = new ImageProcess();

                imageProcess.Clean(destinationPath);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
                sw.Stop();

                Console.WriteLine($"花費時間: {sw.ElapsedMilliseconds} ms");
                totalTime += sw.ElapsedMilliseconds;

                GC.Collect();
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"平均花費時間: {totalTime/times} ms");
        }
    }
}
