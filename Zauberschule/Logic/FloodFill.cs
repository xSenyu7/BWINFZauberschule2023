using Zauberschule.Data;

namespace Zauberschule.Logic
{
    public class FloodFill
    {
        List<Ziel> Zwischenpunkte = new List<Ziel>();

        int floodNummer = 1;


        public Schule AuffüllenDerStockwerke(Schule schule, Ziel zielpunkt, Person person)
        {
            schule.ErsteEtage.Grundriss = AuffüllenDesStockwerks(schule.ErsteEtage, zielpunkt, person);

            schule.ZweiteEtage.Grundriss = AuffüllenDesStockwerks(schule.ZweiteEtage, zielpunkt, person);

            return schule;
        }

        private string[,] AuffüllenDesStockwerks(Stockwerk etage, Ziel zielpunkt, Person person)
        {
            Zwischenpunkte.Add(zielpunkt);

            string[,] aktuelleEtage = etage.Grundriss;

            aktuelleEtage[zielpunkt.PositionX, zielpunkt.PositionY] = "B";
            aktuelleEtage[person.PositionX, person.PositionY] = "A";

            while (NotwendigkeitFürAuffüllungPrüfen(aktuelleEtage))
            {
                if (PrüfenObAmZiel(aktuelleEtage) == true)
                {
                    Console.WriteLine("Ziel wurde gefunden.");
                    break;
                }
                else
                    FelderAuffüllen(aktuelleEtage);

                NeueKoordinatenHinzufügen(aktuelleEtage);

                //SinnloseKoordinatenLöschen(ersteEtage);

                floodNummer++;
            }

            ZielUndPersonPlatzhalterEntfernen(etage, zielpunkt, person, aktuelleEtage);

            Zwischenpunkte.RemoveRange(0, Zwischenpunkte.Count);
            floodNummer = 1;

            return aktuelleEtage;
        }

        private void ZielUndPersonPlatzhalterEntfernen(Stockwerk etage, Ziel zielpunkt, Person person, string[,] aktuelleEtage)
        {
            if (!etage.UrsprünglichesZiel)
                aktuelleEtage[zielpunkt.PositionX, zielpunkt.PositionY] = "0";

            if (!etage.UrsprünglichePerson)
                aktuelleEtage[person.PositionX, person.PositionY] = Convert.ToString(floodNummer);
        }

        private void NeueKoordinatenHinzufügen(string[,] etage)
        
        {
            int anzahlZwischenpunkte = Zwischenpunkte.Count;

            for (int i = 0; i < anzahlZwischenpunkte; i++)
            {
                if (etage[Zwischenpunkte[i].PositionX + 1, Zwischenpunkte[i].PositionY] == floodNummer.ToString())
                {
                    Zwischenpunkte.Add(new Ziel(Zwischenpunkte[i].PositionX + 1, Zwischenpunkte[i].PositionY));
                }
                if (etage[Zwischenpunkte[i].PositionX - 1, Zwischenpunkte[i].PositionY] == floodNummer.ToString())
                {
                    Zwischenpunkte.Add(new Ziel(Zwischenpunkte[i].PositionX - 1, Zwischenpunkte[i].PositionY));
                }
                if (etage[Zwischenpunkte[i].PositionX, Zwischenpunkte[i].PositionY + 1] == floodNummer.ToString())
                {
                    Zwischenpunkte.Add(new Ziel(Zwischenpunkte[i].PositionX, Zwischenpunkte[i].PositionY + 1));
                }
                if (etage[Zwischenpunkte[i].PositionX, Zwischenpunkte[i].PositionY - 1] == floodNummer.ToString())
                {
                    Zwischenpunkte.Add(new Ziel(Zwischenpunkte[i].PositionX, Zwischenpunkte[i].PositionY - 1));
                }
            }
        }

        private void SinnloseKoordinatenLöschen(string[,] etage)
        {
            int anzahlZwischenpunkte = Zwischenpunkte.Count;

            for (int i = 0; i < anzahlZwischenpunkte; i++)
            {
                if (etage[Zwischenpunkte[i].PositionX + 1, Zwischenpunkte[i].PositionY] != "."
                || etage[Zwischenpunkte[i].PositionX - 1, Zwischenpunkte[i].PositionY] != "."
                || etage[Zwischenpunkte[i].PositionX, Zwischenpunkte[i].PositionY + 1] != "."
                || etage[Zwischenpunkte[i].PositionX, Zwischenpunkte[i].PositionY - 1] != ".")
                {
                    Zwischenpunkte.Remove(Zwischenpunkte[i]);
                    anzahlZwischenpunkte--;
                }

            }
        }

        private void FelderAuffüllen(string[,] etage)
        {
            foreach (Ziel z in Zwischenpunkte)
            {
                if (etage[z.PositionX + 1, z.PositionY] == ".")
                {
                    etage[z.PositionX + 1, z.PositionY] = floodNummer.ToString();
                }
                if (etage[z.PositionX - 1, z.PositionY] == ".")
                {
                    etage[z.PositionX - 1, z.PositionY] = floodNummer.ToString();
                }
                if (etage[z.PositionX, z.PositionY + 1] == ".")
                {
                    etage[z.PositionX, z.PositionY + 1] = floodNummer.ToString();
                }
                if (etage[z.PositionX, z.PositionY - 1] == ".")
                {
                    etage[z.PositionX, z.PositionY - 1] = floodNummer.ToString();
                }
            }
        }

        private bool PrüfenObAmZiel(string[,] etage)
        {
            foreach (Ziel z in Zwischenpunkte)
            {
                if (etage[z.PositionX + 1, z.PositionY] == "A")
                    return true;
                else if (etage[z.PositionX - 1, z.PositionY] == "A")
                    return true;
                else if (etage[z.PositionX, z.PositionY + 1] == "A")
                    return true;
                else if (etage[z.PositionX, z.PositionY - 1] == "A")
                    return true;
            }
            return false;
        }


        private bool NotwendigkeitFürAuffüllungPrüfen(string[,] etage)
        {
            foreach (Ziel z in Zwischenpunkte)
            {
                if (etage[z.PositionX + 1, z.PositionY] == "."
                || etage[z.PositionX - 1, z.PositionY] == "."
                || etage[z.PositionX, z.PositionY + 1] == "."
                || etage[z.PositionX, z.PositionY - 1] == ".")
                    return true;
            }
            return false;
        }
    }
}
