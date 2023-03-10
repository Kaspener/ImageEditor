using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ImageEditor.Models
{
    public class Line : Figures
    {
        private string startPoint;
        private string endPoint;
        private string colorLine;
        private int thicknessLine;

        public string StartPoint
        {
            get => startPoint;
            set => startPoint = value;
        }

        public string EndPoint
        {
            get => endPoint;
            set => endPoint = value;
        }

        public string ColorLine
        {
            get => colorLine;
            set => colorLine = value;
        }
        public int ThicknessLine
        {
            get => thicknessLine;
            set => thicknessLine = value;
        }
    }
}
