<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SistemaCadastrar.aspx.cs" Inherits="WebApplication.SistemaCadastrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GoogleMapsAPI.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-uppercase"><strong>Cadastre-se</strong></h2>
        <!--1° Etapa - Validar email-->
        <div id="dvPrimeiraEtapa" class="row" runat="server">
            <div class="col-md-6">
                <form class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="<%=txtEmailEtapa1.ClientID%>"" class="col-lg-2 control-label">Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtEmailEtapa1" CssClass="form-control" runat="server" AutoPostBack="True" AutoCompleteType="Email" placeholder="Email" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <div>
                                <asp:Button ID="btValidar" runat="server" Text="Criar uma conta" CssClass="btn btn-primary" OnClick="Validar_Click" />
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
                            <!--Selecionar Tipo Pessoa-->
                            <fieldset class="form-group">
                                <label for="<% =dpTipoPessoa.ClientID%>"" class="col-lg-2 control-label">Tipo Pessoa</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList CssClass="form-control" ID="dpTipoPessoa" onchange="tipoPessoaSel();" runat="server">
                                        <asp:ListItem Text="Física" Value="1" />
                                        <asp:ListItem Text="Jurídica" Value="2" />
                                    </asp:DropDownList>
                                </div>
                            </fieldset>
                            <!--Pessoa Jurídica-->
                            <div id="dvPessoaJuridica" runat="server">
                                <div class="form-group">
                                    <label for="<% =txtCnpj.ClientID%>"" class="col-lg-2 control-label">CNPJ</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtCnpj" runat="server" CssClass="form-control" placeholder="CNPJ" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="<% =txtRazaoSocial.ClientID %>"" class="col-lg-2 control-label">Razão Social</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="form-control" placeholder="Razão Social" required="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!--Pessoa Fisica-->
                            <div id="dvPessoaFisica" runat="server">
                                <div class="form-group">
                                    <label for="<% =txtCpf.ClientID %>"" class="col-lg-2 control-label">CPF</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" placeholder="CPF" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="<% =txtNome.ClientID %>"" class="col-lg-2 control-label">Nome</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Nome" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="<% =txtSobrenome.ClientID %>"" class="col-lg-2 control-label">Sobrenome</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtSobrenome" runat="server" CssClass="form-control" placeholder="Sobrenome" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="<% =txtDtNasc.ClientID %>"" class="col-lg-2 control-label">Data de Nasc.</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtDtNasc" TextMode="Date" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="<% =dpGenero.ClientID %>"" class="col-lg-2 control-label">Genero</label>
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
                                <label for="<% =txtEmailEtapa2.ClientID %>"" class="col-lg-2 control-label">Email</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtEmailEtapa2" runat="server" CssClass="form-control" placeholder="Email" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="<% =txtTel.ClientID %>"" class="col-lg-2 control-label">Telefone</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" placeholder="Telefone" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="<% =txtSenha.ClientID %>"" class="col-lg-2 control-label">Senha</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Atividade principal</label>
                                <div class="btn-group col-lg-10" data-toggle="buttons">
                                    <label class="btn btn-primary">
                                        <input type="radio" name="rdAtividade" id="rdComprar" required="required"/>
                                        Comprar
                                    </label>
                                    <label class="btn btn-primary">
                                        <input type="radio" name="rdAtividade" id="rdVender"/>
                                        Vender
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="<% =txtEndereco.ClientID %>"" class="col-lg-2 control-label">Endereço</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" placeholder="CEP ou Endereço" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="<% =txtComplemento.ClientID %>"" class="col-lg-2 control-label">Complemento</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control" placeholder="Complemento" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div id="dvAreaAtuacao" class="form-group">
                                <label for="<% =txtArea.ClientID %>"" class="col-lg-2 control-label">Área de atuação</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" placeholder="Área de atuação" TextMode="Number" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-10" id="map" style="width: 460px; height: 260px;"></div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <div class="checkbox">
                                        <div class="g-recaptcha" data-callback="capcha_filled" data-sitekey="6Le_HRwUAAAAAKA9I8wNIPFR9rxGhFm1E4x9SOe2"></div>
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
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!--Scripts-->
        <!--reCaptcha-->
        <script src='https://www.google.com/recaptcha/api.js'></script>
        <!--googleMaps-->
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAErShX6RRNkCAj2d3E9bxaEEGKSpIHZ1A&callback=initMap"
            async defer></script>
        <!--Outros-->
        <script>
            function tipoPessoaSel() {
                var dropdown = document.getElementById('<% =dpTipoPessoa.ClientID %>');
                var valorSelecioando = dropdown.options[dropdown.selectedIndex].value;

                if (valorSelecioando == 1) {
                    document.getElementById('<% =dvPessoaFisica.ClientID  %>').style.display = "block";
                    document.getElementById('<% =dvPessoaJuridica.ClientID %>').style.display = "none";
                } else {
                    document.getElementById('<% =dvPessoaFisica.ClientID  %>').style.display = "none";
                    document.getElementById('<% =dvPessoaJuridica.ClientID %>').style.display = "block";
                }
            }
        </script>
    </div>
</asp:Content>


