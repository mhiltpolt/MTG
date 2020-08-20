using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace MTG.CardMoth.Utils
{
    public static class ImageConverter
    {
        public static byte[] SvgToPng(byte[] buffer)
        {
            Bitmap bitmap;
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(stream);
                bitmap = svgDocument.Draw();

            }
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
