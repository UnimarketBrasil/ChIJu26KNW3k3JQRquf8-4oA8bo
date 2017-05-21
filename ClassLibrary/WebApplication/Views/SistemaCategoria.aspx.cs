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
    public partial class SistemaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pesquisa = Request.QueryString["idCat"];
            Usuario u = null;
            Usuario uOff = null;

            if (Session["sistema"] != null)
            {
                u = (Usuario)Session["sistema"];
            }
            else if (Session["latlog"] == null & Session["sistema"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { chamaModal(); });", true);
                return;
            }

            ItemRepositorio itemPesquisa = new ItemRepositorio();
            int idCategoria=0;

            //CASO NÃO SEJA DIGITADO NADA NA PESQUISA, O SISTEMA APRESENTA A TELA DE ERRO
            if (!int.TryParse(pesquisa, out idCategoria))
            {
                divMsg.Visible = true;
                divMsg.Attributes["class"] = "alert alert-dismissible alert-info";
                msgPesquisa.Text = "<strong>Ops!!</strong>. Não encontramos essa categoria em nossa base de dados... O que você fez?";
                return;
            }
            //CASO SEJA DIGITADO ALGO NA PESQUISA, O SISTEMA RETORNA O RESULTADO DA MESMA
            else
            {

                List<Item> lst = null;
                if (Session["sistema"] != null)
                {
                    lst = itemPesquisa.MecanismoDeBuscaCategoria(idCategoria, u);
                }
                else
                {
                    uOff = (Usuario)Session["latlog"];
                    lst = itemPesquisa.MecanismoDeBuscaCategoria(idCategoria, uOff);
                }

                foreach (var item in lst)
                {
                    string caminho = string.Format("~/Imagens/{0}/{1}/", item.Vendedor.Id, item.Id);

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
                    msgPesquisa.Text = "<strong></strong>Nenhum produto encontrado nessa categoria...";
                }
                //CASO O PRODUTO EXISTA NO SISTEMA, A GRID VIEW É PREENCHIDA
                else
                {
                    grdItens.DataSource = lst;
                    grdItens.DataBind();
                }
            }
        }

        protected void grdItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdItens.PageIndex = e.NewPageIndex;
            grdItens.DataBind();
        }
    }
}