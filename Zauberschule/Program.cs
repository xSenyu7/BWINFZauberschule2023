using Zauberschule.Data;

namespace Zauberschule
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pfadZurTxt = @"..\..\..\..\zauberschule0.txt";

            Schule schule = new(pfadZurTxt);

             
            for(int i = 0; i < schule.ErsteEtage.Länge; i++)
            {
                for(int j = 0; j < schule.ErsteEtage.Breite; j++)
                {
                    Console.Write(schule.ErsteEtage.Grundriss[i,j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < schule.ZweiteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ZweiteEtage.Breite; j++)
                {
                    Console.Write(schule.ZweiteEtage.Grundriss[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}