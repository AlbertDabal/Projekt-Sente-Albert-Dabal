using System;
using System.Collections.Generic;

namespace Projekt_Sente
{
    class Program
    {
        static void Main(string[] args)
        {
            DeserializacjaXML deserializacja = new DeserializacjaXML();
            List<InfoUczestnicy> uczestnicyList = deserializacja.Deserialize();
            List<Przelew> przelewyList = deserializacja.DeserializePrzelew();       
            (new Prowizja()).LiczenieProwizji(uczestnicyList, przelewyList);
            Console.ReadLine();
        }
    }

}
