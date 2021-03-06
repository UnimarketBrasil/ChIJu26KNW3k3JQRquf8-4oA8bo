﻿using ClassLibrary;
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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divMsg.Visible = false;
            //Recebe o conteudo da barra de pesquisa por parametro
            string pesquisa = Request.QueryString["buscar"];
            Usuario u = null;
            Usuario uOff = null;

            if (Session["sistema"] != null)
            {
                u = (Usuario)Session["sistema"];
            }
            else if (Session["latlog"] == null & Session["sistema"] ==null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { chamaModal(); });", true);
                return;
            }


            ItemRepositorio itemPesquisa = new ItemRepositorio();

            //CASO O CAMPO PESQUISAR ESTIVER VAZIO, APARECERÁ UM MENSAGEM INFORMANDO QUE NÃO ENCOMTRAMOS NENHUM ITEM.
            if (String.IsNullOrWhiteSpace(pesquisa) == true)
            {
                divMsg.Visible = true;
                divMsg.Attributes["class"] = "alert alert-dismissible alert-info";
                msgPesquisa.Text = "Não encontramos nenhum item com o nome pesquisado.";
            }
            //CASO SEJA DIGITADO ALGO NA PESQUISA, O SISTEMA RETORNA O RESULTADO DA MESMA
            else
            {
                List<Item> lst=null;
                if (Session["sistema"] != null)
                {
                    lst = itemPesquisa.MecanismoDeBusca(pesquisa, u);
                }else
                {
                    uOff = (Usuario)Session["latlog"];
                    lst = itemPesquisa.MecanismoDeBusca(pesquisa, uOff);
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
                //CASO O USUARIO PROCURE POR UM ITEM NÃO CADASTRADO NO SISTEMA, O MESMO RETORNA A MENSAGEM INFORMANDO
                //A INEXISTENCIA DO ITEM.
                if (lst.Count == 0)
                {
                    divMsg.Visible = true;
                    divMsg.Attributes["class"] = "alert alert-dismissible alert-info";
                    msgPesquisa.Text = "Não encontramos nenhum item com o nome pesquisado.";
                }
                //CASO O PRODUTO EXISTA NO SISTEMA, A GRID VIEW É PREENCHIDA
                else
                {
                    grdItens.DataSource = lst;
                    grdItens.DataBind();
                }
            }
        }

        protected void lbItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdItens.PageIndex = e.NewPageIndex;
            grdItens.DataBind();
        }
    }
}