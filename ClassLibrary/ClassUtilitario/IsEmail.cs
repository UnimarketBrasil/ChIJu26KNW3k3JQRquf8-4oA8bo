using ClassLibrary;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ClassUtilitario
{
    public class IsEmail : Conexao
    {
        public bool ValidarEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Enviar(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient
            {

                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("unimarketbrasil@gmail.com", "Unimarket2017")

            };

            smtp.Send(message);

        }
        
    }
}









