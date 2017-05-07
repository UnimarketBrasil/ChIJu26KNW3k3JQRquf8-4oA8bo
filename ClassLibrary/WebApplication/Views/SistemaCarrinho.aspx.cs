using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["sistema"];
            List<Item> lst = null;

            if (Session["carrinho"] == null)
            {
                lst = new List<Item>();
                Session["carrinho"] = lst;
            }
            else
            {
                lst = (List<Item>)Session["carrinho"];
            }

            lbItens.DataSource = lst;
            lbItens.DataBind();
        }
    }
}