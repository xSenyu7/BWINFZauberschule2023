
namespace Zauberschule.Data
{
    public class Stockwerk
    {
        public int Breite { get; set; }
        public int Länge { get; set; }
        public string[,]? Grundriss { get; set; }
        public bool UrsprünglichesZiel {  get; set; }
        public bool UrsprünglichePerson { get; set; } = false;
    }
}
