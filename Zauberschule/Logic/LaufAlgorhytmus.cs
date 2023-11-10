
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

        public LaufAlgorhytmus(Schule schule, Ziel ziel, Person person)
        {
            Schulgebäude = schule;
            Ziel = ziel;
            Person = person;
            _ersteEtage = schule.ErsteEtage;
            _zweiteEtage = schule.ZweiteEtage;
            _aktuellePosition = new(Person.PositionX, Person.PositionY);
        }

        private Stockwerk _ersteEtage;
        private Stockwerk _zweiteEtage;
        private Ziel _aktuellePosition;
        private Etage _aktuelleEtage = Etage.Keine;

        public Schule SchnellstenWegFinden()
        {
            _aktuelleEtage = SucheNachAktuelleEtage();

            int vordereZahl;
            int hintereZahl;
            int rechteZahl;
            int linkeZahl;
            int andereEtageZahl;

            while (!AbfragenObAmZiel())
            {
                vordereZahl = SucheVordereZahl();
                hintereZahl = SucheHintereZahl();
                rechteZahl = SucheRechteZahl();
                linkeZahl = SucheLinkeZahl();
                andereEtageZahl = SucheAndereEtageZahl();

                if (_aktuelleEtage == Etage.Erste)
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
                        EtageHoch();
                    }
                }
                else if (_aktuelleEtage == Etage.Zweite)
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
            Schulgebäude.ErsteEtage = _ersteEtage;
            Schulgebäude.ZweiteEtage = _zweiteEtage;
            return Schulgebäude;
        }

        public int SucheAndereEtageZahl()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                if (_ersteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        int koordinatenZahl = Convert.ToInt32(_zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY]);
                        return koordinatenZahl + 7;
                    } catch { }
                }
                else if (!_ersteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        int koordinatenZahl = Convert.ToInt32(_ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY]);
                        return koordinatenZahl + 3;
                    } catch { }
                }

            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                if (_zweiteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        int koordinatenZahl = Convert.ToInt32(_ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY]);
                        return koordinatenZahl + 7;
                    } catch { }
                }
                else if (!_zweiteEtage.UrsprünglichesZiel)
                {
                    try
                    {
                        int koordinatenZahl = Convert.ToInt32(_zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY]);
                        return koordinatenZahl + 3;
                    } catch { }
                }
            }
            return 2147483647;
        }

        public int SucheLinkeZahl()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(_ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY - 1]);
                } catch { }
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(_zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY - 1]);
                } catch { }
            }
            return 2147483647;
        }

        public int SucheRechteZahl()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(_ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY + 1]);
                } catch { }
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(_zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY + 1]);
                } catch { }
            }
            return 2147483647;
        }

        public int SucheHintereZahl()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(_ersteEtage.Grundriss[_aktuellePosition.PositionX - 1, _aktuellePosition.PositionY]);
                } catch { }
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(_zweiteEtage.Grundriss[_aktuellePosition.PositionX - 1, _aktuellePosition.PositionY]);
                } catch { }
            }
            return 2147483647;
        }

        public int SucheVordereZahl()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                try
                {
                    return Convert.ToInt32(_ersteEtage.Grundriss[_aktuellePosition.PositionX + 1, _aktuellePosition.PositionY]);    
                } catch { }
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                try
                {
                    return Convert.ToInt32(_zweiteEtage.Grundriss[_aktuellePosition.PositionX + 1, _aktuellePosition.PositionY]);
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

        private bool AbfragenObAmZiel()
        {
            bool zielFrage;

            if(_aktuelleEtage == Etage.Erste)
            {
                if (_ersteEtage.Grundriss[_aktuellePosition.PositionX + 1, _aktuellePosition.PositionY] == "B")
                    return true;

                else if (_ersteEtage.Grundriss[_aktuellePosition.PositionX - 1, _aktuellePosition.PositionY] == "B")
                    return true;

                else if (_ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY + 1] == "B")
                    return true;

                else if (_ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY - 1] == "B")
                    return true;
                
                else if (_zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] == "B")
                    return true;
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                if (_zweiteEtage.Grundriss[_aktuellePosition.PositionX + 1, _aktuellePosition.PositionY] == "B")
                    return true;

                else if (_zweiteEtage.Grundriss[_aktuellePosition.PositionX - 1, _aktuellePosition.PositionY] == "B")
                    return true;
                
                else if (_zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY + 1] == "B")
                    return true;
                
                else if (_zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY - 1] == "B")
                    return true;
                
                else if (_ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] == "B")
                    return true;
            }
            return false;
        }

        private Etage SucheNachAktuelleEtage()
        {
            if (_ersteEtage.UrsprünglichePerson == true)
                _aktuelleEtage = Etage.Erste;
            
            else if (_zweiteEtage.UrsprünglichePerson == true)
                _aktuelleEtage = Etage.Zweite;
            
            return _aktuelleEtage;
        }

        private void EtageHoch()
        {
            _ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "!";
            _zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "!";
            _aktuelleEtage = Etage.Zweite;
        }
        private void EtageRunter()
        {
            _ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "!";
            _zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "!";
            _aktuelleEtage = Etage.Erste;
        }
        private void NachVorne()
        {
            if(_aktuelleEtage == Etage.Erste)
            {
                _ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "v";
                _aktuellePosition.PositionX++; 
            }
            else if(_aktuelleEtage == Etage.Zweite)
            {
                _zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "v";
                _aktuellePosition.PositionX++;
            }
        }
        private void NachRechts()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                _ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = ">";
                _aktuellePosition.PositionY++;
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                _zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = ">";
                _aktuellePosition.PositionY++;
            }
        }
        private void NachHinten()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                _ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "^";
                _aktuellePosition.PositionX--;
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                _zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "^";
                _aktuellePosition.PositionX--;
            }
        }
        private void NachLinks()
        {
            if (_aktuelleEtage == Etage.Erste)
            {
                _ersteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "<";
                _aktuellePosition.PositionY--;
            }
            else if (_aktuelleEtage == Etage.Zweite)
            {
                _zweiteEtage.Grundriss[_aktuellePosition.PositionX, _aktuellePosition.PositionY] = "<";
                _aktuellePosition.PositionY--;
            }
        }
    }
}
