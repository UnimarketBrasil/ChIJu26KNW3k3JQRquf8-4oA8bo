using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class ConfirmarCadastro : System.Web.UI.Page
    {
        //AO CARREGAR A TELA DE CONFIRMAÇÃO DE CADASTRO
        protected void Page_Load(object sender, EventArgs e)
        {
            //RECEBE O HASH ENVIADO POR PARAMETRO
            string hash = Request.QueryString["Hash"];

            //SE NÃO RECEBEU HASH OU SE USUÁRIO ESTÁ LOGADO, ENTÃO ENVIAR PARA TELA PRINCIPAL DO SISTEMA
            if (Session["sistema"] != null || hash == null)
                Response.Redirect("~/Views/Sistema.aspx");

            Usuario u = new Usuario();
            UsuarioRepositorio conf = new UsuarioRepositorio();

            u.HashConfirmacao = hash;
            //VERIFICAR SE EXISTE O HASH E SE USUÁRIO ESTÁ PEDENTE DE CONFIRMAÇÃO
            if (conf.ConfirmarCadastro(u))
            {
                Session["sistema"] = u;

                //GERAR LINK DE CONFIRMAÇÃO
                MailMessage message = null;
                IsEmail enviarConf = new IsEmail();
                StringBuilder strBody;


                //GERAR MENSAGEM PARA ENVIAR POR E-MAIL PARA O USUÁRIO
                strBody = new StringBuilder();
                strBody.AppendLine("cONFIRMAÇÃO DE CADASTRO");
                strBody.AppendLine("Id: " + u.Id);
                strBody.AppendLine("Nome: " + u.Nome + " " + u.Sobrenome);
                strBody.AppendLine("E-mail: " + u.Email);
                strBody.AppendLine("Dt. Cadastro: " + DateTime.Now);
                strBody.AppendLine("");
                strBody.AppendLine("Unimarket Brasil");

                //ENVIAR LINK PARA CONFIRMAÇÃO DE CADASTRO POR E-MAIL
                using (message = new MailMessage("unimarketbrasil@gmail.com", "unimarketbrasil@gmail.com")
                {

                    Subject = "Confirmação de Cadastro",
                    Body = strBody.ToString()

                })
                    enviarConf.Enviar(message);

                if (Session["carrinho"] != null)
                {
                    Response.Redirect("~/Views/SistemaCarrinho.aspx");
                }
                else
                {
                    if (u.Tipousuario.Id == 3)//Tipo de usuário vendedor
                    {
                        Response.Redirect("~/Views/Vendedor/VenderItem.aspx");
                    }
                    else if (u.Tipousuario.Id == 2)//Tipo de usuário comprador
                    {
                        Response.Redirect("~/Views/Sistema.aspx");
                    }
                    else if (u.Tipousuario.Id == 1)//Tipo de usuário administrador
                    {
                        Response.Redirect("~/Views/Administrador/AdminListar.aspx");
                    }
                }

            }
            else
            {
                Response.Redirect("~/Views/Sistema.aspx");
            }
        }
    }
}