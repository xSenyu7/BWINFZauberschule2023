
using System.Security.Cryptography.X509Certificates;
using Zauberschule.Data;

namespace Zauberschule.Logic
{
    public class LaufAlgorhytmus
    {
        public Schule Schulgebäude {  get; set; }
        public Ziel Ziel { get; set; }
        public Person Person { get; set; }
        public Stockwerk ErsteEtage { get; set; }
        public Stockwerk ZweiteEtage { get; set; }

        public LaufAlgorhytmus(Schule schule, Ziel ziel, Person person)
        {
            Schulgebäude = schule;
            Ziel = ziel;
            Person = person;
            ErsteEtage = schule.ErsteEtage;
            ZweiteEtage = schule.ZweiteEtage;
        }


        public void SchnellstenWegFinden()
        {
            Ziel startpunkt = 

            while()
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
