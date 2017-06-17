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
    public partial class EnviarDuvidaP_Vendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["sistema"];
            IsEmail enviarDuvida = new IsEmail();
            MailMessage message = new MailMessage();
            string urlItem = null;


            if (HttpContext.Current.Request.IsLocal)
            {
                urlItem = "http://localhost:49756/Views/SistemaDetalheItem.aspx?id" + Request.QueryString["idItem"].ToString();
            }
            else
            {
                urlItem = "http://unimarket.academico.trilema.com.br/Views/SistemaDetalheItem.aspx?id" + Request.QueryString["idItem"].ToString();
            }

            StringBuilder strBody;
            strBody = new StringBuilder();
            strBody.AppendLine("Olá " + Request.QueryString["NomeVendedor"].ToString() + "!");
            strBody.AppendLine("Registrei uma dúvida referente ao seu item...");
            strBody.AppendLine("");
            strBody.AppendLine("MINHA DÚVIDAS:");
            strBody.AppendLine(Request.QueryString["Duvida"].ToString());
            strBody.AppendLine("");
            strBody.AppendLine("DADOS DO ITEM:");
            strBody.AppendLine("Nome do item: " + Request.QueryString["NomeItem"].ToString());
            strBody.AppendLine("Descrição do item: " + Request.QueryString["DescricaoItem"].ToString());
            strBody.AppendLine("Link do item:" + urlItem);
            strBody.AppendLine("");
            strBody.AppendLine("MEUS DADOS (comprador):");
            strBody.AppendLine("Nome do comprador: " + u.Nome + " " + u.Sobrenome);
            strBody.AppendLine("E-mail: "+u.Email);
            strBody.AppendLine("Telefone: "+u.Telefone);
            strBody.AppendLine("Aguardo sua resposta...");
            strBody.AppendLine("");
            strBody.AppendLine("Unimarket Brasil");
            strBody.AppendLine("http://unimarket.academico.trilema.com.br");

            message = new MailMessage("unimarketbrasil@gmail.com", Request.QueryString["EmailVendedor"].ToString());
            message.Subject = "Unimarket Brasil - Dúvida";
            message.Body = strBody.ToString();

            enviarDuvida.Enviar(message);

            Response.Write("E-mail enviado com sucesso");

        }
    }
}