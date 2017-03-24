<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SistemaCadastrar.aspx.cs" Inherits="WebApplication.SistemaCadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-uppercase"><strong>Cadastre-se</strong></h2>
        <!--1° Etapa - Validar email-->
        <div id="dvPrimeiraEtapa" class="row" runat="server">
            <div class="col-md-6">
                <form class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="txtEmailEtapa1" class="col-lg-2 control-label">Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtEmailEtapa1" CssClass="form-control" runat="server" AutoPostBack="True" AutoCompleteType="Email" placeholder="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <div>
                                <asp:Button ID="myButtonEtapa1" runat="server" Text="Cadastrar!" CssClass="btn btn-primary" OnClick="myButtonEtapa1_Click" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <!--2° Etapa - Dados da pessoa-->
        <div id="dvSegundaEtapa" class="row" runat="server">
            <div>
                <div class="col-md-6">
                    <div class="sm-m-top-50">
                        <form class="form-horizontal" runat="server">
                            <fieldset>
                                <!--Selecionar Tipo Pessoa-->
                                <fieldset class="form-group">
                                    <label for="select" class="col-lg-2 control-label">Tipo Pessoa</label>
                                    <div class="col-lg-10">
                                        <asp:DropDownList CssClass="form-control" ID="dpTipoPessoa" onchange="tipoPessoaSel();" runat="server">
                                            <asp:ListItem Text="Física" Value="1" />
                                            <asp:ListItem Text="Jurídica" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                </fieldset>
                                <!--Pessoa Jurídica-->
                                <fieldset id="pessoaJuridica" runat="server">
                                    <div class="form-group">
                                        <label for="txtCnpj" class="col-lg-2 control-label">CNPJ</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtCnpj" runat="server" CssClass="form-control" placeholder="CNPJ"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtRazaoSocial" class="col-lg-2 control-label">Razão Social</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="form-control" placeholder="Razão Social"></asp:TextBox>
                                        </div>
                                    </div>
                                </fieldset>
                                <!--Pessoa Fisica-->
                                <div id="pessoaFisica" runat="server">
                                    <div class="form-group">
                                        <label for="txtCpf" class="col-lg-2 control-label">CPF</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" placeholder="CPF"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtNome" class="col-lg-2 control-label">Nome</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Nome"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtSobrenome" class="col-lg-2 control-label">Sobrenome</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtSobrenome" runat="server" CssClass="form-control" placeholder="Nome"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtDtNasc" class="col-lg-2 control-label">Data de Nasc.</label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtDtNasc" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="dpGenero" class="col-lg-2 control-label">Genero</label>
                                        <div class="col-lg-10">
                                            <asp:DropDownList CssClass="form-control" ID="dpGenero" runat="server">
                                                <asp:ListItem Text="Masculino" Value="1" />
                                                <asp:ListItem Text="Feminino" Value="2" />
                                                <asp:ListItem Text="Outros" Value="3" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!--Email / Tel / Senha / Robô / Botão -->
                                <div class="form-group">
                                    <label for="txtEmailEtapa2" class="col-lg-2 control-label">Email</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtEmailEtapa2" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtTel" class="col-lg-2 control-label">Telefone</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" placeholder="Telefone"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtSenha" class="col-lg-2 control-label">Senha</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtSenhaConf" class="col-lg-2 control-label">Confirmar Senha</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtSenhaConf" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar Senha"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="rdCompra" class="col-lg-2 control-label">Cê quer o que?</label>
                                    <div class="col-lg-10">
                                        <asp:RadioButtonList ID="rdOperacao" runat="server" RepeatLayout="Flow">
                                            <asp:ListItem Value="2">Comprar</asp:ListItem>
                                            <asp:ListItem Value="3">Vender</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <div class="checkbox">
                                            <script src='https://www.google.com/recaptcha/api.js'></script>
                                            <div class="g-recaptcha" data-sitekey="6Lc-HRcUAAAAAG-oWXYAcgOnqXQ7TEHGEESB_PiZ"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <div>
                                            <asp:Button runat="server" ID="myButtonEtapa2" Text="Cadastrar!" CssClass="btn btn-primary" OnClick="myButtonEtapa2_Click"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!--Scripts-->
        <script>
            //Ocultar Fieldset Pessoa Jutídica
            window.onload = function ocultarPessoaJuridica() {
                document.getElementById('<% =pessoaJuridica.ClientID %>').style.display = "none";
            }
            //Animação do Botão Cadastrar
            $('#myButton').on('click', function () {
                var $btn = $(this).button('loading')
                //$btn.button('reset')
            })

            //
            function tipoPessoaSel() {
                var dropdown = document.getElementById('<% =dpTipoPessoa.ClientID %>');
                var valorSelecioando = dropdown.options[dropdown.selectedIndex].value;

                if (valorSelecioando == 1) {
                    document.getElementById('<% =pessoaFisica.ClientID  %>').style.display = "block";
                    document.getElementById('<% =pessoaJuridica.ClientID %>').style.display = "none";
                } else {
                    document.getElementById('<% =pessoaFisica.ClientID  %>').style.display = "none";
                    document.getElementById('<% =pessoaJuridica.ClientID %>').style.display = "block";
                }
            }
        </script>
    </div>

</asp:Content>


