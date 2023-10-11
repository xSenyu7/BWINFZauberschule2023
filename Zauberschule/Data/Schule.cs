using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Schule
    {
        private string arrLänge;
        private string arrBreite;
        private char[,] grundrissErsteEtage;
        private char[,] grundrissZweiteEtage;
        private char[] grundrissSchule;



        public Schule()
        {
            arrLänge = "";
            arrBreite = "";
            grundrissErsteEtage = Converter.CharArrayInitialisieren(int.Parse(arrLänge), int.Parse(arrBreite));
            grundrissZweiteEtage = Converter.CharArrayInitialisieren(int.Parse(arrLänge), int.Parse(arrBreite));
        }

        public char[] GrundrissAuslesen(string path)
        {
            string text = File.ReadAllText(path);
            char[] textDatei = text.ToCharArray();

            InitialisiereSchule.LängeUndBreiteDerArraysAuslesen(textDatei);

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
