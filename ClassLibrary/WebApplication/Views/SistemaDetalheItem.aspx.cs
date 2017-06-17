using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SistemaDetalheItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] == null)
                dvDuvida.Visible = false;


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
                    lbTelefone.Text = i.Vendedor.Telefone;
                    lbEmailVendedor.Text = i.Vendedor.Email;
                    lbDescricao.Text = i.Descricao;
                    lbEndereco.Text = g.ObterEndereco(i.Vendedor.Latitude, i.Vendedor.Longitude);
                    txtQuantidade.MaxLength = Convert.ToInt32(i.Quantidade);

                    string caminho = string.Format("~/Imagens/{0}/{1}/", i.Vendedor.Id, i.Id);

                    if (Directory.Exists(Server.MapPath(caminho)))
                    {
                        var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                        var arquivos = diretorio.GetFiles();
                        string img = arquivos.Last().Name;
                        imProduto.ImageUrl = ResolveUrl(Path.Combine(caminho, img));
                    }

                    //MÉTODOS DE PAGAMENTO DO VENDEDOR
                    MetodoPagamentoRepositorio carregaMetodos = new MetodoPagamentoRepositorio();
                    List<MetodoPagamento> mPagamentoList = new List<MetodoPagamento>();

                    mPagamentoList = carregaMetodos.ListarMetodoPagamento(i.Vendedor.Id);

                    foreach (var item in mPagamentoList)
                    {
                        if (item.tMetodoPgto.Id.Equals(2))
                        {
                            if (String.IsNullOrEmpty(lbCartaoDebito.Text))
                            {
                                lbCartaoDebito.Text = item.Nome;
                            }
                            else
                            {
                                lbCartaoDebito.Text += " - " + item.Nome;
                            }
                        }
                        else if (item.tMetodoPgto.Id.Equals(3))
                        {
                            if (String.IsNullOrEmpty(lbCartaoCredito.Text))
                            {
                                lbCartaoCredito.Text = item.Nome;
                            }
                            else
                            {
                                lbCartaoCredito.Text += " - " + item.Nome;
                            }
                        }
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

        protected void btDuvidaEmail_Click(object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["sistema"];
            IsEmail enviarDuvida = new IsEmail();
            MailMessage message = new MailMessage();
            string urlItem = null;


            if (HttpContext.Current.Request.IsLocal)
            {
                urlItem = "http://localhost:49756/Views/SistemaDetalheItem.aspx?id=" + lbIdItem;
            }
            else
            {
                urlItem = "http://unimarket.academico.trilema.com.br/Views/SistemaDetalheItem.aspx?id=" + lbIdItem;
            }

            StringBuilder strBody;
            strBody = new StringBuilder();
            strBody.AppendLine("Olá " + lbNomeVendedor + "!");
            strBody.AppendLine("Registri uma dúvida referente ao seu item...");
            strBody.AppendLine("");
            strBody.AppendLine("Nome do item: " + lbNomeProduto);
            strBody.AppendLine("Descrição do item: " + lbDescricao);
            strBody.AppendLine("Link do item:" + urlItem);
            strBody.AppendLine("");
            strBody.AppendLine("MINHA DÚVIDAS:");
            strBody.AppendLine(txtDuvida.Value);
            strBody.AppendLine("Unimarket Brasil");
            strBody.AppendLine("http://unimarket.academico.trilema.com.br");

            message = new MailMessage("unimarketbrasil@gmail.com", u.Email.ToString());
            message.Subject = "Unimarket Brasil - Dúvida";
            message.Body = strBody.ToString();
            message.To.Add(lbEmailVendedor.Text);

            enviarDuvida.Enviar(message);
        }
    }
}