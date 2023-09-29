using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Schule
    {
        
        private char[,] grundrissErsteEtage;
        private char[,] grundrissZweiteEtage;
        private string arrLänge;
        private string arrBreite;
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

            LängeUndBreiteDerArraysAuslesen(textDatei);

            return textDatei;
        }

        private void LängeUndBreiteDerArraysAuslesen(char[] textDatei)
        {
            string arrL;
            string arrb;

            for (int i = 0; i < textDatei.Length; i++)
            {
                if (char.IsNumber(textDatei[i]))
                {
                    arrLänge = arrLänge + textDatei[i];
                }
                else if (char.IsWhiteSpace(textDatei[i]))
                {
                    for (int j = i + 1; j < textDatei.Length; j++)
                    {
                        if (char.IsNumber(textDatei[j]))
                        {
                            arrBreite = arrBreite + textDatei[j];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            arrLänge = arrL;
            arrBreite = arrb;
        }

        private void CharInitialisieren()
        {

        }

        public void OberesStockwerkErmitteln()
        {

        }
        public void UnteresStockwerkErmitteln()
        {

        }
    }
}
