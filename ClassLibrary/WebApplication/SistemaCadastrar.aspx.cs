using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassUtilitario;

namespace WebApplication
{
    public partial class SistemaCadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dvSegundaEtapa.Visible = false;
        }

        protected void myButtonEtapa1_Click(object sender, EventArgs e)
        {
            IsEmail u = new IsEmail();
            if (u.ValidarEmail(txtEmailEtapa1.Text))
            {
                dvSegundaEtapa.Visible = true;
                dvPrimeiraEtapa.Visible = false;
                txtEmailEtapa2.Text = txtEmailEtapa1.Text;
            }
        }

        protected void myButtonEtapa2_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            u.Email = txtEmailEtapa2.Text;
            if (dpTipoPessoa.SelectedValue == "1")
            {
                u.Nome = txtNome.Text;
                u.Sobrenome = txtSobrenome.Text;
                u.CpfCnpj = txtCpf.Text;
                u.Nascimento = DateTime.Today;
                u.Genero = int.Parse(dpGenero.SelectedValue);
            }
            else
            {
                u.Nome = txtRazaoSocial.Text;
                u.Sobrenome = null;
                u.CpfCnpj = txtCnpj.Text;
                u.Nascimento = DateTime.Today;//Falta arrumar
            }
            u.Senha = txtSenha.Text;

            CriptografarSenha(u.Senha);

            u.Telefone = txtTel.Text;
            u.Tipousuario = new TipoUsuario(int.Parse(rdOperacao.SelectedValue));

            CadastrarUsuario(u);
        }
    }
}