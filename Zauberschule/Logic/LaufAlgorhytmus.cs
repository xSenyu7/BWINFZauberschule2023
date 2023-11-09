
using Zauberschule.Data;

namespace Zauberschule.Logic
{
    public class LaufAlgorhytmus
    {

        List<Ziel> Zwischenpunkte = new List<Ziel>();

        public string[,] ErsteEtage {  get; set; }
        public string[,] ZweiteEtage{  get; set; }
        public Ziel Ziel { get; set; }
        public Person Person { get; set; }

        public LaufAlgorhytmus(string[,] ersteEtage, string[,] zweiteEtage, Ziel ziel, Person person)
        {
            ErsteEtage = ersteEtage;
            ZweiteEtage = zweiteEtage;
            Ziel = ziel;
            Person = person;
        }


        public void SchnellstenWegFinden()
        {
            
        }
        private void EtageHoch()
        {

        }
        private void EtageRunter()
        {

        }
        private void NachVorne()
        {

        }
        private void NachRechts()
        {

        }
        private void NachUnten()
        {

        }
        private void NachLinks()
        {

        }
    }
}
