using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                lbNomeUsuario.Text = u.Nome;
            }
            else
            {
                Response.Redirect("~/Views/SistemaLogin.aspx");
            }
        }
    }
}