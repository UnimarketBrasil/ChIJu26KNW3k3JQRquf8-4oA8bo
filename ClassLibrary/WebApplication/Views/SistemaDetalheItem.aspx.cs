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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idItem = 0;
                try
                {
                    idItem = int.Parse(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("~/Views/SistemaErro.aspx");
                }

                Item i = new Item();
                ItemRepositorio carregarItem = new ItemRepositorio();
                GeoCodificacao g = new GeoCodificacao();

                i = carregarItem.DetalheItem(idItem);

                if (i != null)
                {
                    lbIdItem.Text = i.Id.ToString();
                    lbNomeProduto.Text = i.Nome;
                    lbValorUnitario.Text = i.ValorUnitario.ToString();
                    lbTotal.Text = i.ValorUnitario.ToString();
                    lbNomeVendedor.Text = i.Vendedor.Nome;
                    lbEndereco.Text = "Falta buscar endereco";
                    lbTelefone.Text = i.Vendedor.Telefone;
                    lbEmailVendedor.Text = i.Vendedor.Email;
                    lbDescricao.Text = i.Descricao;
                    lbEndereco.Text = g.ObterEndereco(i.Vendedor.Latitude, i.Vendedor.Longitude);
                    txtQuantidade.MaxLength = 2; // = Convert.ToInt32(i.Quantidade);

                    string caminho = string.Format("~/Imagens/{0}/{1}/", i.Vendedor.Id, i.Id);

                    if (Directory.Exists(Server.MapPath(caminho)))
                    {
                        var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                        var arquivos = diretorio.GetFiles();
                        string img = arquivos.Last().Name;
                        imProduto.ImageUrl = ResolveUrl(Path.Combine(caminho, img));
                    }
                }
            }
        }

        protected void btAdicionaCarrinho_Click(object sender, EventArgs e)
        {
            Item i = new Item();
            ItemRepositorio carregaItem = new ItemRepositorio();
            List<Item> lst = new List<Item>();

            if (Session["carrinho"] == null)
            {
                i = carregaItem.DetalheItemCarrinho(int.Parse(lbIdItem.Text));
                i.Quantidade = int.Parse(txtQuantidade.Text);
                lst.Add(i);
                Session["carrinho"] = lst;
            }
            else if (Session["carrinho"] != null)
            {
                lst = (List<Item>)Session["carrinho"];

                bool achei = false;

                foreach (var item in lst)
                {
                    if (item.Id == int.Parse(lbIdItem.Text))
                    {
                        item.Quantidade += int.Parse(txtQuantidade.Text);
                        achei = true;
                    }
                }

                if (achei == false)
                {
                    i = carregaItem.DetalheItemCarrinho(int.Parse(lbIdItem.Text));
                    i.Quantidade = int.Parse(txtQuantidade.Text);
                    lst.Add(i);
                }

                Session["carrinho"] = lst;
            }
        }
    }
}