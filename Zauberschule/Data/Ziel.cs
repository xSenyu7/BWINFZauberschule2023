

using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Ziel
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public InitialisiereZiel initialisiereZiel = new();

        public Ziel(Schule schule)
        {
            PositionX = initialisiereZiel.PositionXFinden(schule);
            Console.WriteLine(PositionX);
            PositionY = initialisiereZiel.PositionYFinden(schule);
            Console.WriteLine(PositionY);
        }

    }
}
