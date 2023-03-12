using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImageEditor.Models
{
    public class LineElement : Figures
    {
        private string startPoint;
        private string endPoint;
        private int strokeNum;
        private int strokeThickness;


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
