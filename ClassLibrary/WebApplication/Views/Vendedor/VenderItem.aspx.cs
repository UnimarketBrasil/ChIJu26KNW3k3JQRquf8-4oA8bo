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
    public partial class VenderItem : System.Web.UI.Page
    {
        //ESTE METODO LISTA TODOS OS ITENS CADASTRADOS NA CONTA DO USUARIO VENDEDOR
        //A LISTA É EXIBIDA EM UMA GRID NA SUA TELA PRINCIPAL
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] == null)
                Response.Redirect("~/Views/Logout.aspx");

            Usuario user = (Usuario)Session["sistema"];

            ItemRepositorio listarItemVendedor = new ItemRepositorio();

            List<Item> lst = listarItemVendedor.ListarItem(user.Id);

            foreach (var item in lst)
            {
                string caminho = string.Format("~/Imagens/{0}/{1}/", user.Id, item.Id);

                if (Directory.Exists(Server.MapPath(caminho)))
                {
                    var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                    var arquivos = diretorio.GetFiles();
                    string i = arquivos.Last().Name;
                    item.Imagem = ResolveUrl(Path.Combine(caminho, i));
                }
            }
            grdDetalheVendedor.DataSource = lst;
            grdDetalheVendedor.DataBind();
        }

        protected void grdDetalheVendedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDetalheVendedor.PageIndex = e.NewPageIndex;
            grdDetalheVendedor.DataBind();
        }
    }
}