using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Projekt_Sente
{
    class DeserializacjaXML
    {
        public void PodUczestnicy(Uczestnik[] u, int sektor,List<InfoUczestnicy> uczestnicyList)
        {
            for (int a = 0; a < (u.Length); a++)
            {
                if (a == 0) sektor++;

                if (u[a].PodUczestnik != null)
                {
                    uczestnicyList.Add(new InfoUczestnicy { Id = u[a].Id, PoziomPiramidy = sektor, LiczbaPodwladnych = u[a].PodUczestnik.Length, Prowizja = 0 });
                    u = u[a].PodUczestnik;
                    PodUczestnicy(u, sektor,uczestnicyList);
                }
                else
                {
                    uczestnicyList.Add(new InfoUczestnicy { Id = u[a].Id, PoziomPiramidy = sektor, LiczbaPodwladnych = 0, Prowizja = 0 });
                }
            }

           
        }
        public List<InfoUczestnicy> Deserialize()
        {
            List<InfoUczestnicy> uczestnicyList = new List<InfoUczestnicy>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Piramida));
            Piramida piramida = (Piramida)xmlSerializer.Deserialize(new StreamReader(@"..\..\xml\piramida.xml"));
            DeserializacjaXML deserializacja = new DeserializacjaXML();
            int sektor = 0;

            Uczestnik[] u = piramida.Uczestnik;

            for (int i = 0; i < u.Length; i++)
            {
                if (u[i].PodUczestnik != null)
                {
                    uczestnicyList.Add(new InfoUczestnicy { Id = u[i].Id,PoziomPiramidy = sektor, LiczbaPodwladnych= u[i].PodUczestnik.Length, Prowizja=0 });
                    deserializacja.PodUczestnicy(u[i].PodUczestnik, sektor,uczestnicyList);
                }
                else
                {
                    uczestnicyList.Add(new InfoUczestnicy { Id = u[i].Id, PoziomPiramidy = sektor, LiczbaPodwladnych = 0, Prowizja = 0 });                   
                }
            }

            return uczestnicyList;
        }

        public List<Przelew> DeserializePrzelew()
        {
            List<Przelew> przelewyList = new List<Przelew>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Przelewy));
            Przelewy przelewy = (Przelewy)xmlSerializer.Deserialize(new StreamReader(@"..\..\xml\przelewy.xml"));

            foreach (Przelew item in przelewy.Przelew)
            {
                przelewyList.Add(new Przelew { Od = item.Od, Kwota = item.Kwota });
            }

            return przelewyList;
        }
    }
}
