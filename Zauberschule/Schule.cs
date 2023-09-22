
namespace Zauberschule
{
    public class Schule
    {
        private char[,] grundrissErsteEtage;
        private char[,] grundrissZweiteEtage;
        private char[] grundrissSchule;

        Person person = new();

        public char[] GrundrissAuslesen(string path)
        {
            string text = File.ReadAllText(@"..\..\..\..\zauberschule0.txt");
            char[] textDatei = text.ToCharArray();

            return textDatei;
        } 

        public void OberesStockwerkErmitteln()
        {

        }
        public void UnteresStockwerkErmitteln()
        {

        }
    }
}
