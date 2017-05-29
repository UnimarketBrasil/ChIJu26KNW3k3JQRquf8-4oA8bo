using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class DetalhePedidoComprador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idPedido = 0;

            idPedido = int.Parse(Request.QueryString["idPedido"]);

            Pedido pedido = new Pedido();
            pedido.Vendedor = new Usuario();
            pedido.Id = idPedido;
            pedido.Comprador = (Usuario)Session["sistema"];

            PedidoRepositorio carregaPedido = new PedidoRepositorio();

            pedido = carregaPedido.CarregarPedidoComprador(pedido);

            lbNumPedido.Text = pedido.Codigo;
            lbVendedor.Text = pedido.Vendedor.Nome;
            lbValorTotal.Text = pedido.Valor.ToString();
            lbStatus.Text = pedido.StatusPedido.Nome;
            lbTelefone.Text = pedido.Vendedor.Telefone;
            lbEmailVendedor.Text = pedido.Vendedor.Email;
            lbNumComplemento.Text = pedido.Vendedor.Numero + "/" + pedido.Vendedor.Complemento;

            GeoCodificacao g = new GeoCodificacao();
            lbEndereco.Text = g.ObterEndereco(pedido.Vendedor);

            grdItens.DataSource = pedido.Item;
            grdItens.DataBind();

        }
    }
}