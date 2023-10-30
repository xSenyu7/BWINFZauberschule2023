
using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Person
    {
        public string PositionSymbol { get; set; } = "A";
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public InitialisierePerson initialisierePerson;


        public Person(Schule schule)
        {
            PositionX = initialisierePerson.PositionXFinden(schule);
            PositionY = initialisierePerson.PositionYFinden(schule);
        }
    }
}
