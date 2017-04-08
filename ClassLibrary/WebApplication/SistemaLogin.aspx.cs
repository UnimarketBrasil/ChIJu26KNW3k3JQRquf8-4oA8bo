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
                Session["Sistema"] = usuario;
                Response.Redirect("");
            }
            else
            {

            }
            
        }
    }
}