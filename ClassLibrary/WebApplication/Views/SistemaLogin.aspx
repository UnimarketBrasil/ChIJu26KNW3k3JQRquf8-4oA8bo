﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaLogin.aspx.cs" Inherits="WebApplication.SistemaLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <!--Style e Script-->


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="dvMsg" runat="server" class="alert alert-success alert-dismissible" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <strong>Erro!</strong> Better check yourself, you're not looking too good.
        </div>
        <h2 class="text-uppercase"><strong>Login</strong></h2>
        <div id="dvPrimeiraEtapa" class="row" runat="server">
            <div class="col-md-6">
                <form class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="txtEmail" class="col-lg-2 control-label">Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" AutoCompleteType="Email" placeholder="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtSenha" class="col-lg-2 control-label">Senha</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <div>
                                <asp:Button ID="btLogin" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btLogin_Click" />
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script>
        $('<% %>').on('closed.bs.alert', function () {
            // do something…
        })
    </script>
</asp:Content>
