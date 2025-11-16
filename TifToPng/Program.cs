using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;

namespace TifToPng
{
    class Program
    {
        static void Main(string[] argsArray)
        {
            List<string> args = new List<string>(argsArray);

            if (args.Count < 1)
            {
                Console.WriteLine("Not enough arguments supplied");
                return;
            }

            string filePath = args[0];

            bool hasTifExtension = Path.GetExtension(filePath) == ".tif";
            if (!hasTifExtension)
            {
                Console.WriteLine("Only tif files can be supplied as an argument");
                return;
            }

            bool fileExists = File.Exists(filePath);
            if (fileExists)
            {
                try
                {
                    string newFilePath = Path.ChangeExtension(filePath, ".png");
                    using (var image = new MagickImage(filePath))
                    {
                        image.Write(newFilePath); // Magick.NET detects output format from extension
                    }
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
