using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Models
{
    public static class Converters
    {
        public static string BrushToString(SolidColorBrush brush)
        {
            return brush.ToString();
        }

        public static SolidColorBrush StringToBrush(string str)
        {
            return new SolidColorBrush(Avalonia.Media.Color.Parse(str));
        }
    }
}
