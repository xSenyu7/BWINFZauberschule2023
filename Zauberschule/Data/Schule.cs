using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Schule
    {
        public string[] linien;
        public string[,] grundrissInitErste;
        public string[,] grundrissInitZweite;
        public InitialisiereSchule initialisiere;

        public Stockwerk ErsteEtage { get; set; }
        public Stockwerk ZweiteEtage { get; set; }

        public Schule(string path)
        {
            linien = File.ReadAllLines(path);

            initialisiere = new InitialisiereSchule(linien);

            grundrissInitErste = new string[Convert.ToInt32(initialisiere.arrLänge), Convert.ToInt32(initialisiere.arrBreite)];
            grundrissInitZweite = new string[Convert.ToInt32(initialisiere.arrLänge), Convert.ToInt32(initialisiere.arrBreite)];

            ErsteEtage = new Stockwerk
            {
                Breite = Convert.ToInt32(initialisiere.arrBreite),
                Länge = Convert.ToInt32(initialisiere.arrLänge),
                Grundriss = initialisiere.OberesStockwerkAuslesen(grundrissInitErste, linien)
            };
            ErsteEtage.UrsprünglichePerson = initialisiere.UrsprünglichePersonAuslesen(ErsteEtage.Grundriss);
            ErsteEtage.UrsprünglichesZiel = initialisiere.UrschprünglichesZielAuslesen(ErsteEtage.Grundriss);

            ZweiteEtage = new Stockwerk
            {
                Breite = Convert.ToInt32(initialisiere.arrBreite),
                Länge= Convert.ToInt32(initialisiere.arrLänge),
                Grundriss = initialisiere.UnteresStockwerkAuslesen(grundrissInitZweite, linien)
            };
            ZweiteEtage.UrsprünglichePerson = initialisiere.UrsprünglichePersonAuslesen(ZweiteEtage.Grundriss);
            ZweiteEtage.UrsprünglichesZiel = initialisiere.UrschprünglichesZielAuslesen(ZweiteEtage.Grundriss);
        }

        public void WriteSchuleMitZahl(Schule schule)
        {
            for (int i = 0; i < schule.ErsteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ErsteEtage.Breite; j++)
                {
                    Console.Write(schule.ErsteEtage.Grundriss[i, j] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < schule.ZweiteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ZweiteEtage.Breite; j++)
                {
                    Console.Write(schule.ZweiteEtage.Grundriss[i, j] + ",");
                }
                Console.WriteLine();
            }
        }

        public void WriteSchule(Schule schule)
        {
            for (int i = 0; i < schule.ErsteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ErsteEtage.Breite; j++)
                {
                    if (bla(schule.ErsteEtage.Grundriss[i, j]))
                        schule.ErsteEtage.Grundriss[i, j] = ".";

                    Console.Write(schule.ErsteEtage.Grundriss[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < schule.ZweiteEtage.Länge; i++)
            {
                for (int j = 0; j < schule.ZweiteEtage.Breite; j++)
                {
                    if (bla(schule.ZweiteEtage.Grundriss[i, j]))
                        schule.ZweiteEtage.Grundriss[i, j] = ".";

                    Console.Write(schule.ZweiteEtage.Grundriss[i, j]);
                }
                Console.WriteLine();
            }
        }

        private bool bla(string s)
        {
            try
            {
                Convert.ToInt32(s);
                return true;
            }
            catch { }
            return false;
        }
    }
}
