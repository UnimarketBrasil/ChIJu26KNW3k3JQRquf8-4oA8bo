using ClassLibrary;
using ClassLibrary.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pesquisa = Request.QueryString["buscar"];


            if (Session["sistema"] != null)
            {
                ItemRepositorio itemPesquisa = new ItemRepositorio();
                Usuario u = (Usuario)Session["sistema"];

                //CASO NÃO SEJA DIGITADO NADA NA PESQUISA, O SISTEMA APRESENTA A TELA DE ERRO
                if(String.IsNullOrEmpty(pesquisa) == true) {
                    Response.Redirect("~/Views/SistemaErro.aspx");
                }

                //CASO SEJA DIGITADO ALGO NA PESQUISA, O SISTEMA RETORNA O RESULTADO DA MESMA
                else
                {
                    List<Item> lst = itemPesquisa.MecanismoDeBusca(pesquisa, u);
                    lbItens.DataSource = lst;
                    lbItens.DataBind();
                }
            }
            else
            {
              
            }
        }
    }
}