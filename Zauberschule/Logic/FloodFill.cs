using Zauberschule.Data;

namespace Zauberschule.Logic
{
    public class FloodFill
    {
        List<Ziel> Zwischenpunkte = new List<Ziel>();

        int floodNummer = 1;


        public void AuffüllenDesStockwerks(Schule schule, Ziel zielpunkt)
        {
            Zwischenpunkte.Add(zielpunkt);

            string[,] ersteEtage = schule.ErsteEtage.Grundriss;

            while (NotwendigkeitFürAuffüllungPrüfen(ersteEtage) == true)
            {
                if (PrüfenObAmZiel(ersteEtage) == true)
                    break;
                else
                    FelderAuffüllen(ersteEtage);
            }
        }

        private void FelderAuffüllen(string[,] etage)
        {
            int aufgefüllteFelder = 0;

            foreach (Ziel z in Zwischenpunkte)
            {
                while (NotwendigkeitFürAuffüllungPrüfen(etage))
                {
                    if (etage[z.PositionX + 1, z.PositionY] == ".")
                    {
                        etage[z.PositionX + 1, z.PositionY] = floodNummer.ToString();
                        aufgefüllteFelder++;
                    }
                    if (etage[z.PositionX - 1, z.PositionY] == ".")
                    {
                        etage[z.PositionX - 1, z.PositionY] = floodNummer.ToString();
                        aufgefüllteFelder++;
                    }
                    if (etage[z.PositionX, z.PositionY + 1] == ".")
                    {
                        etage[z.PositionX, z.PositionY + 1] = floodNummer.ToString();
                        aufgefüllteFelder++;
                    }
                    if (etage[z.PositionX, z.PositionY - 1] == ".")
                    {
                        etage[z.PositionX, z.PositionY - 1] = floodNummer.ToString();
                        aufgefüllteFelder++;
                    }
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
