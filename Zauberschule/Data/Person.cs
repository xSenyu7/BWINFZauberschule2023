
using Zauberschule.Logic;

namespace Zauberschule.Data
{
    public class Person
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public InitialisierePerson initialisierePerson = new();

        public Person(Schule schule)
        {
            PositionX = initialisierePerson.PositionXFinden(schule);
            Console.WriteLine(PositionX);
            PositionY = initialisierePerson.PositionYFinden(schule);
            Console.WriteLine(PositionY);
        }
    }
}
