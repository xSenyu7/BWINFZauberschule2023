namespace Zauberschule.Data
{
    public class Schule
    {
        public string arrLänge { get; private set; }
        public string arrBreite { get; private set; }
        private char[,] grundrissErsteEtage;
        private char[,] grundrissZweiteEtage;
        private char[] grundrissSchule;

        public Schule()
        {

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
                            return;
                        }
                    }
                }
            }
        }

        public void OberesStockwerkErmitteln()
        {

        }
        public void UnteresStockwerkErmitteln()
        {

        }
    }
}
