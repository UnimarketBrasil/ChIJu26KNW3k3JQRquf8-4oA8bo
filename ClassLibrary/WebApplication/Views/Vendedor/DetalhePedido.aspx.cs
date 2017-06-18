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
    public partial class DetalhePedidoVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] == null)
                Response.Redirect("~/Views/SistemaLogin.aspx");

            int idPedido = 0;

            idPedido = int.Parse(Request.QueryString["idPedido"]);

            Pedido pedido = new Pedido();
            pedido.Comprador = new Usuario();
            pedido.Id = idPedido;
            pedido.Vendedor = (Usuario)Session["sistema"];

            PedidoRepositorio carregaPedido = new PedidoRepositorio();

            pedido = carregaPedido.CarregarPedidoVendedor(pedido);

            lbNumPedido.Text = "Pedido: " + pedido.Codigo;
            lbComprador.Text = pedido.Comprador.Nome;
            lbValorTotal.Text = Math.Round(pedido.Valor, 2).ToString();
            lbStatus.Text = pedido.StatusPedido.Nome;
            lbTelefone.Text = pedido.Comprador.Telefone;
            lbEmailComprador.Text = pedido.Comprador.Email;
            lbNumComplemento.Text = pedido.Comprador.Numero + "/" + pedido.Comprador.Complemento;

            GeoCodificacao g = new GeoCodificacao();
            lbEndereco.Text = g.ObterEndereco(pedido.Vendedor);

            grdItens.DataSource = pedido.Item;
            grdItens.DataBind();
        }
    }
}