using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassUtilitario;
using ClassLibrary.Repositorio;

namespace WebApplication
{
    public partial class SistemaLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dvMsg.Visible = false;
            if (!IsPostBack)
            {
                //Recupera o ID do usuario gravado no cookie
                if (Request.Cookies["idUsuario"] != null)
                {
                    //Joga o valor do cookie na variavel
                    int valorCookie = int.Parse(Request.Cookies["idUsuario"].Value);

                    //Cria um novo usuario
                    Usuario usuario = new Usuario();
                    UsuarioRepositorio usuarioRepos = new UsuarioRepositorio();

                    //Atribui o valor do cookie a variavel usuario 
                    usuario.Id = valorCookie;

                    //Carrega o usuario através do metodo CarregarUsuario
                    if (usuarioRepos.CarregarUsuario(usuario))
                    {
                        //Verifica se a variavel é diferente de nulo
                        if (usuario != null)
                        {
                            //Caso o usuario ainda não tenha confirmado seu cadastro via e-mail
                            if (usuario.StatusUsuario.Id == 2)
                            {
                                dvMsg.Visible = true;
                                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                                lbMsg.Text = "<strong>Confirme seu cadastro</strong>, enviamos um link de confirmação para <a href='/Views/SistemaAjuda.aspx?help=1' target='_blank'><u>" + usuario.Email.ToString() + "</u></a>!";
                                HttpContext.Current.Response.Cookies["idUsuario"].Expires = DateTime.Now.AddDays(-1);
                                txtEmail.Text = usuario.Email;
                                manterLogado.Checked = true;                              
                            }
                            //Caso sua conta esteja bloqueada
                            else if (usuario.StatusUsuario.Id == 3)
                            {
                                dvMsg.Visible = true;
                                dvMsg.Attributes["class"] = "alert alert-danger alert-dismissible";
                                lbMsg.Text = "<strong>Conta bloqueada</strong>, entre em contato com o administrador do sistema. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=2' target='_blank'></a>";
                                HttpContext.Current.Response.Cookies["idUsuario"].Expires = DateTime.Now.AddDays(-1);
                                txtEmail.Text = usuario.Email;
                                manterLogado.Checked = true;
                            }
                            //Após as validações, o usuario é redirecionado para sua tela
                            else if (usuario.StatusUsuario.Id == 1 | usuario.StatusUsuario.Id == 5 | usuario.StatusUsuario.Id == 6)
                            {
                                //A tela inicial depende do tipo do usuario que estiver fazendo login
                                Session["sistema"] = usuario;

                                if (usuario.Tipousuario.Id == 3)//Tipo de usuário vendedor
                                {
                                    Response.Redirect("~/Views/Vendedor/VenderItem.aspx");
                                }
                                else if (usuario.Tipousuario.Id == 2)//Tipo de usuário comprador
                                {
                                    Response.Redirect("~/Views/Sistema.aspx");
                                }
                                else if (usuario.Tipousuario.Id == 1)//Tipo de usuário administrador
                                {
                                    Response.Redirect("~/Views/Administrador/AdminListar.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/Views/SistemaErro.aspx");
                                }
                            }
                        }
                        else
                        {
                            //Caso o usuario seja nulo, ele destroí o Cookie.
                            HttpContext.Current.Response.Cookies["idUsuario"].Expires = DateTime.Now.AddDays(-1);
                        }
                    }
                }
            }

            if (Session["sistema"] != null)
            {
                Usuario u = (Usuario)Session["sistema"];
                if (u.Tipousuario.Id == 1)
                {
                    Response.Redirect("~/Views/Administrador/AdminListar.aspx");
                }
                else if (u.Tipousuario.Id == 3)
                {
                    Response.Redirect("~/Views/Vendedor/VenderItem.aspx");
                }
                else
                {
                    Response.Redirect("~/Views/Sistema.aspx");
                }
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            //Este metodo valida o login do usuario no sistema
            Usuario usuario = new Usuario();
            Criptografia criptografia = new Criptografia();

            usuario.Email = txtEmail.Text;
            //Comparados os hashs da criptografia
            usuario.Senha = criptografia.CriptografarSenha(txtSenha.Text);

         
            UsuarioRepositorio login = new UsuarioRepositorio();
            if (login.LoginUsuario(usuario))
            {
                if (manterLogado.Checked)
                {
                    //É criado um cookie com validade de 30 dias
                    HttpContext.Current.Response.Cookies["idUsuario"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    //Caso não seja necessario, é atribuido uma data de validade negativa fazendo o cookie ser destruido
                    HttpContext.Current.Response.Cookies["idUsuario"].Expires = DateTime.Now.AddDays(-1);
                }

                //O ID do usuario carregado é adicionado ao Cookie caso tenha marcado o checked
                HttpContext.Current.Response.Cookies["idUsuario"].Value = Convert.ToString(usuario.Id);

                //Caso o usuario ainda não tenha confirmado seu cadastro via e-mail
                if (usuario.StatusUsuario.Id == 2)
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                    lbMsg.Text = "<strong>Confirme seu cadastro</strong>, enviamos um link de confirmação para <a href='/Views/SistemaAjuda.aspx?help=1' target='_blank'><u>" + usuario.Email.ToString() + "</u></a>!";
                }
                //Caso sua conta esteja bloqueada
                else if (usuario.StatusUsuario.Id == 3)
                {
                    dvMsg.Visible = true;
                    dvMsg.Attributes["class"] = "alert alert-danger alert-dismissible";
                    lbMsg.Text = "<strong>Conta bloqueada</strong>, entre em contato com o administrador do sistema. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=2' target='_blank'></a>";                   
                }
                else if (usuario.StatusUsuario.Id == 1 | usuario.StatusUsuario.Id == 5 | usuario.StatusUsuario.Id == 6)
                {
                    //A tela inicial depende do tipo do usuario que estiver fazendo login
                    Session["sistema"] = usuario;

                    if (usuario.Tipousuario.Id == 3)//Tipo de usuário vendedor
                    {
                        Response.Redirect("~/Views/Vendedor/VenderItem.aspx");
                    }
                    else if (usuario.Tipousuario.Id == 2)//Tipo de usuário comprador
                    {
                        Response.Redirect("~/Views/Sistema.aspx");
                    }
                    else if (usuario.Tipousuario.Id == 1)//Tipo de usuário administrador
                    {
                        Response.Redirect("~/Views/Administrador/AdminListar.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Views/SistemaErro.aspx");
                    }
                }

            }
            else
            {
                //Caso o e-mail e a senha estiverem errados, o sistema informa através da mensagem
                dvMsg.Visible = true;
                dvMsg.Attributes["class"] = "alert alert-warning alert-dismissible";
                lbMsg.Text = "Email ou senha inválidos. <a class='glyphicon glyphicon-question-sign' href='/Views/SistemaAjuda.aspx?help=3' target='_blank'></a>";
            }
        }
    }
}