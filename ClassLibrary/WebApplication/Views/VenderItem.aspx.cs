using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApplication
{
    public partial class SistemaHomeVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}