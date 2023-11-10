using System.Security.Cryptography;
using Zauberschule.Data;
using Zauberschule.Logic;

namespace Zauberschule
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pfadZurTxt = @"..\..\..\..\zauberschule0.txt";

            Schule schule = new(pfadZurTxt);

            Person person = new(schule);

            Ziel ziel = new(schule);

            FloodFill floodFill = new();

            schule = floodFill.AuffüllenDerStockwerke(schule, ziel, person);

            LaufAlgorhytmus lauf = new(schule, ziel, person);

            schule = lauf.SchnellstenWegFinden();

            for (int i = 0; i < schule.ErsteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ErsteEtage.Breite; j++)
                {
                    if (bla(schule.ErsteEtage.Grundriss[i, j]))
                        schule.ErsteEtage.Grundriss[i, j] = ".";

                    Console.Write(schule.ErsteEtage.Grundriss[i,j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < schule.ZweiteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ZweiteEtage.Breite; j++)
                {
                    if (bla(schule.ZweiteEtage.Grundriss[i, j]))
                        schule.ZweiteEtage.Grundriss[i, j] = ".";

                    Console.Write(schule.ZweiteEtage.Grundriss[i, j]);
                }
                Console.WriteLine();
            }


        }
        static bool bla(string s)
        {
            try
            {
                Convert.ToInt32(s);
                return true;
            }
            catch { }
            return false;
        }
    }
}