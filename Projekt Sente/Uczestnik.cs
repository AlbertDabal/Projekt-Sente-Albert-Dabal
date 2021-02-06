using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt_Sente
{
    public class Uczestnik
    {
        [XmlElement("uczestnik")]
        public Uczestnik[] PodUczestnik { get; set; }


        [XmlAttribute("id")]
        public int Id { get; set; }

    }
}
