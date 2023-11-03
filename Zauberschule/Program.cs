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

            string[,] wurdeGefillt = floodFill.AuffüllenDesStockwerks(schule, ziel);

            for (int i = 0; i < schule.ErsteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ErsteEtage.Breite; j++)
                {
                    Console.Write(wurdeGefillt[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}