using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;

namespace WebApplication
{
    public partial class SistemaLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["EmailUsuario"] != null && Request.Cookies["SenhaUsuario"] != null)
                {
                    txtEmail.Text = Request.Cookies["EmailUsuario"].Value;
                    txtSenha.Attributes["value"] = Request.Cookies["SenhaUsuario"].Value;
                }
            }

            dvMsg.Visible = false;
            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    Response.Redirect("~/Views/AdminListar.aspx");
                }
                else if (u.Tipousuario.Id == 3)
                {
                    Response.Redirect("~/Views/VenderItem.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/Sistema.aspx");
                }
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            //Este metodo valida o login do usuario no sistema
            Usuario usuario = new Usuario();
            Criptografia criptografia = new Criptografia();

            usuario.Email = txtEmail.Text;
            //Comparados os hashs da criptografia
            usuario.Senha = criptografia.CriptografarSenha(txtSenha.Text);

            if (lembrarLogin.Checked)
            {

                Response.Cookies["EmailUsuario"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["SenhaUsuario"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {

                Response.Cookies["EmailUsuario"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["SenhaUsuario"].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Cookies["EmailUsuario"].Value = txtEmail.Text.Trim();
            Response.Cookies["SenhaUsuario"].Value = txtSenha.Text.Trim();

            UsuarioRepositorio login = new UsuarioRepositorio();
            if (login.LoginUsuario(usuario))
            {
                //Caso o usuario ainda não tenha confirmado seu cadastro via e-mail
                if (usuario.StatusUsuario.Id == 2)
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "<strong>Confirme seu cadastro</strong>, enviamos um link de confirmação para <a href='/Views/SistemaAjuda.aspx?help=1' target='_blank'><u>" + usuario.Email.ToString() + "</u></a>!";
                }
                //Caso sua conta esteja bloqueada
                else if (usuario.StatusUsuario.Id == 3)
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-danger alert-dismissible";
                    lbMsg.Text = "<strong>Conta bloqueada</strong>, entre em contato com o administrador do sistema. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=2' target='_blank'></a>";
                }
                else if (usuario.StatusUsuario.Id == 1)
                {
                    //A tela inicial depende do tipo do usuario que estiver fazendo login
                    Session["sistema"] = usuario;

                    if (usuario.Tipousuario.Id == 3)//Tipo de usuário vendedor
                    {
                        Response.Redirect("~/Views/VenderItem.aspx");
                    }
                    else if (usuario.Tipousuario.Id == 2)//Tipo de usuário comprador
                    {
                        Response.Redirect("~/Views/Sistema.aspx");
                    }
                    else if (usuario.Tipousuario.Id == 1)//Tipo de usuário administrador
                    {
                        Response.Redirect("~/Views/AdminListar.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Views/SistemaErro.aspx");
                    }
                }

                else
                {
                    //Caso o e-mail e a senha estiverem errados, o sistema informa através da mensagem
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "Email ou senha inválidos. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=3' target='_blank'></a>";
                }
            }
        }
    }
}