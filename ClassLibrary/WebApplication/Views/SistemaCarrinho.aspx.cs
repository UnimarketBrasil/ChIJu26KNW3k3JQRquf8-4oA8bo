using ClassLibrary;
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
                dvMsg.Attributes["class"] = "info";
                lbMsg.Text = "Seu carrinho de compras está vazio...<a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=6' target='_blank'></a>";
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

    }
}