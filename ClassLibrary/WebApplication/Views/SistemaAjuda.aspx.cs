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
                lbAjudaCorpo.Text = "Email ou senha inválidos ou não estão cadastrados no sistema. Por favor, verifique e tente novamente. Lembrando que um endereço de email válido deve ter o formato de xxxxxx@dominio.com" +
                                    "e a senha deve possuir no minimo 8 caracteres.";
            }
            else if (pesquisa.Equals("4"))
            {
                lbAjudaCabecalho.Text = "NÃO LOCALIZAMOS SEU ENDEREÇO";
                lbAjudaCorpo.Text = "Não conseguimos localizar seu endereço. Por favor, verifique o CEP digitado e tente novamente. Caso você não saiba seu CEP, acesse o site <a href='http://www.buscacep.correios.com.br/sistemas/buscacep/' target='_blank'>Correios - Busca CEP</a> e digite seu endereço para saber seu CEP";
            }
            else if (pesquisa.Equals("5"))
            {
                lbAjudaCabecalho.Text = "EMAIL INVÁLIDO";
                lbAjudaCorpo.Text = "O email digitado é inválido ou não está de acordo com os padrões de endereços de emails. Por favor, verifique o email digitado e tente novamente. Lembrando que um endereço de email válido deve ter o formato de xxxxxx@dominio.com";
            }
            else if (pesquisa.Equals("6"))
            {
                lbAjudaCabecalho.Text = "O EMAIL E O CPF/CNPJ JÁ ESTÃO CADASTRADOS NO SISTEMA";
                lbAjudaCorpo.Text = "O EMAIL e o CPF/CNPJ digitados já estão cadastrados no sistema. Caso você já tenha um cadastro e tenha esquecido seus dados de acessos, por favor acesse a pagina <a href='/Views/SistemaRecuperarSenha.aspx' target='_blank'> Recuperar Senha </a> e recupere seus dados digitando seu CPF/CNPJ";
            }
            else if (pesquisa.Equals("7"))
            {
                lbAjudaCabecalho.Text = "EMAIL JÁ CADASTRADO";
                lbAjudaCorpo.Text = "O EMAIL digitado já encontra-se cadastrado no sistema. Digite outro endereço de EMAIL para poder efetuar seu cadastro. Caso tenha esquecido seu endereço de EMAIL, acesse <a href='/Views/SistemaRecuperarSenha.aspx' target='_blank'> Recuperar Senha </a> e recupere seu email digitando seu CPF/CNPJ";
            }
            else if (pesquisa.Equals("8"))
            {
                lbAjudaCabecalho.Text = "CNPJ JÁ CADASTRADO";
                lbAjudaCorpo.Text = "CNPJ digitados já está cadastrado no sistema. Caso você já tenha um cadastro e tenha esquecido seus dados de acessos, por favor acesse a pagina <a href='/Views/SistemaRecuperarSenha.aspx' target='_blank'> Recuperar Senha </a> e recupere seus dados digitando seu CPF/CNPJ";
            }
            else if (pesquisa.Equals("9"))
            {
                lbAjudaCabecalho.Text = "CPF JÁ CADASTRADO";
                lbAjudaCorpo.Text = "O CPF digitado já encontra-se cadastrado no sistema. Verifique o CPF digitado e tente novamente. Caso você já tenha um cadastro e tenha esquecido seus dados de acessos, por favor acesse a pagina <a href='/Views/SistemaRecuperarSenha.aspx' target='_blank'> Recuperar Senha </a> e recupere seus dados digitando seu CPF/CNPJ";
            }
            else if (pesquisa.Equals("10"))
            {
                lbAjudaCabecalho.Text = "ATIVIDADE PRINCIPAL";
                lbAjudaCorpo.Text = "Define qual será sua atividade principal dentro do sistema Unimarket Brasil. Você poderá mais tarde mudar sua atividade principal de acordo com sua necessidade. Informamos que cada atividade possui opções esclusivas que só podem ser utilizadas de acordo com a atividade escolhida pelo usuario";
            }
            else if (pesquisa.Equals("11"))
            {
                lbAjudaCabecalho.Text = "ENDEREÇO PRINCIPAL";
                lbAjudaCorpo.Text = "Endereço principal cadastrado e visivel aos demais usuarios do sistema. Pode ser entendido como o endereço de origem de suas atividades, ou seja, o local onde você exerce suas compras ou vendas.";
            }
            else if (pesquisa.Equals("12"))
            {
                lbAjudaCabecalho.Text = "ÁREA DE ATUAÇÃO";
                lbAjudaCorpo.Text = "Define o tamanho da área em que o usuario irá atuar com suas atividades de compras, vendas e entregas. ";
            }
        }
    }
}