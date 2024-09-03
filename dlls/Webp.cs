using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebpConverter.dlls
{
    internal static class Webp
    {
        public delegate void refreshCounter(string file);
        public static event refreshCounter? _refreshCounter;

        public static void Convert(int _x, int _y, WebpEncodingMethod method, string directory, params string[] files)
        {
            int _counter = 0;

            Parallel.ForEach(files, (i) =>
            {
                try
                {
                    using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(i))
                    {
                        image.Mutate(x => x.Resize(_x, _y));

                        string webp = Path.Combine(directory, "webp");

                        Directory.CreateDirectory(webp);

                        image.Save(Path.Combine(directory, webp, Path.GetFileNameWithoutExtension(i) + @".webp"), new WebpEncoder()
                        {
                            Quality = 0,
                            Method = method,
                            NearLossless = false
                        });
                    }

                    _refreshCounter?.Invoke(i);
                } catch { RTConsole.Write($"{++_counter}:{i} is not image or damaged!", System.Drawing.Color.Red); }
            });
        }
    }
}
