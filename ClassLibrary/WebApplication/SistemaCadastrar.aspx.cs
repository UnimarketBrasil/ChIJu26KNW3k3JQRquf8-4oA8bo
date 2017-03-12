using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

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
            Utilidade u = new Utilidade();
            if (u.validarEmail(txtEmailEtapa1.Text))
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
            if (dpTipoPessoa.SelectedIndex == 1)
            {
                u.Nome = txtNome.Text;
                u.CpfCnpj = txtCpf.Text;
                u.Nascimento = DateTime.Today;
                u.Senha = txtSenha.Text;
                u.Genero = 1;
                u.Telefone = txtTel.Text;

            }

            u.CadastrarUsuario(u);
        }
    }
}