using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Schule
    {
        public char[] textDatei;
        public char[,] grundrissErsteEtage;
        public char[,] grundrissZweiteEtage;
        private char[] grundrissSchule;
        public InitialisiereSchule initialisiere = new();

        public Stockwerk ErsteEtage { get; set; }
        public Stockwerk ZweiteEtage { get; set; }


        public Schule(string path)
        {
            GrundrissAuslesen(path);
            grundrissErsteEtage = new char[Convert.ToInt32(initialisiere.arrLänge), Convert.ToInt32(initialisiere.arrBreite)];
            grundrissZweiteEtage = new char[Convert.ToInt32(initialisiere.arrLänge), Convert.ToInt32(initialisiere.arrBreite)];
            LeseStockwerkeAusTxt(path);
        }

        public void LeseStockwerkeAusTxt(string path)
        {
            string[] zeilen = File.ReadAllLines(path);
            int index = 0;

            string[] dimensionen = zeilen[index++].Split('\n');
            int breiteErsteEtage = Convert.ToInt32(initialisiere.arrBreite);
            int längeErsteEtage = Convert.ToInt32(initialisiere.arrLänge);

            ErsteEtage = new Stockwerk
            {
                Breite = breiteErsteEtage,
                Länge = längeErsteEtage,
                Grundriss = new char[längeErsteEtage, breiteErsteEtage]
            };

            for (int i = 0; i < längeErsteEtage; i++)
            {
                char[] reihe = zeilen[index].ToCharArray();
                for (int j = 1; i < breiteErsteEtage; j++)
                {
                    ErsteEtage.Grundriss[i, j] = zeilen[index][j];
                }
                index++;
            }

            dimensionen = zeilen[index++].Split(' ');
            int breiteZweiteEtage = int.Parse(dimensionen[0]);
            int längeZweiteEtage = int.Parse(dimensionen[1]);

            ZweiteEtage = new Stockwerk
            {
                Grundriss = new char[längeZweiteEtage, breiteZweiteEtage]
            };

            for (int i = 0; i < längeZweiteEtage; i++)
            {
                char[] reihe = zeilen[index].ToCharArray();
                for (int j = 1; i < breiteZweiteEtage; j++)
                {
                    ZweiteEtage.Grundriss[i, j] = zeilen[index][j];
                }
                index++;
            }
        }

        public char[] GrundrissAuslesen(string path)
        {
            string text = File.ReadAllText(path);
            textDatei = text.ToCharArray();

            initialisiere.LängeUndBreiteDerArraysAuslesen(textDatei);

            return textDatei;
        }

        public void OberesStockwerkErmitteln()
        {
            initialisiere.OberesStockwerk(textDatei);
        }
        public void UnteresStockwerkErmitteln()
        {

        }
    }
}
