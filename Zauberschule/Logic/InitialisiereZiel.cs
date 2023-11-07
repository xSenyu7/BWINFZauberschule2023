
using Zauberschule.Data;

namespace Zauberschule.Logic
{
    public class InitialisiereZiel
    {
        public int PositionXFinden(Schule schule)
        {
            Stockwerk etage = ErsteOderZweiteEtage(schule);

            for (int i = 0; i < etage.Länge - 1; i++)
            {
                for (int j = 0; j < etage.Breite - 1; j++)
                {
                    if (etage.Grundriss[i, j] == "B")
                        return i;
                }
            }
            return 1;
        }

        public int PositionYFinden(Schule schule)
        {

            Stockwerk etage = ErsteOderZweiteEtage(schule);

            for (int i = 0; i < etage.Länge; i++)
            {
                for (int j = 0; j < etage.Breite; j++)
                {
                    if (etage.Grundriss[i, j] == "B")
                        return j;
                }
            }
            return 1;
        }

        public Stockwerk ErsteOderZweiteEtage(Schule schule)
        {
            Stockwerk ersteEtage = schule.ErsteEtage;
            Stockwerk zweiteEtage = schule.ZweiteEtage;

            foreach (string s in ersteEtage.Grundriss)
            {
                if (s == "B")
                    return ersteEtage;
            }
            foreach (string s in zweiteEtage.Grundriss)
            {
                if (s == "B")
                    return zweiteEtage;
            }

            Stockwerk empty = new();

            return empty;
        }

    }
}
