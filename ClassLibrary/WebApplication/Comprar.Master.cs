using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace WebApplication
{
    public partial class Comprar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {


                Usuario u = (Usuario)Session["sistema"];
                lbNomeUsuario.Text = u.Nome;
                dvSemLogin.Visible = false;
                dvLogin.Visible = true;
                dvCarrinho.Visible = true;
            }
            else
            {
                dvLogin.Visible = false;
                dvSemLogin.Visible = true;
            }
        }

        //protected void btPesquisa_Click(object sender, EventArgs e)
        //{

            //txtPesquisa.Text = txtPesquisa.Text.Replace(" ", "+");
            //Response.Redirect("~/Views/SistemaPesquisa.aspx?p="+txtPesquisa.Text);
        //}
    }
}