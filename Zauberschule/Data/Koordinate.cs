using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Koordinate
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public InitialisiereZiel initialisiereZiel;

        public Koordinate(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

    }
}