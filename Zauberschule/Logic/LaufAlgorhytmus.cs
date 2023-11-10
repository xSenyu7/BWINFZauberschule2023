
using System.Net.Http.Headers;
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
        public int Etagenwechsel { get; set; }

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

            int vordereZahl;
            int hintereZahl;
            int rechteZahl;
            int linkeZahl;
            int andereEtageZahl;

            while (AbfragenObAmZiel(aktuellePosition, aktuelleEtage))
            {
                vordereZahl = SucheVordereZahl(aktuellePosition, aktuelleEtage);
                hintereZahl = SucheHintereZahl(aktuellePosition, aktuelleEtage);
                rechteZahl = SucheRechteZahl(aktuellePosition, aktuelleEtage);
                linkeZahl = SucheLinkeZahl(aktuellePosition, aktuelleEtage);
                andereEtageZahl = SucheAndereEtageZahl(aktuellePosition, aktuelleEtage);

                if (aktuelleEtage == Etage.Erste)
                {
                    if (EntscheidenObNachVorne(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachVorne();
                    }
                    else if (EntscheidenObNachHinten(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachHinten();
                    }
                    else if (EntscheidenObNachRechts(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachRechts();
                    }
                    else if (EntscheidenObNachLinks(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachLinks();
                    }
                    else if (EntscheidenObAndereEtage(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        EtageRunter();
                    }
                }
                else if (aktuelleEtage == Etage.Zweite)
                {
                    if (EntscheidenObNachVorne(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachVorne();
                    }
                    else if (EntscheidenObNachHinten(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachHinten();
                    }
                    else if (EntscheidenObNachRechts(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachRechts();
                    }
                    else if (EntscheidenObNachLinks(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        NachLinks();
                    }
                    else if (EntscheidenObAndereEtage(vordereZahl, hintereZahl, rechteZahl, linkeZahl, andereEtageZahl))
                    {
                        EtageRunter();
                    }
                }
            }
        }

        public int SucheAndereEtageZahl(Ziel aktuellePosition, Etage aktuelleEtage)
        {
            if (aktuelleEtage == Etage.Erste)
            {
                if (ErsteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        return Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY] + 7);
                    } catch { }
                }
                else if (!ErsteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        return Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY] + 7);
                    } catch { }
                }

            }
            else if (aktuelleEtage == Etage.Zweite)
            {
                if (ZweiteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        return Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY] + 7);
                    } catch { }
                }
                else if (!ZweiteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        return Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY] + 7);
                    } catch { }
                }
            }
            return 2147483647;
        }

        public int SucheLinkeZahl(Ziel aktuellePosition, Etage aktuelleEtage)
        {
            if (aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY - 1]);
                } catch { }
            }
            else if (aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY - 1]);
                } catch { }
            }
            return 2147483647;
        }

        public int SucheRechteZahl(Ziel aktuellePosition, Etage aktuelleEtage)
        {
            if (aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY + 1]);
                } catch { }
            }
            else if (aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY + 1]);
                } catch { }
            }
            return 2147483647;
        }

        public int SucheHintereZahl(Ziel aktuellePosition, Etage aktuelleEtage)
        {
            if (aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX - 1, aktuellePosition.PositionY]);
                } catch { }
            }
            else if (aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX - 1, aktuellePosition.PositionY]);
                } catch { }
            }
            return 2147483647;
        }

        public int SucheVordereZahl(Ziel aktuellePosition, Etage aktuelleEtage)
        {
            if (aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX + 1, aktuellePosition.PositionY]);    
                } catch { }
            }
            else if (aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX + 1, aktuellePosition.PositionY]);
                } catch { }
            }
            return 2147483647;
        }

        public bool EntscheidenObAndereEtage(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (andereEtageZahl < vordereZahl
                && andereEtageZahl < hintereZahl
                && andereEtageZahl < linkeZahl
                && andereEtageZahl < rechteZahl)
            {
                return true;
            }
            return false;
        }

        private bool PrüfungObEtagenwechsel(Ziel aktuellePosition, Etage aktuelleEtage)
        {
            if (aktuelleEtage == Etage.Erste)
            {
                if (ErsteEtage.UrsprünglichesZiel)
                {
                    if (Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) < Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) + 7)
                    {
                        return true;
                    }
                }
                else if (!ErsteEtage.UrsprünglichesZiel)
                {
                    if (Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) < Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) + 3)
                    {
                        return true;
                    }
                }
            }
            else if (aktuelleEtage == Etage.Zweite)
            {
                if (ZweiteEtage.UrsprünglichesZiel)
                {
                    if (Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) < Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) + 7)
                    {
                        return true;
                    }
                }
                else if (!ZweiteEtage.UrsprünglichesZiel)
                {
                    if (Convert.ToInt32(ZweiteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) < Convert.ToInt32(ErsteEtage.Grundriss[aktuellePosition.PositionX, aktuellePosition.PositionY]) + 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EntscheidenObNachLinks(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (linkeZahl < rechteZahl
                && linkeZahl < hintereZahl
                && linkeZahl < vordereZahl
                && linkeZahl < andereEtageZahl)
            {
                return true;
            }
            return false;
        }

        private bool EntscheidenObNachRechts(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (rechteZahl < hintereZahl
                && rechteZahl < linkeZahl
                && rechteZahl < vordereZahl
                && rechteZahl < andereEtageZahl)
            {
                return true;
            }
            return false;
        }

        private bool EntscheidenObNachHinten(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (hintereZahl < vordereZahl
                && hintereZahl < rechteZahl
                && hintereZahl < linkeZahl
                && hintereZahl < andereEtageZahl)
            {
                return true;
            }
            return false;
        }

        private bool EntscheidenObNachVorne(int vordereZahl, int hintereZahl, int rechteZahl, int linkeZahl, int andereEtageZahl)
        {
            if (vordereZahl < hintereZahl
                && vordereZahl < rechteZahl
                && vordereZahl < linkeZahl
                && vordereZahl < andereEtageZahl)
            {
                return true;
            }
            return false;
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
        private void NachHinten()
        {

        }
        private void NachLinks()
        {

        }
    }
}
