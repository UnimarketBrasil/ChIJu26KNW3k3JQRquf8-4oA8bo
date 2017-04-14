using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SistemaListaPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            comprador.Visible = false;
            try
            {
                string s = Request.QueryString["type"];
                if (s.Equals("v"))
                {
                    comprador.Visible = false;
                    vendedor.Visible = true;
                }
                else
                {
                    comprador.Visible = true;
                    vendedor.Visible = false;
                }
            }
            catch
            {

            }
        }
    }
}