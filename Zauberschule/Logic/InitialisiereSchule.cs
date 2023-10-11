


namespace Zauberschule.Logic
{
    public static class InitialisiereSchule
    {
        public static string arrLänge;
        public static string arrBreite;

        public static void LängeUndBreiteDerArraysAuslesen(char[] textDatei)
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
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
