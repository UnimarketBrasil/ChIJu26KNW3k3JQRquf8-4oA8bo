<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaAtualizarCadastro.aspx.cs" Inherits="WebApplication.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div id="dvMsg" runat="server" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <strong>!</strong> <asp:Label ID="lbMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-uppercase"><strong>Atualizar Cadastro</strong></h2>
        <!--Atualizar Cadastro-->
        <div id="dvSegundaEtapa" class="row" runat="server">
            <div>
                <div class="col-md-6">
                    <div class="sm-m-top-50">
                        <form class="form-horizontal" runat="server">
                            <!--Pessoa Fisica-->
                            <div id="dvPessoaFisica" runat="server">
                                <div class="form-group">
                                    <label for="<% =txtCpf.ClientID %>"" class="col-lg-2 control-label">CPF</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" placeholder="CPF" required="true" Enabled="False"></asp:TextBox>
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
                                        <asp:TextBox ID="txtDtNasc" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="<% =dpGenero.ClientID %>"" class="col-lg-2 control-label">Genero</label>
                                   <%-- <div class="col-lg-10">
                                        <asp:DropDownList CssClass="form-control" ID="dpGenero" runat="server">
                                            <asp:ListItem Text="Masculino" Value="1" />
                                            <asp:ListItem Text="Feminino" Value="2" />
                                            <asp:ListItem Text="Outros" Value="3" />
                                        </asp:DropDownList>
                                    </div>--%>
                                </div>
                            </div>
                            <!--Pessoa Jurídica-->
                            <div id="dvPessoaJuridica" runat="server">
                                <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                                <div class="form-group">
                                    <label for="<% =txtCnpj.ClientID%>"" class="col-lg-2 control-label">CNPJ</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtCnpj" runat="server" CssClass="form-control" placeholder="CNPJ" required="true" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="<% =txtRazaoSocial.ClientID %>"" class="col-lg-2 control-label">Razão Social</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="form-control" placeholder="Razão Social" required="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!--Email / Tel / Senha / Botão -->
                            <div class="form-group">
                                <label for="<% =txtEmail.ClientID %>"" class="col-lg-2 control-label">Email</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="<% =txtTel.ClientID %>"" class="col-lg-2 control-label">Telefone</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" placeholder="Telefone" MaxLength="15" onkeyup="formataTelefone(this,event);" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-2 control-label">Atividade principal</label>
                                <div class="btn-group col-lg-10" data-toggle="buttons">
                                    <label id="lbComprar" runat="server" class="btn btn-primary">
                                        <input type="radio" name="rdAtividade" id="rdComprar" onchange="areAtuacaoDisplay('c');" runat="server" value="1" required="required"/>
                                        Comprar
                                    </label>
                                    <label id="lbVender" runat="server" class="btn btn-primary">
                                        <input type="radio" name="rdAtividade" id="rdVender" onchange="areAtuacaoDisplay('v');" runat="server" value="2" />
                                        Vender
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="<% =txtEndereco.ClientID %>" class="col-lg-2 control-label">Endereço</label>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" placeholder="CEP ou Endereço" required="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" TextMode="Number"  placeholder="N°" required="true" OnTextChanged="txtNumero_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="dvEnderecoCompleto" runat="server" class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Label runat="server" ID="lbEndereco"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="<% =txtComplemento.ClientID %>" class="col-lg-2 control-label">Complemento</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control" placeholder="Complemento" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div id="dvAreaAtuacao" class="form-group" runat="server">
                                <label for="<% =dpArea.ClientID %>"" class="col-lg-2 control-label">Área de atuação</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList CssClass="form-control" ID="dpArea" runat="server">
                                        <asp:ListItem Text="5 km" Value="5" />
                                        <asp:ListItem Text="10 km" Value="10" />
                                        <asp:ListItem Text="20 km" Value="20" />
                                        <asp:ListItem Text="30 km" Value="30" />
                                        <asp:ListItem Text="40 km" Value="40" />
                                        <asp:ListItem Text="50 km" Value="50" />
                                        <asp:ListItem Text="75 km" Value="75" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <!--GOOGLE MAPS
                            <div class="form-group">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-10 form-control" runat="server" id="map" style="width: 460px; height: 260px;"></div>
                            </div>
                            -->
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <div>
                                        <asp:Button runat="server" ID="btSalvar" Text="Salvar" CssClass="btn btn-primary" OnClick="btSalvar_Click" ></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!--Scripts-->
        <!--googleMaps-->
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAErShX6RRNkCAj2d3E9bxaEEGKSpIHZ1A&callback=initMap"
            async defer></script>
        <!--Outros-->
        <script src="../Scripts/bootstrap-datepicker.js"></script>
        <script src="../Scripts/locales/bootstrap-datepicker.pt-BR.min.js"></script>
        <script type="text/javascript" src="../Scripts/Mascara.js"></script>
        <script>
            function areAtuacaoDisplay(s) {

                if (s == 'c') {
                    document.getElementById('<% =dvAreaAtuacao.ClientID%>').style.display = "none";
                    document.getElementById('<% =lbComprar.ClientID%>').className = "btn btn-primary active";
                    document.getElementById('<% =lbVender.ClientID%>').className = "btn btn-primary";
                } else {
                    document.getElementById('<% =dvAreaAtuacao.ClientID%>').style.display = "block";
                    document.getElementById('<% =lbVender.ClientID%>').className = "btn btn-primary active";
                    document.getElementById('<% =lbComprar.ClientID%>').className = "btn btn-primary";
                }
            }

            $('#<%=txtDtNasc.ClientID%>').datepicker({
                language: "pt-BR",
                format: "dd/mm/yyyy"
            });
        </script>
    </div>
</asp:Content>
