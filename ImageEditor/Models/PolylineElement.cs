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
        private int strokeNum;
        private int strokeThickness;


        public string Points
        {
            get => points;
            set => points = value;
        }
        public int StrokeNum
        {
            get => strokeNum;
            set => strokeNum = value;
        }
        public int StrokeThickness
        {
            get => strokeThickness;
            set => strokeThickness = value;
        }
    }
}
