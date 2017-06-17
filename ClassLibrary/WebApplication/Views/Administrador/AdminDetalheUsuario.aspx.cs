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
    public partial class AdminDetalheUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RECEBE ID DO ITEM POR PARAMETRO E CARREGA NA TELA DADOS DO USUÁRIO
            Usuario user = null;
            UsuarioRepositorio carregaUsuario = new UsuarioRepositorio();
            int idUsuario = 0;

            if (int.TryParse(Request.QueryString["idUsuario"], out idUsuario))
            {
                user = carregaUsuario.DetalheUsuario(idUsuario);
                if (user != null)
                {
                    if (user.CpfCnpj.Length == 11)
                    {
                        //USUÁRIO PESSOA FISICA
                        lbNome.Text = user.Nome + ", " + user.Sobrenome;
                        lbCpf.Text = FormatarCnpjCpf.FormatCPF(user.CpfCnpj);
                        if (user.Genero == 1)
                        {
                            lbGenero.Text = "Masculino";
                        }
                        else if (user.Genero == 2)
                        {
                            lbGenero.Text = "Feminino";
                        }
                        else if (user.Genero == 3)
                        {
                            lbGenero.Text = "Outro";
                        }
                        dvPessoaJuridica.Visible = false;
                    }
                    else if (user.CpfCnpj.Length == 14)
                    {
                        //USUARIO PESSOA JURIDICA
                        lbRazao.Text = user.Nome;
                        lbCnpj.Text = FormatarCnpjCpf.FormatCNPJ(user.CpfCnpj);
                        dvPessoaFisica.Visible = false;

                    }
                    lbEmail.Text = user.Email;
                    lbTelefone.Text = user.Telefone;
                    lbTipoUsuario.Text = user.Tipousuario.Nome;
                    if (user.Tipousuario.Nome == "Vendedor")
                    {
                        lbAreaAtuacao.Text = user.AreaAtuacao.ToString();
                        lbItensCadastrados.Text = user.QtdadeItens.ToString();
                        lbPedidosPendentes.Text = user.QtdPedidosPendente.ToString();
                        lbPedidosFinalizados.Text = user.QtdPedidosFinanlizado.ToString();
                        lbPedidosCancelados.Text = user.QtdPedidosCancelado.ToString();
                    }
                    else
                    {
                        dvVendedor.Visible = false;
                    }
                    lbStatusUsuario.Text = user.StatusUsuario.Nome;
                    lbDataCadastro.Text = user.DataCadastro.ToString();
                    //CARREGAR ENDEREÇO
                    GeoCodificacao g = new GeoCodificacao();
                    lbEndereco.Text = g.ObterEndereco(user);
                    lbComplemento.Text = user.Complemento;
                    lbAreaAtuacao.Text = user.AreaAtuacao.ToString();
                }
            }
        }
    }
}