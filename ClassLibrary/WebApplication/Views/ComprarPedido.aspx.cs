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
            if (Session["sistema"] != null)
            {

            }
            else
            {
                Response.Redirect("~/Views/SistemaLogin.aspx");
            }
        }

        protected void blTabs_Click(object sender, BulletedListEventArgs e)
        {
            Usuario user = (Usuario)Session["sistema"];
            PedidoRepositorio consulta = new PedidoRepositorio();


            switch (e.Index)
            {
                case 0:
                    List<Pedido> lstTodos = consulta.ListarPedidoComprador(user.Id);

                    grdPedido.DataSource = lstTodos;
                    grdPedido.DataBind();

                    break;
                case 1:
                    List<Pedido> lstPendentes = consulta.ListarPedidoPeloStatusComprador(user.Id, 1);

                    grdPedido.DataSource = lstPendentes;
                    grdPedido.DataBind();
                    break;
                case 2:
                    List<Pedido> lstCancelados = consulta.ListarPedidoPeloStatusComprador(user.Id, 3);

                    grdPedido.DataSource = lstCancelados;
                    grdPedido.DataBind();
                    break;
                case 3:
                    List<Pedido> lstFinalizados = consulta.ListarPedidoPeloStatusComprador(user.Id, 2);

                    grdPedido.DataSource = lstFinalizados;
                    grdPedido.DataBind();
                    break;
                default:

                    break;

            }
        }
    }
}