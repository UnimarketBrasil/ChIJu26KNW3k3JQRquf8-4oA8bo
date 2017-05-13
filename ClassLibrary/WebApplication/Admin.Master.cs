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
                if (u.Tipousuario.Id == 1)
                {
                    lbNomeUsuario.Text = u.Nome;
                }
                else if (u.Tipousuario.Id == 2)
                {
                    Response.Redirect("~/Views/Sistema.aspx");
                }
                else if (u.Tipousuario.Id == 3)
                {
                    Response.Redirect("~/Views/VenderItem.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Views/Logout.aspx");
            }
        }
    }
}