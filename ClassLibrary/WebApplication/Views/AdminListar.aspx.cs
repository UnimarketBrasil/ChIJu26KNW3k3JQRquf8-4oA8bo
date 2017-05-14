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

            UsuarioRepositorio listarUsuarios = new UsuarioRepositorio();

            List<Usuario> lst = listarUsuarios.ListarUsuario();

            grdAdmin.DataSource = lst;
            grdAdmin.DataBind();
        }

        protected void grdAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAdmin.PageIndex = e.NewPageIndex;
            grdAdmin.DataBind();
        }

        protected void grdAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button status = null;

            for (int i = 0; i < grdAdmin.Rows.Count; i++)
            {
                status = (Button)grdAdmin.Rows[i].FindControl("btStatus");
                String state = status.CommandArgument.ToString();
                if (state.Equals("Ativo"))
                {
                    status.Text = "Bloquear";
                    status.CssClass = "btn btn-block btn-danger btn-sm";
                }
                else if (state.Equals("Pendênte"))
                {
                    status.Text = "Pendênte...";
                    status.CssClass = "btn btn-block btn-warning btn-sm disabled";
                    status.Enabled = false;
                }
                else if (state.Equals("Bloqueado"))
                {
                    status.Text = "Desbloquear";
                    status.CssClass = "btn btn-block btn-success btn-sm";
                }
            }
        }
    }
}