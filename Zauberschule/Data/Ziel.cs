

using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Ziel
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public InitialisiereZiel initialisiereZiel;

        public Ziel(Schule schule)
        {
            initialisiereZiel = new();

            PositionX = initialisiereZiel.PositionXFinden(schule);
            Console.WriteLine(PositionX);
            PositionY = initialisiereZiel.PositionYFinden(schule);
            Console.WriteLine(PositionY);
        }

        public Ziel(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

    }
}
