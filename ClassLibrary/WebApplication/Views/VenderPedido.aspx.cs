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

        }

        protected void blTabs_Click(object sender, BulletedListEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    Response.Write("<script>alert('Todos')</script>");
                    break;
                case 1:
                    Response.Write("<script>alert('Pendentes')</script>");
                    break;
                case 2:
                    Response.Write("<script>alert('cancelados')</script>");
                    break;
                default:
                    Response.Write("<script>alert('Finalizados')</script>");
                    break;

            }
        }
    }
}