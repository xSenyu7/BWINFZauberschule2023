using Zauberschule.Data;

namespace Zauberschule
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pfadZurTxt = @"..\..\..\..\zauberschule0.txt";

            Schule schule = new(pfadZurTxt);

            char[] zauberschuleArray = schule.GrundrissAuslesen(pfadZurTxt);



            foreach (char c in zauberschuleArray)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine(schule.initialisiere.arrLänge + " " + schule.initialisiere.arrBreite);
            Console.WriteLine(schule.grundrissZweiteEtage.Length);
        }
    }
}