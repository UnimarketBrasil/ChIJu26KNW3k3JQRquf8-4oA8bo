﻿using System;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;
using System.Data;

namespace WebApplication
{
    public partial class SistemaNovoItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void bt_CadastrarItem(object sender, EventArgs e)
        {
            Item item = new Item();

            txtCod.Text = txtCod.Text.Replace(">", "");
            item.Codigo = txtCod.Text;
            txtNome.Text = txtNome.Text.Replace(">", "");
            item.Nome = txtNome.Text;
            item.Descricao = txtDescricao.InnerText;
            item.ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
            item.Quantidade = Convert.ToInt64(txtQuantidade.Text);

            item.Categoria = new Categoria(Convert.ToInt32(dpCategoria.SelectedValue));

            Usuario u = (Usuario)Session["sistema"];

            item.Usuario = new Usuario(u.Id);

            ItemRepositorio cadastrarItem = new ItemRepositorio();

            if (cadastrarItem.CadastrarItem(item))
            {
                txtCod.Text = "Sucesso";
            }
            else
            {
                txtCod.Text = "Erro";
            }



  
            



            /* if (dpCategoria.SelectedValue == "1")
              {

                  // Alimentos/Bebidas

                  Categoria c = new Categoria();
                  c.Nome = dpCategoria.Text;

              }

              else if (dpCategoria.SelectedValue == "2")
              {

                  // Eletronicos

                  Categoria c = new Categoria();
                  c.Nome = dpCategoria.Text;
             } */
        }
    }
}