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

            schule.WriteSchuleMitZahl(schule);

            LaufAlgorhytmus lauf = new(schule, ziel, person);

            schule = lauf.SchnellstenWegFinden();

            Console.WriteLine("\n");

            schule.WriteSchule(schule);

            
        }
    }
}