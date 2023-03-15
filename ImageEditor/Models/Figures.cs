using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImageEditor.Models
{
    [XmlInclude(typeof(LineElement))]
    [XmlInclude(typeof(PolylineElement))]
    [XmlInclude(typeof(PolygonElement))]
    [XmlInclude(typeof(RectangleElement))]
    [XmlInclude(typeof(EllipseElement))]
    [XmlInclude(typeof(PathElement))]
    public class Figures
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}
