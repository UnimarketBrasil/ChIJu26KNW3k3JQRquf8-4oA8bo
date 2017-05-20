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
using System.Collections;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace WebApplication
{
    public partial class SistemaCadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                Response.Redirect("~/Views/Sistema.aspx");
            }

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
                    //txtCnpj.Text = null;
                    txtCnpj.BorderColor = System.Drawing.Color.Red;
                    return;
                }
                u.Nome = txtRazaoSocial.Text;
                u.Nascimento = DateTime.Today;//Falta arrumar a data de nascimento.
            }
            else if (dpTipoPessoa.SelectedValue == "1")//PESSOA FÍSICA
            {
                IsCpfCnpj cpf = new IsCpfCnpj();
                txtCpf.Text = txtCpf.Text.Replace(">", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");
                if (cpf.validarCpfCnpj(txtCpf.Text))
                {
                    u.CpfCnpj = txtCpf.Text;
                }
                else
                {
                    //txtCpf.Text = "";
                    txtCpf.BorderColor = System.Drawing.Color.Red;
                    return;
                }
                u.Nome = txtNome.Text;
                u.Sobrenome = txtSobrenome.Text;
                u.Nascimento = Convert.ToDateTime(txtDtNasc.Text);
                u.Genero = int.Parse(dpGenero.SelectedValue);
            }
            IsEmail mail = new IsEmail();
            if (mail.ValidarEmail(txtEmailEtapa2.Text))
            {
                u.Email = txtEmailEtapa2.Text;
            }
            else
            {
                txtEmailEtapa2.BorderColor = System.Drawing.Color.Red;
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                lbMsg.Text = "Por favor, digite um email válido.<a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=5' target='_blank'></a>";
                return;
            }
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
            Usuario uEndereco = (Usuario)Session["latlog"];

            u.Latitude = uEndereco.Latitude;
            u.Longitude = uEndereco.Longitude;
            u.Complemento = txtComplemento.Text;
            u.Numero = int.Parse(txtNumero.Text);
            u.UltimoAcesso = DateTime.Now;

            HashConfirmacao hc = new HashConfirmacao();
            u.HashConfirmacao = hc.GerarHash(30);

            UsuarioRepositorio cadastrar = new UsuarioRepositorio();

            SqlDataReader Dr = cadastrar.ValidarEmailCpfCnpj(u);

            if (!Dr.HasRows)
            {
                if (cadastrar.CadastrarUsuario(u))
                {
                    MailMessage message = null;
                    IsEmail enviarConf = new IsEmail();
                    HttpApplication serve = new HttpApplication();
                    string urlConf = null;
                    //if (serve.Request.IsLocal)
                    //{
                    //    urlConf = "http://localhost:49756/ConfirmarCadastro.aspx?Hash=" + u.HashConfirmacao;
                    //}
                    //else
                    //{
                    //    urlConf = "http://unimarket.academico.trilema.com.br/ConfirmarCadastro.aspx?Hash=" + u.HashConfirmacao;
                    //}
                    urlConf = "http://localhost:49756/ConfirmarCadastro.aspx?Hash=" + u.HashConfirmacao;

                    StringBuilder strBody = new StringBuilder();
                    strBody.AppendLine("Seja bem vindo ao Unimarket, "+u.Nome+"!");
                    strBody.AppendLine("Complete seu cadastro clicando no link abaixo, para começar a usar o sistema:");
                    strBody.AppendLine("");
                    strBody.AppendLine(""+urlConf+"");
                    strBody.AppendLine("");
                    strBody.AppendLine("Unimarket Brasil");
                    strBody.AppendLine("http://unimarket.academico.trilema.com.br");


                    using (message = new MailMessage("unimarketbrasil@gmail.com", u.Email.ToString())
                    {
                        
                        Subject = "Confirmação de Cadastro",
                        Body = strBody.ToString()

                    })
                        enviarConf.Enviar(message);

                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                    lbMsg.Text = "Cadastro realizado com sucesso!";
                }
                else
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "Não foi possível atender sua solicitação, tente novamente mais tarde.";
                }
            }
            else if (Dr.HasRows)
            {
                Dr.Read();
                string existe = Convert.ToString(Dr["Existe"]);
                if (existe.Equals("Email_CpfCnpj"))
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                    lbMsg.Text = "E-mail e CNPJ/CPJ já estão cadastrados no sistema.<a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=6' target='_blank'></a>";
                }
                else if (existe.Equals("Email"))
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                    lbMsg.Text = "O E-mail " + u.Email.ToString() + " já está cadastrado no sistema.<a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=7' target='_blank'></a>";
                }
                else if (existe.Equals("CpfCnpj"))
                {
                    if (existe.Length == 11)
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                        lbMsg.Text = "O CPF: " + u.CpfCnpj.ToString() + ", já cadastrado. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=8' target='_blank'></a>";
                    }
                    else if (existe.Length == 14)
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                        lbMsg.Text = "CNPJ: " + u.CpfCnpj + ", já cadastrado. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=9' target='_blank'></a>";
                    }
                }
            }
        }

        protected void dpTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpTipoPessoa.SelectedValue == "1")//Significa que é pessoa fisica
            {
                dvPessoaJuridica.Visible = false;
                dvPessoaFisica.Visible = true;
            }
            else if (dpTipoPessoa.SelectedValue == "2")
            {//Significa que é pessoa jurídica
                dvPessoaFisica.Visible = false;
                dvPessoaJuridica.Visible = true;
            }
            else
            {

            }
        }
    }
}