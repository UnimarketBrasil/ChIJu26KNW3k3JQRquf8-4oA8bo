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
            int idtpousuario;

            int.TryParse(Request.QueryString["TipoUsuario"], out idtpousuario);

            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    this.Page.MasterPageFile = "~/Admin.Master";
                }
                else if (u.Tipousuario.Id == 2 && !idtpousuario.Equals(2))
                {
                    this.Page.MasterPageFile = "~/Comprar.Master";
                }
                else if (u.Tipousuario.Id == 3 || idtpousuario.Equals(2))
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
            int idtpousuario;

            int.TryParse(Request.QueryString["TipoUsuario"], out idtpousuario);

            if (idtpousuario.Equals(2))
            {
                dvMetodo.Visible = true;
            }

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

                        string caminho = string.Format("~/Imagens/{0}/Perfil/", u.Id);

                        if (Directory.Exists(Server.MapPath(caminho)))
                        {
                            var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                            var arquivos = diretorio.GetFiles();
                            string img = arquivos.Last().Name;
                            userImage.ImageUrl = ResolveUrl(Path.Combine(caminho, img));
                        }

                        GeoCodificacao g = new GeoCodificacao();
                        lbEndereco.Text = g.ObterEndereco(u.Latitude, u.Longitude);
                        txtEndereco.Text = u.CEP;
                        txtNumero.Text = u.Numero.ToString();
                        txtComplemento.Text = u.Complemento;
                        dpArea.SelectedValue = Convert.ToString(u.AreaAtuacao);

                        for (int i = 0; i < u.MetodoPagamento.Count; i++)
                        {
                            cbMetodosPagamento.Items.Add(new ListItem(u.MetodoPagamento[i].Nome, u.MetodoPagamento[i].Id.ToString()));
                            cbMetodosPagamento.Items[i].Selected = u.MetodoPagamento[i].Desabilitado;
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

                        string caminho = string.Format("~/Imagens/{0}/Perfil/", u.Id);

                        if (Directory.Exists(Server.MapPath(caminho)))
                        {
                            var diretorio = new DirectoryInfo(Server.MapPath(caminho));
                            var arquivos = diretorio.GetFiles();
                            string img = arquivos.Last().Name;
                            userImage.ImageUrl = ResolveUrl(Path.Combine(caminho, img));
                        }

                        GeoCodificacao g = new GeoCodificacao();
                        lbEndereco.Text = g.ObterEndereco(u.Latitude, u.Longitude);
                        txtEndereco.Text = u.CEP;
                        txtNumero.Text = u.Numero.ToString();
                        txtComplemento.Text = u.Complemento;
                        dpArea.SelectedValue = Convert.ToString(u.AreaAtuacao);

                        for (int i = 0; i < u.MetodoPagamento.Count; i++)
                        {
                            cbMetodosPagamento.Items.Add(new ListItem(u.MetodoPagamento[i].Nome, u.MetodoPagamento[i].Id.ToString()));
                            cbMetodosPagamento.Items[i].Selected = u.MetodoPagamento[i].Desabilitado;
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

        protected void btSalvar_Click(object sender, EventArgs e)
        {
            Usuario u = (Usuario)Session["sistema"];

            if (u.CpfCnpj.Length == 14)
            {
                u.Nome = txtRazaoSocial.Text;
                u.Email = txtEmail.Text;
                u.Telefone = txtTel.Text;

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
                u.Numero = Convert.ToInt32(txtNumero.Text);
                u.AreaAtuacao = Convert.ToDouble(dpArea.SelectedValue);

                u.MetodoPagamento = new List<MetodoPagamento>();
                MetodoPagamento m = null;

                foreach (var i in cbMetodosPagamento.Items.Cast<ListItem>())
                {
                    m = new MetodoPagamento();
                    m.Id = Convert.ToInt32(i.Value);
                    m.Desabilitado = i.Selected;
                    u.MetodoPagamento.Add(m);
                }

                if (InputFoto.HasFile)
                {
                    string formato = System.IO.Path.GetExtension(InputFoto.FileName);
                    if (formato == ".png" || formato == ".jpg" || formato == ".gif" || formato == ".jpeg")
                    {
                        var caminho = Server.MapPath(string.Format(@"~/Imagens/{0}/Perfil/", u.Id));

                        Directory.CreateDirectory(caminho);

                        DirectoryInfo dir = new DirectoryInfo((caminho));
                        dir.GetFiles("*", SearchOption.AllDirectories).ToList().ForEach(file => file.Delete());

                        InputFoto.PostedFile.SaveAs(Path.Combine(caminho, InputFoto.FileName));
                    }
                }

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
                u.Numero = Convert.ToInt32(txtNumero.Text);
                u.AreaAtuacao = Convert.ToDouble(dpArea.SelectedValue);

                u.MetodoPagamento = new List<MetodoPagamento>();
                MetodoPagamento m = null;

                foreach (var i in cbMetodosPagamento.Items.Cast<ListItem>())
                {
                    m = new MetodoPagamento();
                    m.Id = Convert.ToInt32(i.Value);
                    m.Desabilitado = i.Selected;
                    u.MetodoPagamento.Add(m);
                }

                if (InputFoto.HasFile)
                {
                    string formato = System.IO.Path.GetExtension(InputFoto.FileName);
                    if (formato == ".png" || formato == ".jpg" || formato == ".gif" || formato == ".jpeg")
                    {
                        var caminho = Server.MapPath(string.Format(@"~/Imagens/{0}/Perfil/", u.Id));

                        Directory.CreateDirectory(caminho);

                        DirectoryInfo dir = new DirectoryInfo((caminho));
                        dir.GetFiles("*", SearchOption.AllDirectories).ToList().ForEach(file => file.Delete());

                        InputFoto.PostedFile.SaveAs(Path.Combine(caminho, InputFoto.FileName));
                    }
                }

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
            Response.Redirect(Request.RawUrl);
        }
    }
}