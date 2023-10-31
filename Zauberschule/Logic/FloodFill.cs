

using Zauberschule.Data;

namespace Zauberschule.Logic
{
    public class FloodFill
    {
        List<Ziel> Zwischenpunkte = new List<Ziel>();



        public void AuffüllenDesStockwerks(Schule schule, Ziel zielpunkt)
        {
            Zwischenpunkte.Add(zielpunkt);

            string[,] ersteEtage = schule.ErsteEtage.Grundriss;

            while (NotwendigkeitFürAuffüllungPrüfen(ersteEtage) == true)
            {
                if (PrüfenObAmZiel(ersteEtage) == true)
                    break;


            }
        }

        private bool PrüfenObAmZiel(string[,] ersteEtage)
        {
            foreach (Ziel z in Zwischenpunkte)
            {
                if (ersteEtage[z.PositionX + 1, z.PositionY] == "A")
                    return true;
                else if (ersteEtage[z.PositionX - 1, z.PositionY] == "A")
                    return true;
                else if (ersteEtage[z.PositionX, z.PositionY + 1] == "A")
                    return true;
                else if (ersteEtage[z.PositionX, z.PositionY + 1] == "A")
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

        private void ZwischenpunktIteration()
        {

        }
    }
}
