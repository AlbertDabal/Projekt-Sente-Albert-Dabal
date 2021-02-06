using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt_Sente
{
    [XmlRoot("piramida")]
    public class Piramida
    {
        [XmlElement("uczestnik")]
        public Uczestnik[] Uczestnik { get; set; } 
    }

}
