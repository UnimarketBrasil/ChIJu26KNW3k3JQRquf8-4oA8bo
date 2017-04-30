using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;

namespace WebApplication
{
    public partial class SistemaHomeVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sistema"] != null)
            {
                 Item item = new Item();

                ItemRepositorio listarItens = new ItemRepositorio();
                Usuario u = (Usuario)Session["sistema"];

                item.Usuario = new Usuario(u.Id);

                grdDetalheVendedor.DataSource = listarItens.ListarItem(u.Id);
                grdDetalheVendedor.DataBind();

               // List<Item> listaItens = itemDisponivel.

                // grdDetalheVendedor.DataSource = itemDisponivel.DetalheItemVendedor;
                //grdDetalheVendedor.DataBind();*/
            }
        }
    }
}