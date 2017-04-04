using ClassLibrary;
using System.Configuration;
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


            System.Net.Mail.MailMessage e_mail = new System.Net.Mail.MailMessage();
            e_mail.To.Add(emailUsuario);
            e_mail.Subject = "UNIMARKET Brasil";
            e_mail.From = new MailAddress("unimarketbrasil@gmail.com");
            e_mail.Body = "Este email é valido";
            e_mail.Priority = System.Net.Mail.MailPriority.High;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("unimarketbrasil@gmail.com", "unimarket2017");
            smtp.Credentials = cred;
            smtp.UseDefaultCredentials = true;

            smtp.Send(e_mail);

        }
    }
}
