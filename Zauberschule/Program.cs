namespace Zauberschule
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Schule schule = new();

            char[] arrLine = schule.GrundrissAuslesen("adf");

            foreach (char c in arrLine)
            {
                Console.WriteLine(c);
            }
        }
    }
}