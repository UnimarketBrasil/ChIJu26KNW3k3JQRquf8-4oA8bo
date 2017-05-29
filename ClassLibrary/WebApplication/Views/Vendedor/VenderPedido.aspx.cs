using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (Session["sistema"] == null)
                Response.Redirect("~/Views/Logout.aspx");
        }

        protected void blTabs_Click(object sender, BulletedListEventArgs e)
        {
            Usuario user = (Usuario)Session["sistema"];
            PedidoRepositorio consulta = new PedidoRepositorio();

            switch (e.Index)
            {

                case 0:
                    //Este case lista todos os pedidos na grid de pedidos do usuario vendedor
                    List<Pedido> lstTodos = consulta.ListarPedidoVendedor(user.Id);

                    grdPedido.DataSource = lstTodos;
                    grdPedido.DataBind();

                    break;
                case 1:
                    //Este case lista todos os pedidos pendentes na grid de pedidos do usuario vendedor
                    List<Pedido> lstPendentes = consulta.ListarPedidoPeloStatusVendedor(user.Id, 1);

                    grdPedido.DataSource = lstPendentes;
                    grdPedido.DataBind();
                    break;
                case 2:
                    //Este case lista todos os pedidos cancelados na grid de pedidos do usuario vendedor
                    List<Pedido> lstCancelados = consulta.ListarPedidoPeloStatusVendedor(user.Id, 3);

                    grdPedido.DataSource = lstCancelados;
                    grdPedido.DataBind();
                    break;
                case 3:
                    //Este case lista todos os pedidos finalizados na grid de pedidos do usuario vendedor
                    List<Pedido> lstFinalizados = consulta.ListarPedidoPeloStatusVendedor(user.Id, 2);

                    grdPedido.DataSource = lstFinalizados;
                    grdPedido.DataBind();
                    break;
                default:

                    break;
            }
        }

        protected void grdPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPedido.PageIndex = e.NewPageIndex;
            grdPedido.DataBind();
        }

        //Este metodo gera um relatorio em PDF do pedidos do usuario vendedor
        protected void pdfPedido_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Pedido")
            {
                string IdPedido = e.CommandArgument.ToString();
                Pedido pedido = new Pedido();
                pedido.Id = Convert.ToInt32(IdPedido);
                PedidoRepositorio p = new PedidoRepositorio();
                pedido = p.CarregarPedido(pedido);
                MemoryStream m = new MemoryStream();
                Pdf pdf = new Pdf();
                pdf.PedidoPdf(pedido, m);
                Response.ContentType = "Application/pdf";
                Response.BinaryWrite(m.GetBuffer());
                Response.End();
            }
        }

        protected void grdPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label status = null;
            Button cancelar = null;
            Button finalizar = null;

            for (int i = 0; i < grdPedido.Rows.Count; i++)
            {
                status = (Label)grdPedido.Rows[i].FindControl("lbStatus");
                String state = status.Text.ToString();

                cancelar = (Button)grdPedido.Rows[i].FindControl("btcancelar");
                finalizar = (Button)grdPedido.Rows[i].FindControl("btfinalizar");
                if (state.Equals("Finalizado") | state.Equals("Cancelado"))
                {
                    cancelar.Enabled = false;
                    finalizar.Enabled = false;
                }
            }
        }

        protected void btfinalizar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            PedidoRepositorio finalizarPedido = new PedidoRepositorio();

            finalizarPedido.FinalizarPedido(id);

            Response.Redirect(Request.RawUrl);
        }

        protected void btcancelar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            PedidoRepositorio cancelarPedido = new PedidoRepositorio();

            cancelarPedido.CancelarPedido(id);

            Response.Redirect(Request.RawUrl);
        }
    }
}