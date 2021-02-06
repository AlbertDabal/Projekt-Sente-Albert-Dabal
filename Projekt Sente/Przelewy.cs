using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt_Sente
{
    [XmlRoot("przelewy")]
    public class Przelewy
    {
        [XmlElement("przelew")]
        public Przelew[] Przelew { get; set; }
    }

    public class Przelew
    {
        [XmlAttribute("od")]
        public int Od { get; set; }
        [XmlAttribute("kwota")]
        public double Kwota { get; set; }
    }
}
