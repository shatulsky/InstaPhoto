using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;

namespace InstaPhoto
{
    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Windows only")]
    public static class Program
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static void Main()
        {
            var files = Directory.EnumerateFiles(Path.Combine(BaseDirectory, "in")).ToArray();
            
            for (var i = 0; i < files.Length; i+=2)
            {
                using var file1 = Image.FromFile(files.ElementAt(i));
                using var file2 = Image.FromFile(files.ElementAt(i+1));
                using var result = new Bitmap(1750, 1166);
                using var g = Graphics.FromImage(result);
                
                g.FillRegion(new SolidBrush(Color.DarkGray), new Region(new Rectangle(0, 0, 1750, 1166)));
                g.DrawImage(file1, 0, 71, 866, 1024);
                g.DrawImage(file2, 884, 71, 866, 1024);

                result.Save(Path.Combine(BaseDirectory, $"{i}{i+1}.png"));
            }
        }
    }
}
