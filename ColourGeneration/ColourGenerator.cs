using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColourGeneration
{
    public static class ColorGenerator
    {
        public static Color FromIndex(int index)
        {
            byte red = 0;
            byte green = 0;
            byte blue = 0;

            red = CalculateColor(index, -256, 256, 512, 1024);
            green = CalculateColor(index, 256, 768, 1024, 0);
            blue = CalculateColor(index, 768, 1280, 0, 512);

            return Color.FromArgb(0, red, green, blue);
        }

        private static byte CalculateColor(int index, int fullColorStart, int rampDownStart, int noColorStart, int rampUpStart)
        {
            if (index >= fullColorStart && index < fullColorStart + 512)
            {
                return 255;
            }

            if (index >= rampDownStart && index < rampDownStart + 256)
            {
                return (byte)(rampDownStart + 255 - index);
            }

            if (index >= rampUpStart && index < rampUpStart + 256)
            {
                return (byte)(index - rampUpStart);
            }

            if (index >= noColorStart && index < noColorStart + 512)
            {
                return 0;
            }

            if (fullColorStart < 0
                && index >= fullColorStart + 1536 && index < 1536)
            {
                return 255;
            }

            throw new IndexOutOfRangeException(index + " is out of known range");
        }
    }
}
