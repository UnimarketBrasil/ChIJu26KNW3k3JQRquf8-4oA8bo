using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Views.Ajax
{
    public partial class RecuperarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            UsuarioRepositorio uRecuperar = new UsuarioRepositorio();

            HashConfirmacao hc = new HashConfirmacao();

            string hash = hc.GerarHash(30).ToString();

            if (uRecuperar.RecuperarSenha(Request.QueryString["email"].ToString(), hash))
            {
                MailMessage message = null;
                IsEmail enviarConf = new IsEmail();

                string urlConf = null;
                if (HttpContext.Current.Request.IsLocal)
                {
                    urlConf = "http://localhost:49756/Views/SistemaRecuperarSenha.aspx?Hash=" + hash;
                }
                else
                {
                    urlConf = "http://unimarket.academico.trilema.com.br/Views/SistemaRecuperarSenha.aspx?Hash=" + hash;
                }

                StringBuilder strBody = new StringBuilder();
                strBody.AppendLine("Olá,");
                strBody.AppendLine("Clique no link abaixo para alterar sua senha:");
                strBody.AppendLine("");
                strBody.AppendLine("" + urlConf + "");
                strBody.AppendLine("");
                strBody.AppendLine("Unimarket Brasil");
                strBody.AppendLine("http://unimarket.academico.trilema.com.br");

                using (message = new MailMessage("unimarketbrasil@gmail.com", Request.QueryString["email"].ToString())
                {

                    Subject = "Recuperar / Alterar senha",
                    Body = strBody.ToString()

                })

                    enviarConf.Enviar(message);

                Response.Write("E-mail enviado com sucesso");
            }
            else
            {
                Response.Write("E-mail não localizado...");
            }

        }
    }
}