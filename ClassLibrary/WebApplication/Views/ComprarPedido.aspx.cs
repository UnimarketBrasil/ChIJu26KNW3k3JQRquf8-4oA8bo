using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void blTabs_Click(object sender, BulletedListEventArgs e)
        {
            Usuario user = (Usuario)Session["sistema"];
            PedidoRepositorio consulta = new PedidoRepositorio();


            switch (e.Index)
            {
                case 0:
                    List<Pedido> lst = consulta.ListarPedidoComprador(user.Id);

                    grdPedido.DataSource = lst;
                    grdPedido.DataBind();

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