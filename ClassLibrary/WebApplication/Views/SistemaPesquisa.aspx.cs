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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Recebe o conteudo da barra de pesquisa por parametro
            string pesquisa = Request.QueryString["buscar"];


            if (Session["sistema"] != null)
            {
                ItemRepositorio itemPesquisa = new ItemRepositorio();
                Usuario u = (Usuario)Session["sistema"];

                //CASO NÃO SEJA DIGITADO NADA NA PESQUISA, O SISTEMA APRESENTA A MENSAGEM INFORMANDO QUE O CAMPO PESQUISA ESTÁ VAZIO
                if (String.IsNullOrWhiteSpace(pesquisa) == true)
                {
                    divMsg.Visible = true;
                    divMsg.Attributes["class"] = "alert alert-dismissible alert-info";
                    msgPesquisa.Text = "<strong>Pesquisa Inválida</strong>. O campo de pesquisa está vazio.";
                }
                //CASO SEJA DIGITADO ALGO NA PESQUISA, O SISTEMA RETORNA O RESULTADO DA MESMA
                else
                {
                    List<Item> lst = itemPesquisa.MecanismoDeBusca(pesquisa, u);

                    foreach (var item in lst)
                    {
                        string caminho = string.Format("~/Imagens/{0}/{1}/", u.Id, item.Id);

                        if (Directory.Exists(Server.MapPath(caminho)))
                        {
                            var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                            var arquivos = diretorio.GetFiles();
                            string i = arquivos.Last().Name;
                            item.Imagem = ResolveUrl(Path.Combine(caminho, i));

                        }

                    }
                    //CASO O USUARIO PROCURE POR UM PRODUTO NÃO CADASTRADO NO SISTEMA, O MESMO RETORNA A MENSAGEM INFORMANDO
                    //A INEXISTENCIA DO PRODUTO.
                    if (lst.Count == 0)
                    {
                        divMsg.Visible = true;
                        divMsg.Attributes["class"] = "alert alert-dismissible alert-info";
                        msgPesquisa.Text = "<strong>Pesquisa Inválida</strong>. Nenhum produto encontrado com esse critério de pesquisa. Tente novamente com outro termo para busca...";
                    }
                    //CASO O PRODUTO EXISTA NO SISTEMA, A GRID VIEW É PREENCHIDA
                    else
                    {
                        grdItens.DataSource = lst;
                        grdItens.DataBind();
                    }
                }
            }
            else
            {

            }
        }

        protected void lbItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdItens.PageIndex = e.NewPageIndex;
            grdItens.DataBind();
        }
    }
}