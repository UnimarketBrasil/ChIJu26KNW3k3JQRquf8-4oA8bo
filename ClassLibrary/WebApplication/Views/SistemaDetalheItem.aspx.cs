using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idItem;
            try
            {
                idItem = int.Parse(Request.QueryString["id"]);
            }
            catch
            {
                Response.Redirect("~/Views/SistemaErro.aspx");
            }
            

        }
    }
}