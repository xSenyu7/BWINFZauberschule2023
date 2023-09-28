
namespace Zauberschule
{
    public class Schule
    {
        private char[,] grundrissErsteEtage;
        private char[,] grundrissZweiteEtage;
        private char[] grundrissSchule;
        string arrLänge;

        Person person = new();

        public char[] GrundrissAuslesen(string path)
        {
            string text = File.ReadAllText(@"..\..\..\..\zauberschule0.txt");
            char[] textDatei = text.ToCharArray();

            for (int i = 0; i < textDatei.Length; i++)
            {
                if (char.IsNumber(textDatei[i]))
                {
                   if (char.IsNumber(textDatei[i]) && !char.IsWhiteSpace(textDatei[i + 1]))
                    {
                        arrLänge = arrLänge + textDatei[i].ToString();
                    }
                   else if (char.IsNumber(textDatei[i]) && char.IsWhiteSpace(textDatei[i + 1]))
                    {
                        arrLänge = arrLänge + textDatei[i].ToString();
                    }
                }
            }

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
