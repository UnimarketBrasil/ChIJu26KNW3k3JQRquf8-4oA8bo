﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace WebApplication
{
    public partial class SistemaCadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dvSegundaEtapa.Visible = false;
                dvPessoaJuridica.Visible = false;
                dvMsg.Visible = false;
                lbEndereco.Visible = false;
            }
        }

        protected void btValidar_Click(object sender, EventArgs e)
        {
            dvSegundaEtapa.Visible = true;
            dvPrimeiraEtapa.Visible = false;
            txtEmailEtapa2.Text = txtEmailEtapa1.Text;
        }

        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Usuario u = new Usuario();
                GeoCodificacao g = new GeoCodificacao();

                u = g.ObterCoordenadas(u, txtEndereco.Text, txtNumero.Text);

                Session["latlog"] = u;

                ArrayList sEndereco = new ArrayList();
                sEndereco = g.ObterEndereco(u);
                lbEndereco.Visible = true;
                lbEndereco.Text = sEndereco[1].ToString();
            }
            catch
            {
                dvMsg.Visible = true;
                dvEnderecoCompleto.Visible = false;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Desculpe, não localizamos o seu endereço. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=4' target='_blank'></a>";
            }
        }

        protected void btCadastrar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            if (dpTipoPessoa.SelectedValue == "2")//PESSOA JURÍDICA
            {
                IsCpfCnpj cnpj = new IsCpfCnpj();
                txtCnpj.Text = txtCnpj.Text.Replace(">", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");
                if (cnpj.validarCpfCnpj(txtCnpj.Text))
                {
                    u.CpfCnpj = txtCnpj.Text;
                }
                else
                {
                    txtCnpj.Text = null;
                    txtCnpj.BorderColor = System.Drawing.Color.Red;
                }
                u.Nome = txtRazaoSocial.Text;
                u.Nascimento = DateTime.Today;//Falta arrumar a data de nascimento.
            }
            else if (dpTipoPessoa.SelectedValue == "1")//PESSOA FÍSICA
            {
                IsCpfCnpj cpf = new IsCpfCnpj();
                txtCpf.Text = txtCpf.Text.Replace(">", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("/", "");
                if (cpf.validarCpfCnpj(txtCpf.Text))
                {
                    u.CpfCnpj = txtCpf.Text;
                }
                else
                {
                    txtCpf.Text = "";
                    txtCpf.BorderColor = System.Drawing.Color.Red;
                    
                }
                u.Nome = txtNome.Text;
                u.Sobrenome = txtSobrenome.Text;
                u.Nascimento = Convert.ToDateTime(txtDtNasc.Text);
                u.Genero = int.Parse(dpGenero.SelectedValue);
            }
            u.Email = txtEmailEtapa2.Text;
            u.Telefone = txtTel.Text;

            /*
                ->Tem que receber senha criptografia do usuário (criptografia temporária...). 
            */

            Criptografia criptografia = new Criptografia();
            u.Senha = criptografia.CriptografarSenha(txtSenha.Text);

            if (rdComprar.Checked == true)
            {
                u.Tipousuario = new TipoUsuario(int.Parse(rdComprar.Value));
                u.AreaAtuacao = 0.1;//É necessário verificar porque não está aceitando null
            }
            else if (rdVender.Checked == true)
            {
                u.Tipousuario = new TipoUsuario(int.Parse(rdVender.Value));
                u.AreaAtuacao = Convert.ToDouble(dpArea.SelectedValue);
            }
            Usuario uEndereco = (Usuario)Session["latlog"];

            u.Latitude = uEndereco.Latitude;
            u.Longitude = uEndereco.Longitude;
            u.Complemento = txtComplemento.Text;

            UsuarioRepositorio cadastrar = new UsuarioRepositorio();

            SqlDataReader Dr = cadastrar.ValidarEmailCpfCnpj(u);

            if (!Dr.HasRows)
            {
                if (cadastrar.CadastrarUsuario(u))
                {
                    //Response.Redirect(Request.RawUrl);
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                    lbMsg.Text = "Cadastro realizado com sucesso!";

                }
                else
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "Não foi possível atender sua solucitação, tente novamente mais tarde.";
                }
            }
            else if (Dr.HasRows)
            {
                Dr.Read();
                string existe = Convert.ToString(Dr["Existe"]);
                if (existe.Equals("Email_CpfCnpj"))
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                    lbMsg.Text = "E-mail e CNPJ/CPJ já estão cadastrado no sistema.<a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=5' target='_blank'></a>";
                }
                else if (existe.Equals("Email"))
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                    lbMsg.Text = "O E-mail "+u.Email.ToString()+" já está cadastrado no sistema.<a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=6' target='_blank'></a>";
                }
                else if (existe.Equals("CpfCnpj"))
                {
                    if (existe.Length == 11)
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                        lbMsg.Text = "O CPF: "+u.CpfCnpj.ToString()+ ", já cadastrado. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=7' target='_blank'></a>";
                    }
                    else if (existe.Length == 14)
                    {
                        dvMsg.Visible = true;
                        dvMsg.Attributes["class"] = "alert alert-info alert-dismissible";
                        lbMsg.Text = "O CNPJ: "+u.CpfCnpj+", já cadastrado. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=8' target='_blank'></a>";
                    }
                }
            }
        }

        protected void dpTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpTipoPessoa.SelectedValue == "1")//Significa que é pessoa fisica
            {
                dvPessoaJuridica.Visible = false;
                dvPessoaFisica.Visible = true;
            }
            else if (dpTipoPessoa.SelectedValue == "2")
            {//Significa que é pessoa jurídica
                dvPessoaFisica.Visible = false;
                dvPessoaJuridica.Visible = true;
            }
            else
            {

            }
        }
    }
}