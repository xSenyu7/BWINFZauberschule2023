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
        public Person Person { get; set; }


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

            ZweiteEtage = new Stockwerk
            {
                Breite = Convert.ToInt32(initialisiere.arrBreite),
                Länge= Convert.ToInt32(initialisiere.arrLänge),
                Grundriss = initialisiere.UnteresStockwerkAuslesen(grundrissInitZweite, linien)
            };
        }
    }
}
