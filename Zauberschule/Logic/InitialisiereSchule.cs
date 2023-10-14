using Zauberschule.Data;


namespace Zauberschule.Logic
{
    public class InitialisiereSchule
    {
        public string arrLänge;
        public string arrBreite;
        private int aktuelleLinie = 0;
        char[] linie;

        public InitialisiereSchule(string[] linien)
        {
            linie = linien[aktuelleLinie].ToCharArray();

            LängeUndBreiteErmittlen(linien, linie);
        }

        private void LängeUndBreiteErmittlen(string[] linien, char[] linie)
        {
            for (int i = 0; i < linien[aktuelleLinie].Length; i++)
            {
                if (char.IsNumber(linie[i]))
                {
                    arrLänge = arrLänge + linie[i];
                }
                else if (char.IsWhiteSpace(linie[i]))
                {
                    for (int j = i + 1; j < linie.Length; j++)
                    {
                        if (char.IsNumber(linie[j]))
                        {
                            arrBreite = arrBreite + linie[j];
                        }
                        else
                        {
                            break;
                        }
                        i++;
                    }
                }
            }
            aktuelleLinie++;
        }

        public char[,] OberesStockwerkAuslesen(char[,] grundriss, string[] linien)
        {
            linie = linien[aktuelleLinie].ToCharArray();

            if (linie.Length != 0)
            {
                for (int i = 0;i < linie.Length; i++)
                {
                    grundriss[aktuelleLinie, i] = linie[i];
                }
                aktuelleLinie++;
            }
            return grundriss;
        }

        public char[,] UnteresStockwerkAuslesen(Stockwerk stockwerk, string[] linien)
        {
            char[,] grundriss = new char[stockwerk.Länge, stockwerk.Breite];
            linie = linien[aktuelleLinie].ToCharArray();

            if (linie.Length != 0)
            {
                for (int i = 0; i < linie.Length; i++)
                {
                    grundriss[aktuelleLinie, i] = linie[i];
                }
                aktuelleLinie++;
            }
            return grundriss;
        }
    }
}
