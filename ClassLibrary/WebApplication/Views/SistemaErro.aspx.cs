using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SistemaErro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btErro_Click(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    Response.Redirect("~/Views/AdminListar.aspx");
                }
                else if (u.Tipousuario.Id == 3)
                {
                    Response.Redirect("~/Views/VenderItem.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/Sistema.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Views/Sistema.aspx");
            }

        }
    }
}