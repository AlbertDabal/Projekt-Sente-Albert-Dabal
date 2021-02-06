using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Sente
{
    class Prowizja
    {
        public void SprawdzanieProwizja(List<InfoUczestnicy> uczestnicyList, List<Przelew> przelewyList, int numerPrzelewu, int numerPoprzedniegoUczestnika, int numerUczestnika, double kwota)
        {
            double kwota_chwilowa;

            for (int i = 0; i <= uczestnicyList[numerPoprzedniegoUczestnika].LiczbaPodwladnych; i++)
            {
                if (uczestnicyList[numerUczestnika].LiczbaPodwladnych > 0 && (przelewyList[numerPrzelewu].Od > uczestnicyList[1].Id + 1) && (uczestnicyList[0].Id != przelewyList[numerPrzelewu].Od - 1))
                {                                   
                    if(uczestnicyList[numerUczestnika+1].LiczbaPodwladnych == 0)
                    {
                        uczestnicyList[numerUczestnika].Prowizja += kwota;
                    }
                    else if(uczestnicyList[numerUczestnika + 1].LiczbaPodwladnych > 0)
                    {
                        kwota_chwilowa = Math.Floor(kwota / 2);
                        uczestnicyList[numerUczestnika].Prowizja += kwota_chwilowa;
                        kwota -= kwota_chwilowa;           
                    }
                    
                    SprawdzanieProwizja(uczestnicyList, przelewyList, numerPrzelewu, ++numerPoprzedniegoUczestnika, ++numerUczestnika, kwota);
                }
                numerUczestnika++;
            }

        }
        public void LiczenieProwizji(List<InfoUczestnicy> uczestnicyList, List<Przelew> przelewyList)
        {
            for (int i = 0; i < przelewyList.Count; i++)
            {
                double kwota_chwilowa;
                double kwota = przelewyList[i].Kwota;

                if (przelewyList[i].Od == uczestnicyList[0].Id)
                {
                    uczestnicyList[0].Prowizja += kwota;
                }

                if (uczestnicyList[0].LiczbaPodwladnych > 0 && (uczestnicyList[0].Id != przelewyList[i].Od - 1) && (przelewyList[i].Od > uczestnicyList[1].Id + 1))
                {              
                    kwota_chwilowa = Math.Floor(kwota / 2);
                    uczestnicyList[0].Prowizja += kwota_chwilowa;
                    kwota -= kwota_chwilowa;         
                    SprawdzanieProwizja(uczestnicyList, przelewyList, i, 0, 1,kwota);
                }
                else
                {
                    uczestnicyList[0].Prowizja += kwota;
                }
            }

            foreach (var item in uczestnicyList)
            {
                Console.WriteLine(item.Id + " " + item.PoziomPiramidy + " " + item.LiczbaPodwladnych + " " + item.Prowizja);
            }
        }

    }

}

