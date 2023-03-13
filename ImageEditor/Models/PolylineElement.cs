using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor.Models
{
    public class PolylineElement : Figures
    {
        private string points;
        private string strokeColor;
        private int strokeThickness;


        public string Points
        {
            get => points;
            set => points = value;
        }
        public string StrokeColor
        {
            get => strokeColor;
            set => strokeColor = value;
        }
        public int StrokeThickness
        {
            get => strokeThickness;
            set => strokeThickness = value;
        }
    }
}
