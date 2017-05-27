using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.IO;
using ClassLibrary.Repositorio;

namespace WebApplication
{
    public partial class Comprar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    Response.Redirect("~/Views/AdminListar.aspx");
                }
            }

            if (!IsPostBack)
            {
                CategoriaRepositorio carregaCategoria = new CategoriaRepositorio();

                List<Categoria> lstCategoria = carregaCategoria.ListarCategoria();

                RepeaterCategoria.DataSource = lstCategoria;
                RepeaterCategoria.DataBind();

            }


            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                lbNomeUsuario.Text = u.Nome;
                dvSemLogin.Visible = false;
                dvLogin.Visible = true;
            }
            else
            {
                dvLogin.Visible = false;
                dvSemLogin.Visible = true;
            }
        }
    }
}