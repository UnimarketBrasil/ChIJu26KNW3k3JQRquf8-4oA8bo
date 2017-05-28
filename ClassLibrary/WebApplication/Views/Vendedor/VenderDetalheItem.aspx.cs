using System;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace WebApplication
{
    public partial class SistemaNovoItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica se o usuario está logado
            if (Session["sistema"] == null)
                Response.Redirect("~/Views/SistemaLogin.aspx");


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

                //RECEBE ID DO ITEM POR PARAMETRO, CARREGA NA TELA OU CADASTRA NOVO PRODUTO
                if (int.TryParse(Request.QueryString["idItem"], out idItem) &&
                    carregaItem.DetalheItemVendedor(idItem, user.Id) != null)
                {
                    dvHeadNovo.Visible = false;
                    dvBtnNovo.Visible = false;
                    i = carregaItem.DetalheItemVendedor(idItem, user.Id);
                    txtNome.Text = i.Nome;
                    txtCod.Text = i.Codigo;
                    txtQuantidade.Text = i.Quantidade.ToString();
                    txtValorUnitario.Text = i.ValorUnitario.ToString();
                    txtDescricao.Value = i.Descricao.ToString();
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
                    dvBtnAlterar.Visible = false;
                }
            }
        }

        //ESTE METODO CADASTRA UM NOVO ITEM AO SISTEMA
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

            item.Vendedor = new Usuario();
            item.Vendedor.Id = u.Id;

            ItemRepositorio cadastrarItem = new ItemRepositorio();

            if (cadastrarItem.CadastrarItem(item))
            {
                var caminho = Server.MapPath(string.Format(@"~/Imagens/{0}/{1}/", item.Vendedor.Id, item.Id));

                Directory.CreateDirectory(caminho);

                if (InputFoto.HasFile)
                {
                    string formato = System.IO.Path.GetExtension(InputFoto.FileName);
                    if (formato == ".png" || formato == ".jpg" || formato == ".gif" || formato == ".jpeg")
                    {
                        InputFoto.PostedFile.SaveAs(Path.Combine(caminho, InputFoto.FileName));
                    }
                }
                else
                {
                    File.Copy(Server.MapPath(string.Format(@"~/Imagens/Sistema/ImagemPadrao.jpg")), caminho + "ImagemPadrao.jpg", true);
                }

                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                lbMsg.Text = "Cadastro realizado com sucesso!";
                Response.Redirect("~/Views/Vendedor/VenderItem.aspx");
            }
            else
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Erro ao cadastrar o item. Verifique as informações digitadas e tente novamente.";
            }
        }

        protected void btAtualizarItem_Click(object sender, EventArgs e)
        {
            Item item = new Item();

            item.Id = int.Parse(Request.QueryString["idItem"]);
           
            txtCod.Text = txtCod.Text.Replace(">", "");
            item.Codigo = txtCod.Text;
            txtNome.Text = txtNome.Text.Replace(">", "");
            item.Nome = txtNome.Text;
            item.Descricao = txtDescricao.InnerText;
            item.ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
            item.Quantidade = Convert.ToInt64(txtQuantidade.Text);

            item.Categoria = new Categoria(Convert.ToInt32(dpCategoria.SelectedValue));

            Usuario u = (Usuario)Session["sistema"];

            item.Vendedor = new Usuario();
            item.Vendedor.Id = u.Id;

            ItemRepositorio itemAtualizar = new ItemRepositorio();

            if (itemAtualizar.AtualizarItem(item))
            {
                          
                if (InputFoto.HasFile)
                {
                    var caminho = Server.MapPath(string.Format(@"~/Imagens/{0}/{1}/", item.Vendedor.Id, item.Id));

                    Directory.CreateDirectory(caminho);

                    DirectoryInfo dir = new DirectoryInfo((caminho));
                    dir.GetFiles("*", SearchOption.AllDirectories).ToList().ForEach(file => file.Delete());

                    InputFoto.PostedFile.SaveAs(Path.Combine(caminho, InputFoto.FileName));
                }
                                
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                lbMsg.Text = "Cadastro realizado com sucesso!";
                Response.Redirect("~/Views/Vendedor/VenderItem.aspx");
            }
            else
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Erro ao cadastrar o item. Verifique as informações digitadas e tente novamente.";
            }
        }

        protected void btnLixeira_Click(object sender, EventArgs e)
        {
            int idItem = Convert.ToInt32(Request.QueryString["idItem"]);
            ItemRepositorio deleteItem = new ItemRepositorio();

            if (deleteItem.DesabilitarItemPorId(idItem))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { chamaModal(); });", true);
            }
        }
    }
}