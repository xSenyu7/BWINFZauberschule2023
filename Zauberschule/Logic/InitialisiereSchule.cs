


namespace Zauberschule.Logic
{
    public class InitialisiereSchule
    {
        public string arrLänge;
        public string arrBreite;

        public void LängeUndBreiteDerArraysAuslesen(char[] textDatei)
        {
            for (int i = 0; i < textDatei.Length; i++)
            {
                if (char.IsNumber(textDatei[i]))
                {
                    arrLänge = arrLänge + textDatei[i];
                }
                else if (char.IsWhiteSpace(textDatei[i]))
                {
                    for (int j = i + 1; j < textDatei.Length; j++)
                    {
                        if (char.IsNumber(textDatei[j]))
                        {
                            arrBreite = arrBreite + textDatei[j];
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
