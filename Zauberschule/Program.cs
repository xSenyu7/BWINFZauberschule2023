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

            floodFill.AuffüllenDesStockwerks(schule, ziel);
        }
    }
}