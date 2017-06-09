<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaRecuperarSenha.aspx.cs" Inherits="WebApplication.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="dvMsg" runat="server" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="lbMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-uppercase"><strong>Alterar Senha</strong></h2>
        <div id="dvPrimeiraEtapa" class="row" runat="server">
            <div class="col-md-6">
                <form class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="txtSenha" class="col-lg-2 control-label">Nova Senha</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtSenha" CssClass="form-control" runat="server" TextMode="Password" placeholder="Nova Senha"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtConfSenha" class="col-lg-2 control-label">Confirma Senha</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtConfSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirma Senha"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <div>
                                <asp:Button ID="btLogin" runat="server" Text="Salvar" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
