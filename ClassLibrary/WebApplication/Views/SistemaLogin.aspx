﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaLogin.aspx.cs" Inherits="WebApplication.SistemaLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="dvMsg" runat="server" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <strong class="glyphicon glyphicon-info-sign"></strong>
            <asp:Label ID="lbMsg" runat="server"></asp:Label>
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
                    <!--Recuperar Senha-->
                    <div class="form-group">
                        <div class="col-sm-10 col-sm-offset-2">
                            <asp:Label runat="server" Text="">Esqueceu sua senha? <a href="#demo" class="btn btn-link" data-toggle="collapse">clique aqui</a></asp:Label>
                        </div>
                        <div id="demo" class="collapse col-sm-10 col-sm-offset-2">
                            <asp:Label runat="server" Text="Insira seu email abaixo, você receberá um link para criar uma nova senha."></asp:Label>
                            <div class="input-group">
                                <input id="txtEmailRecuperar" type="text" class="form-control" placeholder="E-mail">
                                <span class="input-group-btn">
                                    <button id="btRecuperar" onclick="" class="btn btn-default" data-loading-text="Enviando" type="button">Enviar</button>
                                </span>
                            </div>
                            <asp:Label runat="server" ID="ldMsgRecuperar"></asp:Label>
                        </div>
                    </div>
                    <p></p>
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
    <script type="text/javascript">
        $('#btRecuperar').on('click', function () {

            var $btn = $(this).button('loading')

            var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById('<% Response.Write(ldMsgRecuperar.ClientID);%>').innerHTML = xmlhttp.response;
                    $btn.button('reset')

                    if (xmlhttp.response == 'E-mail não localizado...') {
                        document.getElementById('<% Response.Write(ldMsgRecuperar.ClientID);%>').className = "label label-danger";
                    }
                    else if (xmlhttp.response == 'E-mail enviado com sucesso') {
                        document.getElementById('<% Response.Write(ldMsgRecuperar.ClientID);%>').className = "label label-success";
                        $("#txtEmailRecuperar").val('');
                    }
                }
            }

            xmlhttp.open("GET", "<%Response.Write(ResolveUrl("~/Views/Ajax/RecuperarSenha.aspx"));%>?email=" +
                document.getElementById('txtEmailRecuperar').value, true);


            xmlhttp.send();

        })
    </script>
</asp:Content>
