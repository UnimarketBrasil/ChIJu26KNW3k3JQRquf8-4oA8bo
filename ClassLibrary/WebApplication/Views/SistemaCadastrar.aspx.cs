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
                dvPessoaJuridica.Visible = false;
                dvMsg.Visible = false;
                
            }
        }

        protected void btValidar_Click(object sender, EventArgs e)
        {
                dvSegundaEtapa.Visible = true;
                dvPrimeiraEtapa.Visible = false;
                txtEmailEtapa2.Text = txtEmailEtapa1.Text;
        }


        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Usuario u = new Usuario();
                GeoCodificacao g = new GeoCodificacao();

               u = g.ObterCoordenadas(u, txtEndereco.Text, txtNumero.Text);

                Session["latlog"] = u;
            }
            catch
            {

            }
        }

        protected void btCadastrar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            if (dpTipoPessoa.SelectedValue == "2")//PESSOA JURÍDICA
            {
                IsCpfCnpj cnpj = new IsCpfCnpj();
                txtCnpj.Text = txtCnpj.Text.Replace(">", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");
                if (cnpj.validarCpfCnpj(txtCnpj.Text))
                {
                    u.CpfCnpj = txtCnpj.Text;
                }
                else
                {
                    txtCnpj.Text = null;
                    txtCnpj.BorderColor = System.Drawing.Color.Red;
                }
                u.Nome = txtRazaoSocial.Text;
                u.Nascimento = DateTime.Today;//Falta arrumar PERMITIR NULL
            }
            else if (dpTipoPessoa.SelectedValue == "1")//PESSOA FÍSICA
            {
                IsCpfCnpj cpf = new IsCpfCnpj();
                txtCpf.Text = txtCpf.Text.Replace(">", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("/","");
                if (cpf.validarCpfCnpj(txtCpf.Text))
                {
                    u.CpfCnpj = txtCpf.Text;
                }
                else
                {
                    txtCpf.Text = "";
                    txtCpf.BorderColor = System.Drawing.Color.Red;
                }
                u.Nome = txtNome.Text;
                u.Sobrenome = txtSobrenome.Text;
                u.Nascimento = DateTime.Today;//Falta arrumar a data de nascimento.
                u.Genero = int.Parse(dpGenero.SelectedValue);
            }
            else
            {
                //Se não é pessoa física nem jurídica não cadastra
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-danger alert-dismissible";
                
                lbMsg.Text = "Uma mensagem aqui";
            }
            u.Email = txtEmailEtapa2.Text;
            u.Telefone = txtTel.Text;

            /*
                ->Tem que receber senha criptografia do usuário (criptografia temporária...). 
            */

            Criptografia criptografia = new Criptografia();
            u.Senha = criptografia.CriptografarSenha(txtSenha.Text);

            if (rdComprar.Checked == true)
            {
                u.Tipousuario = new TipoUsuario(int.Parse(rdComprar.Value));
                u.AreaAtuacao = 0.1;//É necessário verificar porque não está aceitando null
            }
            else if (rdVender.Checked == true)
            {
                u.Tipousuario = new TipoUsuario(int.Parse(rdVender.Value));
                u.AreaAtuacao = Convert.ToDouble(dpArea.SelectedValue);
            }
            else
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-danger alert-dismissible";
                lbMsg.Text = "Uma mensagem aqui";
            }
            Usuario uEndereco = (Usuario)Session["latlog"];

            u.Latitude = uEndereco.Latitude;
            u.Longitude = uEndereco.Longitude;
            u.Complemento = txtComplemento.Text;
            

            UsuarioRepositorio cadastrar = new UsuarioRepositorio();
            if (cadastrar.CadastrarUsuario(u))
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                lbMsg.Text = "Cadastro realizado com sucesso";
            }
            else
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Não foi possível atender sua solucitação, tente novamente mais tarde.";
            }
            //u.Tipousuario = new TipoUsuario(int.Parse(rdOperacao.SelectedValue));
        }

        protected void dpTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpTipoPessoa.SelectedValue=="1")//Significa que é pessoa fisica
            {
                dvPessoaJuridica.Visible = false;
                dvPessoaFisica.Visible = true;
            }else if(dpTipoPessoa.SelectedValue=="2"){//Significa que é pessoa jurídica
                dvPessoaFisica.Visible = false;
                dvPessoaJuridica.Visible = true;
            }
            else
            {

            }
        }
    }
}