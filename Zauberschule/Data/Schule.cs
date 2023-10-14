using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Schule
    {
        public string[] linien;
        public char[,] grundrissInit;
        public InitialisiereSchule initialisiere;

        public Stockwerk ErsteEtage { get; set; }
        public Stockwerk ZweiteEtage { get; set; }


        public Schule(string path)
        {
            linien = File.ReadAllLines(path);

            initialisiere = new InitialisiereSchule(linien);

            grundrissInit = new char[Convert.ToInt32(initialisiere.arrLänge), Convert.ToInt32(initialisiere.arrBreite)];

            ErsteEtage = new Stockwerk
            {
                Breite = Convert.ToInt32(initialisiere.arrBreite),
                Länge = Convert.ToInt32(initialisiere.arrLänge),
                Grundriss = initialisiere.OberesStockwerkAuslesen(grundrissInit, linien)
            };

            ZweiteEtage = new Stockwerk
            {
                Breite = Convert.ToInt32(initialisiere.arrBreite),
                Länge= Convert.ToInt32(initialisiere.arrLänge),
                Grundriss = initialisiere.OberesStockwerkAuslesen(grundrissInit, linien)
            };
        }
    }
}
