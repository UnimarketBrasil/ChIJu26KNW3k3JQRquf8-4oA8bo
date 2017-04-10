using System;
using System.Text.RegularExpressions;

namespace ClassUtilitario
{
    public class IsCpfCnpj
    {
        public bool validarCpfCnpj(string cpfCnpj)
        {
            cpfCnpj = cpfCnpj.Trim();
            cpfCnpj = cpfCnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cpfCnpj.Length==14)
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;
                
                if (cpfCnpj.Length != 14)
                    return false;
                tempCnpj = cpfCnpj.Substring(0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpfCnpj.EndsWith(digito);
            }
            else if(cpfCnpj.Length==11)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;

                if (cpfCnpj.Length != 11)
                    return false;
                tempCpf = cpfCnpj.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpfCnpj.EndsWith(digito);
            }
            else
            {
                return false;
            }
        }


        public bool sValidarCpfCnpj(string cpfCnpj)
        {
            cpfCnpj = cpfCnpj.Replace(".", "");
            cpfCnpj = cpfCnpj.Replace("-", "");
            cpfCnpj = cpfCnpj.Replace("/", "");

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
