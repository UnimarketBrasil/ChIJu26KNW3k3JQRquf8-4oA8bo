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
using System.IO;

namespace WebApplication
{
    public partial class SistemaCadastrar : System.Web.UI.Page
    {
        //EVENTO AO CARREGAR A TELA DE CADASTRO
        protected void Page_Load(object sender, EventArgs e)
        {
            //SIGNINFICA QUE O USUÁRIO ESTÁ LOGADO
            if (Session["sistema"] != null)
            {
                Response.Redirect("~/Views/Sistema.aspx");
            }

            //SE DIFERENTE DE IsPostBack, SEGUNDA ETAPA DO CADASTRO NÃO EXIBIR MENSAGEM
            if (!IsPostBack)
            {
                dvSegundaEtapa.Visible = false;
                dvPessoaJuridica.Visible = false;
                dvMsg.Visible = false;
            }
        }

        //EVENTO DA PRIMEIRA FASE DO CADASTRO, INFORMAR E-MAIL VÁLIDO 
        protected void btValidar_Click(object sender, EventArgs e)
        {
            dvSegundaEtapa.Visible = true;
            dvPrimeiraEtapa.Visible = false;
            txtEmailEtapa2.Text = txtEmailEtapa1.Text;
        }

        //AO CLICAR NO BOTÃO CADASTRAR
        protected void btCadastrar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            //VARIFICAR QUAL O TIPO DE PESSOA (FÍSICA OU JURÍDICA)
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
                u.Genero = int.Parse(dpGenero.SelectedValue);
            }

            //VERIFICAR SE O E-MAIL É VÁLIDO
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

            //CRIPTOGRAFA A SENHA
            Criptografia criptografia = new Criptografia();
            u.Senha = criptografia.CriptografarSenha(txtSenha.Text);

            //VERIFICAR QUAL O TIPO DE USUÁRIO
            if (rdComprar.Checked == true)
            {
                u.Tipousuario = new TipoUsuario(int.Parse(rdComprar.Value));
                u.AreaAtuacao = 5;
            }
            else if (rdVender.Checked == true)
            {
                u.Tipousuario = new TipoUsuario(int.Parse(rdVender.Value));
                u.AreaAtuacao = Convert.ToDouble(dpArea.SelectedValue);
            }

            //RECEEBR COORDENADAS DO ENDEREÇO DO USUÁRIO
            Usuario uEndereco = (Usuario)Session["latlog"];

            u.Latitude = uEndereco.Latitude;
            u.Longitude = uEndereco.Longitude;
            txtEndereco.Text = txtEndereco.Text.Replace("-", "");
            u.CEP = txtEndereco.Text;
            u.Complemento = txtComplemento.Text;
            u.Numero = int.Parse(txtNumero.Text);

            //CRIAR UM HASH PARA CONFIRMAÇÃO DE CADASTRO POR E-MAIL
            HashConfirmacao hc = new HashConfirmacao();
            u.HashConfirmacao = hc.GerarHash(30);

            UsuarioRepositorio cadastrar = new UsuarioRepositorio();

            //VERIFICAR SE E-MAIL JÁ POSSUI CADASTRO
            string existe = cadastrar.ValidarEmailCpfCnpj(u);

            //SE NÃO POSSUI CADASTRO, CADASTRAR
            if (existe==null)
            {
                if (cadastrar.CadastrarUsuario(u))
                {
                    //GERAR LINK DE CONFIRMAÇÃO
                    MailMessage message = null;
                    IsEmail enviarConf = new IsEmail();
                    string urlConf = null;
                    StringBuilder strBody;

                    if (HttpContext.Current.Request.IsLocal)
                    {
                        urlConf = "http://localhost:49756/ConfirmarCadastro.aspx?Hash=" + u.HashConfirmacao;
                    }
                    else
                    {
                        urlConf = "http://unimarket.academico.trilema.com.br/ConfirmarCadastro.aspx?Hash=" + u.HashConfirmacao;
                    }
                    //GERAR MENSAGEM PARA ENVIAR POR E-MAIL PARA O USUÁRIO
                    strBody = new StringBuilder();
                    strBody.AppendLine("Seja bem vindo(a) ao Unimarket, " + u.Nome + "!");
                    strBody.AppendLine("Complete seu cadastro clicando no link abaixo, para começar a usar o sistema:");
                    strBody.AppendLine("");
                    strBody.AppendLine("" + urlConf + "");
                    strBody.AppendLine("");
                    strBody.AppendLine("Unimarket Brasil");
                    strBody.AppendLine("http://unimarket.academico.trilema.com.br");

                    //ENVIAR LINK PARA CONFIRMAÇÃO DE CADASTRO POR E-MAIL
                    using (message = new MailMessage("unimarketbrasil@gmail.com", u.Email.ToString())
                    {

                        Subject = "Confirmação de Cadastro",
                        Body = strBody.ToString()

                    })

                        enviarConf.Enviar(message);
                    //ENVIAR E-MAIL PARA: unimarketbrasil@gmail.com, INFORMANDO NOVO CADASTRO DE USUÁRIO
                    strBody = new StringBuilder();
                    strBody.AppendLine("NOVO USUÁRIO");
                    strBody.AppendLine("Id: "+u.Id);
                    strBody.AppendLine("Nome: "+ u.Nome +" "+u.Sobrenome);
                    strBody.AppendLine("E-mail: "+u.Email);
                    strBody.AppendLine("Dt. Cadastro: "+ DateTime.Now);
                    strBody.AppendLine("Telefone: "+ u.Telefone);
                    strBody.AppendLine("");
                    strBody.AppendLine("Unimarket Brasil");

                    using (message = new MailMessage("unimarketbrasil@gmail.com", "unimarketbrasil@gmail.com")
                    {
                        Subject = "Novo usuário",
                        Body = strBody.ToString()
                    })

                        enviarConf.Enviar(message);

                    //CADASTRAR IMAGEM PADRÃO
                    var caminho = Server.MapPath(string.Format(@"~/Imagens/{0}/Perfil/", u.Id));

                    Directory.CreateDirectory(caminho);

                    File.Copy(Server.MapPath(string.Format(@"~/Imagens/Sistema/ImagemPadrao.jpg")), caminho + "ImagemPadrao.jpg", true);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { cadastroConcluido(); });", true);
                    return;

                }
                else
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "Não foi possível atender sua solicitação, tente novamente mais tarde.";
                }
            }
            //SE POSSUI CADASTRO, TRATAR E INFORMAR PARA O USUÁRIO QUE JÁ ESTÁ CADASTRADO
            else if (existe!=null)
            {
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
                    lbMsg.Text = "E-mail já está cadastrado no sistema.<a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=7' target='_blank'></a>";
                }
                else if (existe.Equals("CpfCnpj"))
                {
                    if (u.CpfCnpj.Length == 11)
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                        lbMsg.Text = "CPF já cadastrado. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=8' target='_blank'></a>";
                    }
                    else if (u.CpfCnpj.Length == 14)
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                        lbMsg.Text = "CNPJ já cadastrado. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=9' target='_blank'></a>";
                    }
                }
            }
        }

        //CARREGAR CAMPO DO TIPO DE PESSOA
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