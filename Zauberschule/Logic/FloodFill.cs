

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
                Console.WriteLine("Hat geklappt soweit.");
            }
        }



        private bool NotwendigkeitFürAuffüllungPrüfen(string[,] etage)
        {
            foreach (Ziel z in Zwischenpunkte)
            {
                if(etage[z.PositionX + 1, z.PositionY] == "."
                || etage[z.PositionX - 1, z.PositionY] == "."
                || etage[z.PositionX, z.PositionY + 1] == "."
                || etage[z.PositionX, z.PositionY - 1] == ".")
                    return true;
            }
            return false;
        }
    }
}
