using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SistemaRecuperarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dvMsg.Visible = false;

            Usuario u = new Usuario();
            UsuarioRepositorio rUser = new UsuarioRepositorio();


            string hash = Request.QueryString["Hash"];

            if (hash != null && Session["sistema"] == null)
            {
                if (!rUser.ValidarHashNovaSenha(hash))
                {
                    Response.Redirect("~/Views/Sistema.aspx");
                }
                dvAlterarSenhaAntiga.Visible = false;
            }
            else if (hash == null & Session["sistema"] != null)
            {
                dvAlterarSenhaAntiga.Visible = true;
            }
            else
            {
                Response.Redirect("~/Views/Sistema.aspx");
            }


        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            string hash, nSenha;
            hash = Request.QueryString["Hash"];

            Usuario u = new Usuario();
            UsuarioRepositorio rUser = new UsuarioRepositorio();

            Criptografia criptografia = new Criptografia();
            u.Senha = criptografia.CriptografarSenha(txtSenhaAntiga.Text);
            nSenha = criptografia.CriptografarSenha(txtSenha.Text);

            if (txtConfSenha.Text.Equals(txtSenha.Text))
            {
                if (String.IsNullOrEmpty(hash) && Session["sistema"] != null)
                {
                    //SE NÃO FOI RECEBIDO O HASH ENTÃO O USUARIO PRECISA INFORMAR A SENHA ATUAL
                    u = (Usuario)Session["sistema"];
                    u.Senha = criptografia.CriptografarSenha(txtSenhaAntiga.Text);

                    if (rUser.AtualizarSenha(u, nSenha))
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                        lbMsg.Text = "Senha alterada com sucesso!";
                    }
                    else
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                        lbMsg.Text = "Senha inválida!<a onclick='ajudaModal.show('ATIVIDADE PRINCIPAL', 1);' class='glyphicon glyphicon-question-sign'></a>";
                        txtSenhaAntiga.BorderColor = System.Drawing.Color.Red;
                    }
                }
                else if (!String.IsNullOrEmpty(hash))
                {
                    //SE FOI RECEBIDO O HASH ENTÃO SERÁ VALIDADO O HASH E TAMBÉM A ALTERÃO DA SENHA
                    //NÃO SENDO NECESSÁRIO INFORMAR A SENHA ATUAL
                    if (rUser.NovaSenha(hash, nSenha))
                    {

                        if (rUser.NovaSenha(hash, criptografia.CriptografarSenha(txtSenha.Text).ToString()))
                        {
                            dvMsg.Visible = true;
                            dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                            lbMsg.Text = "Senha alterada com sucesso! Para realizar login <a href='SistemaLogin.aspx'>clique aqui</a>";
                        }
                    }
                    else
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                        lbMsg.Text = "Erro!<a onclick='ajudaModal.show('ATIVIDADE PRINCIPAL', 1);' class='glyphicon glyphicon-question-sign'></a>";
                        txtSenha.BorderColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Senhas não coincidem!<a onclick='ajudaModal.show('ATIVIDADE PRINCIPAL', 1);' class='glyphicon glyphicon-question-sign'></a>";
                txtSenha.BorderColor = System.Drawing.Color.Red;
                txtConfSenha.BorderColor = System.Drawing.Color.Red;
            }

        }
    }
}