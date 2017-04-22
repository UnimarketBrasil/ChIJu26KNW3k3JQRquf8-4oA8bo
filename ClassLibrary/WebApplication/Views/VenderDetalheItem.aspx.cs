using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;
using System.Data;

namespace WebApplication
{
    public partial class SistemaNovoItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            Item i = new Item();

            i.Nome = txtNome.Text;
            i.Codigo = txtCod.Text;
            i.Quantidade = Convert.ToInt64(txtQuantidade.Text);
            i.ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
            i.Descricao = txtDescricao.InnerText;

            if (dpCategoria.SelectedValue == "1")
            {

                // Alimentos/Bebidas

                Categoria c = new Categoria();
                c.Nome = dpCategoria.Text;
            }
        }
    }
}