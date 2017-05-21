using ClassLibrary;
using ClassLibrary.Repositorio;
using ClassUtilitario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SistemaAtualizarCadastro : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    this.Page.MasterPageFile = "~/Admin.Master";
                }
                else if (u.Tipousuario.Id == 2)
                {
                    this.Page.MasterPageFile = "~/Comprar.Master";
                }
                else if (u.Tipousuario.Id == 3)
                {
                    this.Page.MasterPageFile = "~/Vender.Master";
                }
                else
                {
                    Response.Redirect("~/Views/SistemaErro.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Views/SistemaLogin.aspx");
            }
        }
        //ESTE METODO CARREGA AS INFORMAÇOES DO USUARIO PARA ALTERAÇÃO
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario u = (Usuario)Session["sistema"];
                UsuarioRepositorio carregaUsuario = new UsuarioRepositorio();

                if (Session["sistema"] != null && u.CpfCnpj.Length == 11)
                {
                    dvMsg.Visible = false;
                    dvPessoaJuridica.Visible = false;

                    if (carregaUsuario.CarregarUsuario(u))
                    {
                        txtCpf.Text = FormatarCnpjCpf.FormatCPF(u.CpfCnpj);
                        txtNome.Text = u.Nome;
                        txtSobrenome.Text = u.Sobrenome;

                        txtEmail.Text = u.Email;
                        txtTel.Text = u.Telefone;
                        if (u.Tipousuario.Id == 2)
                        {
                            rdComprar.Checked = true;
                            lbComprar.Attributes.Add("class", "btn btn-primary active");
                            rdVender.Checked = false;
                        }
                        else if (u.Tipousuario.Id == 3)
                        {
                            rdVender.Checked = true;
                            lbVender.Attributes.Add("class", "btn btn-primary active");
                            rdComprar.Checked = false;
                        }

                        GeoCodificacao g = new GeoCodificacao();
                        lbEndereco.Text = g.ObterEndereco(u.Latitude, u.Longitude);
                        txtNumero.Text = u.Numero.ToString();
                        txtComplemento.Text = u.Complemento;
                        dpArea.SelectedValue = Convert.ToString(u.AreaAtuacao);

                        string caminho = string.Format("~/Imagens/{0}/Perfil/", u.Id);

                        if (Directory.Exists(Server.MapPath(caminho)))
                        {
                            var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                            var arquivos = diretorio.GetFiles();
                            string img = arquivos.Last().Name;
                            userImage.ImageUrl = ResolveUrl(Path.Combine(caminho, img));
                        }

                    }
                    else
                    {
                        Response.Redirect("~/Views/Logout.aspx");
                    }
                }
                else if (Session["sistema"] != null && u.CpfCnpj.Length == 14)
                {
                    dvMsg.Visible = false;
                    dvPessoaFisica.Visible = false;

                    if (carregaUsuario.CarregarUsuario(u))
                    {
                        txtCnpj.Text = FormatarCnpjCpf.FormatCNPJ(u.CpfCnpj);
                        txtRazaoSocial.Text = u.Nome;
                        txtEmail.Text = u.Email;
                        txtTel.Text = u.Telefone;
                        if (u.Tipousuario.Id == 2)
                        {
                            rdComprar.Checked = true;
                            lbComprar.Attributes.Add("class", "btn btn-primary active");
                            rdVender.Checked = false;
                        }
                        else if (u.Tipousuario.Id == 3)
                        {
                            rdVender.Checked = true;
                            lbVender.Attributes.Add("class", "btn btn-primary active");
                            rdComprar.Checked = false;
                        }

                        GeoCodificacao g = new GeoCodificacao();
                        lbEndereco.Text = g.ObterEndereco(u.Latitude, u.Longitude);
                        txtNumero.Text = u.Numero.ToString();
                        txtComplemento.Text = u.Complemento;
                        dpArea.SelectedValue = Convert.ToString(u.AreaAtuacao);

                        string caminho = string.Format("~/Imagens/{0}/Perfil/", u.Id);

                        if (Directory.Exists(Server.MapPath(caminho)))
                        {
                            var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                            var arquivos = diretorio.GetFiles();
                            string img = arquivos.Last().Name;
                            userImage.ImageUrl = ResolveUrl(Path.Combine(caminho, img));
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Logout.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Logout.aspx");
                }
            }
        }

        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Usuario u = new Usuario();
                GeoCodificacao g = new GeoCodificacao();

                u = g.ObterCoordenadas(u, txtEndereco.Text, txtNumero.Text);

                Session["latlog"] = u;

                //ArrayList sEndereco = new ArrayList();
                //sEndereco = g.ObterEndereco(u);
                //lbEndereco.Visible = true;
                //lbEndereco.Text = sEndereco[1].ToString();
            }
            catch
            {
                dvMsg.Visible = true;
                dvEnderecoCompleto.Visible = false;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Desculpe, não localizamos o seu endereço.";
            }
        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["sistema"];

            if (u.CpfCnpj.Length == 14)
            {
                u.Nome = txtRazaoSocial.Text;
                u.Email = txtEmail.Text;
                u.Telefone = txtTel.Text;
                if (rdComprar.Checked == true)
                {
                    u.Tipousuario = new TipoUsuario();
                    u.Tipousuario.Id = 2;
                }
                else if (rdVender.Checked == true)
                {
                    u.Tipousuario = new TipoUsuario();
                    u.Tipousuario.Id = 3;
                }
                try
                {
                    Usuario uEndereco = (Usuario)Session["latlog"];
                    u.Latitude = uEndereco.Latitude;
                    u.Longitude = uEndereco.Longitude;
                }
                catch
                {
                    Usuario uEndereco = (Usuario)Session["sistema"];
                    u.Latitude = uEndereco.Latitude;
                    u.Longitude = uEndereco.Longitude;
                }
                u.Complemento = txtComplemento.Text;

                UsuarioRepositorio atualizarCadastro = new UsuarioRepositorio();
                if (atualizarCadastro.AtualizarUsuario(u))
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                    lbMsg.Text = "Cadastro atualizado com sucesso!";
                }
                else
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "Não foi possível atender sua solicitação.";
                }

            }
            else if (u.CpfCnpj.Length == 11)
            {
                u.Nome = txtNome.Text;
                u.Sobrenome = txtSobrenome.Text;
                u.Email = txtEmail.Text;
                u.Telefone = txtTel.Text;
                if (rdComprar.Checked == true)
                {
                    u.Tipousuario = new TipoUsuario();
                    u.Tipousuario.Id = 2;
                }
                else if (rdVender.Checked == true)
                {
                    u.Tipousuario = new TipoUsuario();
                    u.Tipousuario.Id = 3;
                }
                try
                {
                    Usuario uEndereco = (Usuario)Session["latlog"];
                    u.Latitude = uEndereco.Latitude;
                    u.Longitude = uEndereco.Longitude;
                }
                catch
                {
                    Usuario uEndereco = (Usuario)Session["sistema"];
                    u.Latitude = uEndereco.Latitude;
                    u.Longitude = uEndereco.Longitude;
                }
                u.Complemento = txtComplemento.Text;
                u.AreaAtuacao = Convert.ToDouble(dpArea.SelectedValue);

                UsuarioRepositorio atulizarCadastro = new UsuarioRepositorio();
                if (atulizarCadastro.AtualizarUsuario(u))
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-success alert-dismissible";
                    lbMsg.Text = "Cadastro realizado com sucesso!";
                }
                else
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "Não foi possível atender sua solicitação.";
                }
            }

        }
    }
}