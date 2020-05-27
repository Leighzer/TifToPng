using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace TifToPng
{
    class Program
    {
        static void Main(string[] argsArray)
        {
            List<string> args = new List<string>(argsArray);

            if(args.Count < 1)
            {
                Console.WriteLine("Not enough arguments supplied");
                return;
            }

            string filePath = args[0];

            bool fileExists = File.Exists(filePath);
            if (fileExists)
            {
                try
                {
                    string newfilePath = Path.ChangeExtension(filePath, ".png");
                    System.Drawing.Bitmap.FromFile(filePath).Save(newfilePath, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine("Success! Png created!");
                }
                catch
                {
                    Console.WriteLine("Tif to png translation failed");
                }
                
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}
