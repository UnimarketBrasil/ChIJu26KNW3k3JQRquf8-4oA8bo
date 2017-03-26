using System;
using System.Text.RegularExpressions;

namespace ClassUtilitario
{
    public class CpfCnpj
    {

        public bool ValidarCpfCnpj(string cpfCnpj)
        {
            if (string.IsNullOrEmpty(cpfCnpj))
            {
                return false;
            }

            else
            {
                int[] d;
                int[] v = new int[2];

                string Sequencia, soNumero;

                soNumero = Regex.Replace(cpfCnpj, "[^0-9]", string.Empty);

                if (soNumero.Length == 11)
                {
                    d = new int[11];

                    for (int i = 0; i <= 10; i++)
                    {
                        d[i] = Convert.ToInt32(soNumero.Substring(i, 1));
                    }

                    for (int i = 0; i <= 1; i++)
                    {
                        int soma = 0;

                        for (int j = 0; j <= 8 + i; j++)
                        {
                            soma += d[j] * (10 + i - j);
                        }  
                                       
                        v[i] = (soma) % 11;

                        if (v[i] == 10) v[i] = 0;
                    }

                    return (v[0] == d[9] & v[1] == d[10]);
                }
 
                else if (soNumero.Length == 14)
                {
                    d = new int[14];

                    Sequencia = "6543298765432";
                    for (int i = 0; i <= 13; i++) d[i] = Convert.ToInt32(soNumero.Substring(i, 1));
                    for (int i = 0; i <= 1; i++)
                    {
                        int soma = 0;
                        for (int j = 0; j <= 11 + i; j++)
                            soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                }

                else return false;
            }
        }
  
    }
}
