


namespace Zauberschule.Logic
{
    public class InitialisiereSchule
    {
        public string arrLänge;
        public string arrBreite;
        public char[,] oberesStockwerk;
        public char[,] unteresStockwerk;

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

        public void OberesStockwerk(char[] textString)
        {
            foreach(char c in textString)
            {
                if (!!char.IsWhiteSpace(c) || !!char.IsNumber(c) || c != '\n')
                {
                    for(int i = 0; i < arrLänge.Length; i++)
                    {
                        for(int j = i + 1;j < textString.Length; j++)
                        {
                            //if (char.IsAscii(c))
                            //oberesStockwerk[i,j] = c;
                        }
                    }
                }
                else if (c == '\n')
                {
                    Console.WriteLine("Wir haben einen zeilenumbruch");
                }
            }
        }
    }
}
