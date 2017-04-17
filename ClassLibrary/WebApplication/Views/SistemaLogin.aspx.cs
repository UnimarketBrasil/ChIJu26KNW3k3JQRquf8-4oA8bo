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
            dvMsg.Visible = true;
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
                    //Não foi possível atender sua solicitação
                    Response.Redirect("");
                }

            }
            else
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                lbMsg.Text = "Uma mensagem aqui";
            }

        }
    }
}