using ClassLibrary;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Mail;

namespace ClassUtilitario
{
    public class IsEmail : Conexao
    {
        public bool  ValidarEmail(string email)
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

        public void Enviar(string emailUsuario)
        {
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("unimarketbrasil@gmail.com", "Unimarket2017")

            };

            using (var message = new System.Net.Mail.MailMessage("unimarketbrasil@gmail.com", "unimarketbrasil@gmail.com")
            {
                Subject = "Assunto",
                Body = "Este email é valido"
            })



            //e_mail.To.Add(emailUsuario);
            //e_mail.Subject = "UNIMARKET Brasil";
            //e_mail.From = new MailAddress("unimarketbrasil@gmail.com");
            //e_mail.Body = "Este email é valido";
            //e_mail.Priority = System.Net.Mail.MailPriority.High;
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.EnableSsl = true;
            //System.Net.NetworkCredential cred = new System.Net.NetworkCredential("unimarketbrasil@gmail.com", "Unimarket2017");
            //smtp.Credentials = cred;
            //smtp.UseDefaultCredentials = true;

            smtp.Send(message);

        }
    }
}









