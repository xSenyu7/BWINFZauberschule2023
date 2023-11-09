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


            if (ContainsValue(schule.ErsteEtage.Grundriss, "A"))
            {
                Console.WriteLine("Erste Etage enthält A");
            }
            else
            {
                Console.WriteLine("Erste Etage enthält kein A");
            }

            if (ContainsValue(schule.ErsteEtage.Grundriss, "B"))
            {
                Console.WriteLine("Erste Etage enthält B");
            }
            else
            {
                Console.WriteLine("Erste Etage enthält kein B");
            }

            if (ContainsValue(schule.ZweiteEtage.Grundriss, "A"))
            {
                Console.WriteLine("Zweite Etage enthält A");
            }
            else
            {
                Console.WriteLine("Zweite Etage enthält kein A");
            }

            if (ContainsValue(schule.ZweiteEtage.Grundriss, "B"))
            {
                Console.WriteLine("Zweite Etage enthält B");
            }
            else
            {
                Console.WriteLine("Zweite Etage enthält kein B");
            }
        }

        static bool ContainsValue(string[,] array, string targetValue)
        {
            // Iteriere durch die Zeilen
            for (int i = 0; i < array.GetLength(0); i++)
            {
                // Iteriere durch die Spalten
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // Überprüfe, ob das aktuelle Element den Zielwert enthält
                    if (array[i, j] == targetValue)
                    {
                        return true; // Der Wert wurde gefunden
                    }
                }
            }
            return false;
        }
    }
}