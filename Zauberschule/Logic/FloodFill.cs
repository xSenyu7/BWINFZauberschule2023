using Zauberschule.Data;

namespace Zauberschule.Logic
{
    public class FloodFill
    {
        List<Ziel> Zwischenpunkte = new List<Ziel>();

        int floodNummer = 1;


        public string[,] AuffüllenDesStockwerks(Schule schule, Ziel zielpunkt)
        {
            Zwischenpunkte.Add(zielpunkt);

            string[,] ersteEtage = schule.ErsteEtage.Grundriss;

            while (NotwendigkeitFürAuffüllungPrüfen(ersteEtage) == true)
            {
                if (PrüfenObAmZiel(ersteEtage) == true)
                    break;
                else
                    FelderAuffüllen(ersteEtage);

                NeueKoordinatenHinzufügen(ersteEtage);

                SinnloseKoordinatenLöschen(ersteEtage);

                floodNummer++;
            }
            return ersteEtage;
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
                else if (etage[z.PositionX, z.PositionY + 1] == "A")
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
