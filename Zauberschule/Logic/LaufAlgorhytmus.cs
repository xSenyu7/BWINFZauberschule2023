
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
            Ziel aktuellePosition = new(Person.PositionX, Person.PositionY);

            Etage aktuelleEtage = Etage.Keine;

            aktuelleEtage = SucheNachAktuelleEtage(aktuelleEtage);

            while (AbfragenObAmZiel(aktuellePosition))
            {

            }
        }

        private bool AbfragenObAmZiel(Ziel aktuellePosition)
        {
            bool 

            if(ErsteEtage.Grundriss[aktuellePosition.PositionX + 1, aktuellePosition.PositionY] != "B")
            {

            }

            return ErsteEtage.Grundriss[aktuellePosition.PositionX + 1, aktuellePosition.PositionY] != "B"
                    || ErsteEtage.Grundriss[aktuellePosition.PositionX - 1, aktuellePosition.PositionY] != "B"
                            || ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY + 1] != "B"
                            || ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY - 1] != "B";
        }

        private Etage SucheNachAktuelleEtage(Etage aktuelleEtage)
        {
            if (ErsteEtage.UrsprünglichePerson == true)
            {
                aktuelleEtage = Etage.Erste;
            }
            else if (ZweiteEtage.UrsprünglichePerson == true)
            {
                aktuelleEtage = Etage.Zweite;
            }

            return aktuelleEtage;
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
