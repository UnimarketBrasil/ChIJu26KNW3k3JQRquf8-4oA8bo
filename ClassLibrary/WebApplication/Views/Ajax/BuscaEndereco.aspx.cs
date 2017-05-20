using ClassLibrary;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Views.Ajax
{
    public partial class BuscaEndereco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            GeoCodificacao g = new GeoCodificacao();
            u = g.ObterCoordenadas(u, Request.QueryString["cep"], Request.QueryString["num"]);

            string rEndereco = g.ObterEndereco(u);

            if (rEndereco != null)
            {
                Session["latlog"] = u;
                Response.Write(rEndereco);
            }
            else
            {
                Response.Write("Desculpe, não localizamos o seu endereço...");
            }
        }
    }
}