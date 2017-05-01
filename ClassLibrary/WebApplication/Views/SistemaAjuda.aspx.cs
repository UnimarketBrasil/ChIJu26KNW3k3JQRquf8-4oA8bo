using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Views
{
    public partial class SistemaAjuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pesquisa = Request.QueryString["help"];

            if (pesquisa.Equals("1"))
            {
                lbAjudaCabecalho.Text = "CONFIRMAÇÃO DE CADASTRO";
                lbAjudaCorpo.Text = "Falta pouco! Confirme seu cadastro para começar a usar o UNIMARKET.";
            }
            else if (pesquisa.Equals("2"))
            {
                lbAjudaCabecalho.Text = "CONTA BLOQUEADA";
                lbAjudaCorpo.Text = "O administrador do sistema bloqueou sua conta devido o mau uso do sistema. Entre em contato através do EMAIL: unimarketbrasil@gmail.com relatando seu problema.";
            }
            else if (pesquisa.Equals("3"))
            {
                lbAjudaCabecalho.Text = "EMAIL e/ou SENHA INVÁLIDOS";
                lbAjudaCorpo.Text = "O email ou senha são inválidos ou não estão cadastrados no sistema. ";
            }
            else if (pesquisa.Equals("4"))
            {
                lbAjudaCabecalho.Text = "NÃO LOCALIZAMOS SEU ENDEREÇO";
                lbAjudaCorpo.Text = "Não conseguimos localizar seu endereço. Por favor, verifique o endereço digitado e tente novamente.";
            }
            else if (pesquisa.Equals("5"))
            {
                lbAjudaCabecalho.Text = "EMAIL INVÁLIDO";
                lbAjudaCorpo.Text = "O email digitado é inválido ou não está de acordo com os padrões de endereços de emails.";
            }
            else if (pesquisa.Equals("6"))
            {
                lbAjudaCabecalho.Text = "O EMAIL E O CPF/CNPJ JÁ ESTÃO CADASTRADOS NO SISTEMA";
                lbAjudaCorpo.Text = "O EMAIL e o CPF/CNPJ digitados já estão cadastrados no sistema.";
            }
            else if (pesquisa.Equals("7"))
            {
                lbAjudaCabecalho.Text = "EMAIL JÁ CADASTRADO";
                lbAjudaCorpo.Text = "O EMAIL digitado já encontra-se cadastrado no sistema. Digite outro endereço de EMAIL para poder efetuar seu cadastro";
            }
            else if (pesquisa.Equals("8"))
            {
                lbAjudaCabecalho.Text = "CNPJ JÁ CADASTRADO";
                lbAjudaCorpo.Text = "O CNPJ digitado já encontra-se cadastrado no sistema. Verifique o CNPJ digitado e tente novamente";
            }
            else if (pesquisa.Equals("9"))
            {
                lbAjudaCabecalho.Text = "CPF JÁ CADASTRADO";
                lbAjudaCorpo.Text = "O CPF digitado já encontra-se cadastrado no sistema. Verifique o CPF digitado e tente novamente";
            }
            else if (pesquisa.Equals("10"))
            {
                lbAjudaCabecalho.Text = "ATIVIDADE PRINCIPAL";
                lbAjudaCorpo.Text = "Define qual será sua atividade principal dentro do sistema Unimarket Brasil.";
            }
            else if (pesquisa.Equals("11"))
            {
                lbAjudaCabecalho.Text = "ENDEREÇO PRINCIPAL";
                lbAjudaCorpo.Text = "Endereço principal cadastrado e visivel aos demais usuarios do sistema.";
            }
            else if (pesquisa.Equals("11"))
            {
                lbAjudaCabecalho.Text = "ÁREA DE ATUAÇÃO";
                lbAjudaCorpo.Text = "Define o tamanho da área em que o usuario irá atuar com suas atividades.";
            }
            else if (pesquisa.Equals("12"))
            {
                lbAjudaCabecalho.Text = "ÁREA DE ATUAÇÃO";
                lbAjudaCorpo.Text = "Define o tamanho da área em que o usuario irá atuar com suas atividades.";
            }
        }
    }
}