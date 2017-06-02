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
    public partial class SistemaDetalheItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dvMsg.Visible = false;
            if (Session["latlog"] == null & Session["sistema"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { chamaModal(); });", true);
                return;
            }
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

                //Este metodoo apresenta os detalhes do item clicado pelo usuario comprador
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
                else
                {
                    Response.Redirect("~/Views/Sistema.aspx");
                }
            }
        }

        //Este metodo adiciona um item ao carrinho de compras
        protected void btAdicionaCarrinho_Click(object sender, EventArgs e)
        {
            int quantidade;
            if (!int.TryParse(txtQuantidade.Text, out quantidade))
            {
                txtQuantidade.Text = 1.ToString();
                return;
            }
            else if (int.TryParse(txtQuantidade.Text, out quantidade))
            {
                if (quantidade < 1)
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-danger alert-dismissible";
                    lbMsg.Text = "Não foi possível atender sua solicitação.";

                    txtQuantidade.Text = 1.ToString();

                    return;
                }
            }

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
                        item.Quantidade = int.Parse(txtQuantidade.Text);
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

            Response.Redirect("/Views/SistemaCarrinho.aspx");
        }
    }
}