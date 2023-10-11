using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Schule
    {

        public char[,] grundrissErsteEtage;
        public char[,] grundrissZweiteEtage;
        private char[] grundrissSchule;
        public InitialisiereSchule initialisiere = new();


        public Schule(string path)
        {
            
            GrundrissAuslesen(path);
            grundrissErsteEtage = new char[Convert.ToInt32(initialisiere.arrLänge), Convert.ToInt32(initialisiere.arrBreite)];
            grundrissZweiteEtage = new char[Convert.ToInt32(initialisiere.arrLänge), Convert.ToInt32(initialisiere.arrBreite)];
        }

        public char[] GrundrissAuslesen(string path)
        {
            string text = File.ReadAllText(path);
            char[] textDatei = text.ToCharArray();

            initialisiere.LängeUndBreiteDerArraysAuslesen(textDatei);

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
