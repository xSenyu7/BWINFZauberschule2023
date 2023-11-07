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

            LaufAlgorhytmus lauf = new(schule.ErsteEtage.Grundriss, schule.ZweiteEtage.Grundriss, ziel, person);


            for (int i = 0; i < schule.ErsteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ErsteEtage.Breite; j++)
                {
                    Console.Write(schule.ErsteEtage.Grundriss[i, j] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < schule.ZweiteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ZweiteEtage.Breite; j++)
                {
                    Console.Write(schule.ZweiteEtage.Grundriss[i, j] + ",");
                }
                Console.WriteLine();
            }

        }
    }
}