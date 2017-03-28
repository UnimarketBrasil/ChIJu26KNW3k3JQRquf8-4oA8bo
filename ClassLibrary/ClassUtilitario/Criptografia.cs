using System;
using System.Security.Cryptography;
using System.Text;

namespace ClassUtilitario
{
    public class Criptografia
    {     
        public string CriptografarSenha(string senha)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(senha));
            
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("ChIJu26KNW3k3JQRquf8-4oA8bo"));
            }
         
            return sBuilder.ToString();
        }

    }
}
