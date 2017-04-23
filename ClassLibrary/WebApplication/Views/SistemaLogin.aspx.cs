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
            Usuario usuario = new Usuario();
            Criptografia criptografia = new Criptografia();

            usuario.Email = txtEmail.Text;
            usuario.Senha = criptografia.CriptografarSenha(txtSenha.Text);

            UsuarioRepositorio login = new UsuarioRepositorio();
            if (login.LoginUsuario(usuario))
            {
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
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Email ou senha inválidos.";
            }

        }
    }
}