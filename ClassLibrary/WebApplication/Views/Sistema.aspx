<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="Sistema.aspx.cs" Inherits="WebApplication.Sistema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container">
            <div class="">
                <h1 class="text-uppercase"><strong>Seja bem vindo!</strong></h1>
                <div id="dvMsg" runat="server" role="alert" visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong class="glyphicon glyphicon-info-sign"></strong>
                    <asp:Label ID="lbMsg" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div role="main" class="col-sm-8">
                    teste
                </div>
                <aside runat="server" id="sdLogin" role="complementary" class="col-sm-4">
                    <h2 class="text-uppercase"><strong>Login</strong></h2>
                    <div id="dvPrimeiraEtapa" class="row" runat="server">
                        <div class="form-group">
                            <label for="txtEmail" class="col-sm-2 control-label">Email</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" AutoCompleteType="Email" placeholder="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtSenha" class="col-sm-2 control-label">Senha</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10 col-sm-offset-2">
                                <asp:Label runat="server">Ainda não possui cadastro? <a href="SistemaCadastrar.aspx">Crie uma conta!</a></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10 col-sm-offset-2">
                                <div>
                                    <asp:Button ID="btLogin" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </aside>
            </div>
        </div>
    </form>
</asp:Content>
