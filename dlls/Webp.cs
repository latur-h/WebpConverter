using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.PixelFormats;
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

        public static void Convert(int _x, int _y, int quality, WebpEncodingMethod method, string directory, params string[] files)
        {
            int _counter = 0;

            Parallel.ForEach(files, (i) =>
            {
                try
                {
                    using (SixLabors.ImageSharp.Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(i))
                    {
                        image.Mutate(x => x.Resize(_x, _y));

                        string webp = Path.Combine(directory, "webp");

                        Directory.CreateDirectory(webp);

                        image.Save(Path.Combine(directory, webp, Path.GetFileNameWithoutExtension(i) + @".webp"), new WebpEncoder()
                        {
                            Quality = quality,
                            Method = method,
                            NearLossless = false,
                            FileFormat = WebpFileFormatType.Lossy,
                            SkipMetadata = true
                        });
                    }

                    _refreshCounter?.Invoke(i);
                } catch { RTConsole.Write($"{++_counter}:{i} is not image or damaged!", System.Drawing.Color.Red); }
            });
        }
    }
}
