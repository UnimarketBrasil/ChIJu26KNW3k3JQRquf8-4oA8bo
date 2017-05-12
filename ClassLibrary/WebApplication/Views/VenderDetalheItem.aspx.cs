using System;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication
{
    public partial class SistemaNovoItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CARREGA LISTA DE CATEGORIAS
                CategoriaRepositorio carregaCategoria = new CategoriaRepositorio();

                List<Categoria> lstCategoria = new List<Categoria>();

                lstCategoria = carregaCategoria.ListarCategoria();

                dpCategoria.DataSource = lstCategoria;
                dpCategoria.DataBind();

                //
                ItemRepositorio carregaItem = new ItemRepositorio();
                Usuario user = (Usuario)Session["sistema"];
                Item i = new Item();
                int idItem = 0;

                //RECEBE ID DO ITEM POR PARAMETRO E CARREGA NA TELA OU CADASTRA NOVO PRODUTO
                if (int.TryParse(Request.QueryString["idItem"], out idItem) &&
                    carregaItem.DetalheItemVendedor(idItem, user.Id) != null)
                {
                    dvHeadNovo.Visible = false;
                    i = carregaItem.DetalheItemVendedor(idItem, user.Id);
                    txtNome.Text = i.Nome;
                    txtCod.Text = i.Codigo;
                    txtQuantidade.Text = i.Quantidade.ToString();
                    txtValorUnitario.Text = i.ValorUnitario.ToString();
                    txtDescricao.Value = i.Descricao + i.Id.ToString();
                    lbValorTotal.Text = (i.Quantidade * i.ValorUnitario).ToString();
                    dpCategoria.SelectedValue = i.Categoria.Id.ToString();

                    string caminho = string.Format("~/Imagens/{0}/{1}/", i.Vendedor.Id, i.Id);

                    if (Directory.Exists(Server.MapPath(caminho)))
                    {
                        var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                        var arquivos = diretorio.GetFiles();
                        string img = arquivos.Last().Name;
                        imItem.ImageUrl = ResolveUrl(Path.Combine(caminho, img));
                    }
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

                //dvMsg.Visible = true;
                //dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                //lbMsg.Text = "Cadastro realizado com sucesso!";
            }
            else
            {
                //dvMsg.Visible = true;
                //dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                //lbMsg.Text = "Erro ao cadastrar o item. Verifique as informações digitadas e tente novamente.";
            }
        }
    }
}