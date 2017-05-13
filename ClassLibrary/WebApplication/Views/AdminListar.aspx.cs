using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class AdminListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] == null)
                Response.Redirect("~/Views/Logout.aspx");

            Usuario user = (Usuario)Session["sistema"];

            UsuarioRepositorio listarUsuariosAdmin = new UsuarioRepositorio();

            List<Usuario> lst = listarUsuariosAdmin.ListarUsuario();

            grdAdmin.DataSource = lst;
            grdAdmin.DataBind();
        }

        protected void grdAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAdmin.PageIndex = e.NewPageIndex;
            grdAdmin.DataBind();
        }
    }
}