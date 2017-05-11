using System;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;
using System.Data;
using System.IO;

namespace WebApplication
{
    public partial class SistemaNovoItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                lbMsg.Text = "Cadastro realizado com sucesso!";
            }
            else
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Erro ao cadastrar o item. Verifique as informações digitadas e tente novamente.";
            }
        }
    }
}