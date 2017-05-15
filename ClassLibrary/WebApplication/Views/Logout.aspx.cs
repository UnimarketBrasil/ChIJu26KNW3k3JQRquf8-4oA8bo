using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    //ESTE METODO ZERA A SESSION DO USUARIO PROVOCANDO SEU LOGOUT
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["sistema"] = null;
            Session["latlog"] = null;
            Session["carrinho"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}