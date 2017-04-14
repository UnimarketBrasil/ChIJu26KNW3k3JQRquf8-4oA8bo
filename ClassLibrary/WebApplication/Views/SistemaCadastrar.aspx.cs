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
    public partial class SistemaCadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dvSegundaEtapa.Visible = false;
            }
        }

        protected void Validar_Click(object sender, EventArgs e)
        {
            IsEmail u = new IsEmail();
            if (u.ValidarEmail(txtEmailEtapa1.Text))
            {
                dvSegundaEtapa.Visible = true;
                dvPrimeiraEtapa.Visible = false;
                txtEmailEtapa2.Text = txtEmailEtapa1.Text;
                //dvPessoaJuridica.Visible = false;
            }
        }


        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                //Procurar endereço pelo CEP
                if (Convert.ToString(txtEndereco.Text).Where(c => char.IsNumber(c)).Count() > 0 && Convert.ToString(txtEndereco.Text).Length == 8)
                {
                    //Procurar endereço pelo WS VIACEP
                    ds.ReadXml("https://viacep.com.br/ws/" + txtEndereco.Text + "/xml/");

                    string enderecoViaCep = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                    string addressGoogle = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDPNFOUPna4dnTRtQ806ST8G9Vj6WEK32Y&new_forward_geocoder=true&address=" + enderecoViaCep + ", " + txtNumero.Text + "";

                    ds = new DataSet();
                    ds.ReadXml(addressGoogle);

                    if (ds != null && ds.Tables["address_component"].Rows.Count >= 7)
                    {
                        string endereco = ds.Tables["result"].Rows[0]["formatted_address"].ToString();
                        string lat = ds.Tables["location"].Rows[0]["lat"].ToString();
                        string log = ds.Tables["location"].Rows[0]["lng"].ToString();

                        Usuario u = new Usuario();
                        u.Latitude = lat;
                        u.Longitude = log;

                        Session["latLog"] = u;
                        Session["address"] = endereco;

                    }
                }
                else
                {
                    string address = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDPNFOUPna4dnTRtQ806ST8G9Vj6WEK32Y&new_forward_geocoder=true&address=" + txtEndereco.Text + ", " + txtNumero.Text + "";

                    ds.ReadXml(address);

                    if (ds != null && ds.Tables["address_component"].Rows.Count >= 7)
                    {
                        string endereco = ds.Tables["result"].Rows[0]["formatted_address"].ToString();
                        string lat = ds.Tables["location"].Rows[0]["lat"].ToString();
                        string log = ds.Tables["location"].Rows[0]["lng"].ToString();

                        Usuario u = new Usuario();
                        u.Latitude = lat;
                        u.Longitude = log;

                        Session["latLog"] = u;
                        Session["address"] = endereco;

                    }
                    else
                    {

                    }
                }
            }
            catch
            {

            }
        }

        protected void btCadastrar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();

            if (dpTipoPessoa.SelectedValue == "2")//PESSOA JURÍDICA
            {
                IsCpfCnpj cnpj = new IsCpfCnpj();
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
                u.Nascimento = DateTime.Today;//Falta arrumar PERMITIR NULL
            }
            else if (dpTipoPessoa.SelectedValue == "1")//PESSOA FÍSICA
            {
                IsCpfCnpj cpf = new IsCpfCnpj();
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
                u.Nascimento = DateTime.Today;//Falta arrumar a data de nascimento.
                u.Genero = int.Parse(dpGenero.SelectedValue);
            }
            else
            {
                //TENTE NOVAMENTE MAIS TARDE;
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
            }
            else if (rdVender.Checked == true)
            {
                u.Tipousuario = new TipoUsuario(int.Parse(rdVender.Value));
            }
            else
            {
                //TENTE NOVAMENTE MAIS TARDE;
            }
            Usuario uEndereco = (Usuario)Session["latlog"];

            u.Latitude = uEndereco.Latitude;
            u.Longitude = uEndereco.Longitude;
            u.Complemento = txtComplemento.Text;

            UsuarioRepositorio cadastrar = new UsuarioRepositorio();
            cadastrar.CadastrarUsuario(u);
            //u.Tipousuario = new TipoUsuario(int.Parse(rdOperacao.SelectedValue));
        }
    }
}