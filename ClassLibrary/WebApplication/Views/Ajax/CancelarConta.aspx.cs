using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Views.Ajax
{
    public partial class CancelarConta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["sistema"];

            UsuarioRepositorio cancelar = new UsuarioRepositorio();

            if (cancelar.CancelarConta(u.Id))
            {
                Response.Redirect("~/Views/Logout.aspx");
            }
            else
            {
                Response.Write("erro");
            }

        }
    }
}