using Zauberschule.Data;

namespace Zauberschule
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pfadZurTxt = @"..\..\..\..\zauberschule0.txt";

            Schule schule = new();

            char[] arrLine = schule.GrundrissAuslesen(pfadZurTxt);

            foreach (char c in arrLine)
            {
                Console.WriteLine(c);
            }
        }
    }
}