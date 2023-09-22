
namespace Zauberschule
{
    public class Schule
    {
        private char[] grundrissErsteEtage;
        private char[] grundrissZweiteEtage;

        Person person = new();

        public char[] GrundrissAuslesen()
        {
            string text = File.ReadAllText(@"..\RonsSchule");
            char[] textDatei = { '1', '1' };

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
