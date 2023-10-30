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

        public char[,] OberesStockwerkAuslesen(string[,] grundriss, string[] linien)
        {
            linie = linien[aktuelleLinie].ToCharArray();
            int längeNum = Convert.ToInt32(arrLänge);
            int breiteNum = Convert.ToInt32(arrBreite);

            while (linie.Length != 0)
            {
                for (int i = 0; i < längeNum; i++)
                {
                    for (int j = 0; j < breiteNum; j++)
                    {
                        grundriss[i, j] = Convert.ToString(linie[j]);
                        Console.Write(grundriss[i,j]);
                    }
                    aktuelleLinie++;
                    linie = linien[aktuelleLinie].ToCharArray();

                    Console.WriteLine();
                }
            }
            aktuelleLinie++;
            return grundriss;
        }

        public char[,] UnteresStockwerkAuslesen(string[,] grundriss, string[] linien)
        {
            linie = linien[aktuelleLinie].ToCharArray();
            int längeNum = Convert.ToInt32(arrLänge);
            int breiteNum = Convert.ToInt32(arrBreite);

            if (linie.Length != 0)
            {
                for (int i = 0; i < längeNum; i++)
                {
                    for (int j = 0; j < breiteNum; j++)
                    {
                        grundriss[i, j] = Convert.ToString(linie[j]);
                        Console.Write(grundriss[i, j]);
                    }
                    if (aktuelleLinie < linien.Length - 1)
                        aktuelleLinie++;

                    linie = linien[aktuelleLinie].ToCharArray();

                    Console.WriteLine();
                    }    
            }
            return grundriss;
        }
    }
}
