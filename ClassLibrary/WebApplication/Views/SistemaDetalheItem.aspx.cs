using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
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
                lbNomeProduto.Text = i.Nome;
                lbValorUnitario.Text = i.ValorUnitario.ToString();
                lbNomeVendedor.Text = i.Vendedor.Nome;
                lbEndereco.Text = "Falta buscar endereco";
                lbTelefone.Text = i.Vendedor.Telefone;
                lbEmailVendedor.Text = i.Vendedor.Email;
                lbDescricao.Text = i.Descricao;
                lbEndereco.Text = g.ObterEndereco(i.Vendedor.Latitude, i.Vendedor.Longitude);
                txtQuantidade.MaxLength = 2; // = Convert.ToInt32(i.Quantidade);
            }
        }
    }
}