using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class ConfirmarCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
                Response.Redirect("~/Views/Sistema.aspx");

            string hash = hash = Request.QueryString["Hash"];

            Usuario u = new Usuario();
            UsuarioRepositorio conf = new UsuarioRepositorio();

            u.HashConfirmacao = hash;
            if (conf.ConfirmarCadastro(u))
            {
                Response.Write("<script>alerta("+u.Tipousuario.Id.ToString() +")</script>");
                Session["sistema"] = u;
                if (u.Tipousuario.Id == 3)//Tipo de usuário vendedor
                {
                    Response.Redirect("~/Views/VenderItem.aspx");
                }
                else if (u.Tipousuario.Id == 2)//Tipo de usuário comprador
                {
                    Response.Redirect("~/Views/Sistema.aspx");
                }
                else if (u.Tipousuario.Id == 1)//Tipo de usuário administrador
                {
                    Response.Redirect("~/Views/AdminListar.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Views/Sistema.aspx");
            }
        }
    }
}