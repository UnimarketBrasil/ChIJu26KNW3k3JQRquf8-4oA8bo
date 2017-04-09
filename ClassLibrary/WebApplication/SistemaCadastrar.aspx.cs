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
    public partial class SistemaCadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dvSegundaEtapa.Visible = false;
            }
        }

        protected void Validar_Click(object sender, EventArgs e)
        {
            IsEmail u = new IsEmail();
            if (u.ValidarEmail(txtEmailEtapa1.Text))
            {
                dvSegundaEtapa.Visible = true;
                dvPrimeiraEtapa.Visible = false;
                txtEmailEtapa2.Text = txtEmailEtapa1.Text;
                //dvPessoaJuridica.Visible = false;
            }
        }

        protected void myButtonEtapa2_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            u.Email = txtEmailEtapa2.Text;

            if (dpTipoPessoa.SelectedValue == "1")//SE 1 ENTÃO PESSOA FÍSICA, SE 2 ENTÃO PESSOA JURÍDICA.
            {
                u.Nome = txtNome.Text;
                u.Sobrenome = txtSobrenome.Text;
                u.Nascimento = DateTime.Today;
                u.Genero = int.Parse(dpGenero.SelectedValue);

                IsCpfCnpj cpf = new IsCpfCnpj();
                if (cpf.ValidarCpfCnpj(txtCpf.Text))
                {
                    u.CpfCnpj = txtCpf.Text;
                }
            }
            else
            {

                u.Nome = txtRazaoSocial.Text;
                u.Nascimento = DateTime.Today;//Falta arrumar PERMITIR NULL

                IsCpfCnpj cnpj = new IsCpfCnpj();
                if (cnpj.ValidarCpfCnpj(txtCnpj.Text))
                {
                    u.CpfCnpj = txtCnpj.Text;
                }
            }

            u.CpfCnpj = txtCpf.Text;
            Criptografia criptografia = new Criptografia();
            u.Senha = criptografia.CriptografarSenha(txtSenha.Text);

            u.Telefone = txtTel.Text;

            //u.Tipousuario = new TipoUsuario(int.Parse(rdOperacao.SelectedValue));

            UsuarioRepositorio cadastrar = new UsuarioRepositorio();
            cadastrar.CadastrarUsuario(u);

        }

        protected void txtEndereco_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(txtEndereco.Text).Length == 8|| Convert.ToString(txtEndereco.Text).Where(c => char.IsNumber(c)).Count() > 0)
            {
                try
                {
                    DataSet ds = new DataSet();

                    string cep = txtEndereco.Text.Trim();

                    ds.ReadXml("https://viacep.com.br/ws/" + cep + "/xml/");
                    if (ds != null && ds.Tables[0].Columns.Count > 5)
                    {
                        string endereco = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                        string bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                        string cidade = ds.Tables[0].Rows[0]["localidade"].ToString().Trim();
                        string uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                        

                    }
                }
                catch
                {

                }
            }
            else
            {

            }
        }
    }
}