using System;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace WebApplication
{
    public partial class SistemaNovoItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaRepositorio carregaCategoria = new CategoriaRepositorio();

                List<Categoria> lstCategoria = new List<Categoria>();

                lstCategoria = carregaCategoria.ListarCategoria();

                dpCategoria.DataSource = lstCategoria;
                dpCategoria.DataBind();

                ItemRepositorio carregaItem = new ItemRepositorio();
                Usuario user = (Usuario)Session["sistema"];
                int idItem = 0;

                if (int.TryParse(Request.QueryString["idItem"], out idItem) &&
                    carregaItem.DetalheItemVendedor(idItem, user.Id) != null)
                {
                    dvHeadNovo.Visible = false;
                }
                else
                {
                    dvHeadAlterar.Visible = false;
                    dvExcluirItem.Visible = false;
                }
            }
        }

        protected void bt_CadastrarItem(object sender, EventArgs e)
        {
            Item item = new Item();

            txtCod.Text = txtCod.Text.Replace(">", "");
            item.Codigo = txtCod.Text;
            txtNome.Text = txtNome.Text.Replace(">", "");
            item.Nome = txtNome.Text;
            item.Descricao = txtDescricao.InnerText;
            item.ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
            item.Quantidade = Convert.ToInt64(txtQuantidade.Text);

            item.Categoria = new Categoria(Convert.ToInt32(dpCategoria.SelectedValue));

            Usuario u = (Usuario)Session["sistema"];

            item.Vendedor = new Usuario(u.Id);

            ItemRepositorio cadastrarItem = new ItemRepositorio();

            if (cadastrarItem.CadastrarItem(item))
            {
                var caminho = Server.MapPath(string.Format(@"~/Imagens/{0}/{1}/", u.Id, item.Id));

                Directory.CreateDirectory(caminho);

                InputFoto.PostedFile.SaveAs(Path.Combine(caminho, InputFoto.FileName));

                txtCod.Text = "Sucesso";
            }
            else
            {
                txtCod.Text = "Erro";
            }
        }
    }
}