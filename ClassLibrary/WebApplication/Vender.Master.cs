using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Vender : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    Response.Redirect("~/Views/AdminListar.aspx");
                }
            }

            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                lbNomeUsuario.Text = u.Nome;
            }
            else
            {
                Response.Redirect("~/Views/Logout.aspx");
            }
        }
    }
}