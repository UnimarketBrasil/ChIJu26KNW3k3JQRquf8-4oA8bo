using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SistemaCarrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ESTE METODO LISTA TODOS OS ITENS ADICIONADOS AO CARRINHO DE COMPRAS.
            if (Session["carrinho"] != null)
            {
                List<Item> lst = (List<Item>)Session["carrinho"];

                foreach (var item in lst)
                {
                    string caminho = string.Format("~/Imagens/{0}/{1}/", item.Vendedor.Id, item.Id);

                    if (Directory.Exists(Server.MapPath(caminho)))
                    {
                        var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                        var arquivos = diretorio.GetFiles();
                        string i = arquivos.Last().Name;
                        item.Imagem = ResolveUrl(Path.Combine(caminho, i));
                    }
                }

                grdCarrinhoDeCompra.DataSource = lst;
                grdCarrinhoDeCompra.DataBind();
            }
            else if (Session["carinho"] == null)
            {
                dvCarrinhoVazio.Visible = true;
                dvCarrinhoVazio.Attributes["class"] = "info";
            }
        }

        protected void grdCarrinhoDeCompra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCarrinhoDeCompra.PageIndex = e.NewPageIndex;
            grdCarrinhoDeCompra.DataBind();
        }

        protected void lnkExcluir_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            List<Item> lst = new List<Item>();
            lst = (List<Item>)Session["carrinho"];

            lst.RemoveAll((x) => x.Id == int.Parse(id));

            if (lst.Count == 0)
            {
                Session["carrinho"] = null;
            }
            else
            {
                Session["carrinho"] = lst;
            }

            Response.Redirect(Request.RawUrl);

        }

        protected void btConfirmarPedido_Click(object sender, EventArgs e)
        {

            if (Session["sistema"] == null)
            {
                dvFaltaLogin.Attributes["class"] = "info";
                dvFaltaLogin.Visible = true;
                return;
            }

            List<Item> lstItem = (List<Item>)Session["carrinho"];

            Usuario comprador = (Usuario)Session["sistema"];

            List<Pedido> lstPedido = new List<Pedido>();

            Pedido pedido = null;

            foreach (var item in lstItem.ToList())
            {
                if (lstPedido.Exists(x => x.Vendedor.Id == item.Vendedor.Id))
                {
                    foreach (var pedidoLista in lstPedido)
                    {
                        if (pedidoLista.Vendedor.Id == item.Vendedor.Id)
                        {
                            pedidoLista.Item = new List<Item>();
                            pedidoLista.Item.Add(item);
                        }
                    }
                }
                else
                {
                    pedido = new Pedido();
                    pedido.Codigo = "1";
                    pedido.Vendedor = new Usuario();
                    pedido.Comprador = new Usuario();
                    pedido.Comprador = comprador;
                    pedido.Vendedor.Id = item.Vendedor.Id;
                    pedido.Item = new List<Item>();
                    pedido.Item.Add(item);
                    lstItem.Remove(item);
                    lstPedido.Add(pedido);
                }

            }

            PedidoRepositorio realizarPedido = new PedidoRepositorio();

            foreach (var pedidoRealizar in lstPedido)
            {
                realizarPedido.RealizarPedido(pedidoRealizar);
            }
            Session["carrinho"] = null;
        }
    }
}