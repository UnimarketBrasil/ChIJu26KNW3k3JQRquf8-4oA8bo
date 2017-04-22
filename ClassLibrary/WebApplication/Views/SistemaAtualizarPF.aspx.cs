using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    this.Page.MasterPageFile = "~/Admin.Master";
                }
                else if (u.Tipousuario.Id == 2)
                {
                    this.Page.MasterPageFile = "~/Comprar.Master";
                }
                else if (u.Tipousuario.Id == 3)
                {
                    this.Page.MasterPageFile = "~/Vender.Master";
                }
                else
                {
                    Response.Redirect("~/Views/SistemaErro.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Views/SistemaLogin.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                dvMsg.Visible = false;
            }
            else
            {
                Response.Redirect("~/Views/SistemaLogin.aspx");
            }

        }
    }
}