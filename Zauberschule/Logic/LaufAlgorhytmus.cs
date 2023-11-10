﻿
using System.Reflection.Metadata.Ecma335;
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

            while (AbfragenObAmZiel(aktuellePosition, aktuelleEtage))
            {

            }
        }

        private bool AbfragenObAmZiel(Ziel aktuellePosition, Etage etage)
        {
            bool zielFrage;

            if(etage == Etage.Erste)
            {
                if (ErsteEtage.Grundriss[aktuellePosition.PositionX + 1, aktuellePosition.PositionY] == "B")
                    return true;

                else if (ErsteEtage.Grundriss[aktuellePosition.PositionX - 1, aktuellePosition.PositionY] == "B")
                    return true;

                else if (ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY + 1] == "B")
                    return true;

                else if (ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY - 1] == "B")
                    return true;
                
                else if (ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY] == "B")
                    return true;
            }
            else if (etage == Etage.Zweite)
            {
                if (ZweiteEtage.Grundriss[aktuellePosition.PositionX + 1, aktuellePosition.PositionY] == "B")
                    return true;

                else if (ZweiteEtage.Grundriss[aktuellePosition.PositionX - 1, aktuellePosition.PositionY] == "B")
                    return true;
                
                else if (ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY + 1] == "B")
                    return true;
                
                else if (ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY - 1] == "B")
                    return true;
                
                else if (ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY] == "B")
                    return true;
            }
            return false;
        }

        private Etage SucheNachAktuelleEtage(Etage aktuelleEtage)
        {
            if (ErsteEtage.UrsprünglichePerson == true)
                aktuelleEtage = Etage.Erste;
            
            else if (ZweiteEtage.UrsprünglichePerson == true)
                aktuelleEtage = Etage.Zweite;
            
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
