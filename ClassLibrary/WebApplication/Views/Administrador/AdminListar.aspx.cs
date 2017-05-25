using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
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
            //Lista todos os usuarios cadastrados no sistema e preenche a grid do home Administrador com as seguintes informações: 
            //ID, EMAIL, NOME OU RAZÃO SOCIAL, TIPO DE USUARIO E STATUS DO USUARIO 
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

        //Este metodo altera o botão na grid view conforme o status do usuario
        protected void grdAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button status = null;

            for (int i = 0; i < grdAdmin.Rows.Count; i++)
            {
                status = (Button)grdAdmin.Rows[i].FindControl("btStatus");
                String[] state = new string[2];
                state = status.CommandArgument.ToString().Split(',');
                if (state[0].Equals("Ativo"))
                {
                    status.Text = "Bloquear";
                    status.CssClass = "btn btn-block btn-danger btn-sm";
                }
                else if (state[0].Equals("Pendênte"))
                {
                    status.Text = "Pendênte...";
                    status.CssClass = "btn btn-block btn-warning btn-sm disabled";
                    status.Enabled = false;
                }
                else if (state[0].Equals("Bloqueado"))
                {
                    status.Text = "Desbloquear";
                    status.CssClass = "btn btn-block btn-success btn-sm";
                }
            }
        }

        //Bloqueia ou desbloqueia o usuario
        protected void btStatus_Command(object sender, CommandEventArgs e)
        {
            String[] state = new string[2];
            state = e.CommandArgument.ToString().Split(',');

            UsuarioRepositorio bloq_desblo = new UsuarioRepositorio();

            switch (state[0])
            {
                case "Ativo":
                    bloq_desblo.BloquearUsuario(Convert.ToInt32(state[1]));
                    break;

                case "Bloqueado":
                    bloq_desblo.DesbloquearUsuario(Convert.ToInt32(state[1]));
                    break;

                default:
                    break;
            }
            Response.Redirect(Request.RawUrl);

        }

        protected void PDF_Click(object sender, EventArgs e)
        {
            UsuarioRepositorio l = new UsuarioRepositorio();                 
            MemoryStream m = new MemoryStream();
            Pdf pdf = new Pdf();
            pdf.PdfUsuario(l.ListarUsuario(), m);
            Response.ContentType = "Application/pdf";
            Response.BinaryWrite(m.GetBuffer());
            Response.End();
           
        }
    }
}