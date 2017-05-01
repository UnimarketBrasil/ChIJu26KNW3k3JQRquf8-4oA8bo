using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Views
{
    public partial class SistemaAjuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pesquisa = Request.QueryString["help"];

            if (pesquisa.Equals("1"))
            {
                lbAjudaCabecalho.Text = "CONFIRMAÇÃO DE CADASTRO";
                lbAjudaCorpo.Text = "Falta pouco! Confirme seu cadastro para começar a usar o UNIMARKET.";
            }
            else if (pesquisa.Equals("2"))
            {
                lbAjudaCabecalho.Text = "CONTA BLOQUEADA";
                lbAjudaCorpo.Text = "O administrador do sistema bloqueou sua conta devido o mau uso do sistema, blá blá blá.";
            }
        }
    }
}