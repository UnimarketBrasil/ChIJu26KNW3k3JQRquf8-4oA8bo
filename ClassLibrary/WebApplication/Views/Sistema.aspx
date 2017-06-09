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
                    <div runat="server" id="dvBanner" class="carousel slide" data-ride="carousel" style="width: 400px; margin: 0 auto">
                        <!-- Banner Rotativo -->
                        <ol class="carousel-indicators">
                            <li data-target="#Banner" data-slide-to="0" class="active"></li>
                            <li data-target="#Banner" data-slide-to="1"></li>
                            <li data-target="#Banner" data-slide-to="2"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                            <div class="item active">
                                <asp:Image ID="imgTop1" runat="server" CssClass="img-responsive" Width="100%" />
                                <div class="carousel-caption">
                                    <h3><a runat="server" id="nomeTop1">
                                        <asp:Label runat="server" ID="nomeItem1"></asp:Label></a></h3>
                                    <p>
                                        <asp:Label runat="server" ID="precoItem1"></asp:Label>
                                    </p>
                                </div>
                            </div>

                            <div class="item">
                                <asp:Image ID="imgTop2" runat="server" CssClass="img-responsive" Width="100%" />
                                <div class="carousel-caption">
                                    <h3><a runat="server" id="nomeTop2">
                                        <asp:Label runat="server" ID="nomeItem2"></asp:Label></a></h3>
                                    <p>
                                        <asp:Label runat="server" ID="precoItem2"></asp:Label>
                                    </p>
                                </div>
                            </div>

                            <div class="item">
                                <asp:Image ID="imgTop3" runat="server" CssClass="img-responsive" Width="100%" />
                                <div class="carousel-caption">
                                    <h3><a runat="server" id="nomeTop3">
                                        <asp:Label runat="server" ID="nomeItem3"></asp:Label></a></h3>
                                    <p>
                                        <asp:Label runat="server" ID="precoItem3"></asp:Label>
                                    </p>
                                </div>
                            </div>

                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#Banner" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#Banner" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
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
                                        <button id="btRecuperar" onclick="" class="btn btn-default" data-loading-text="Enviando" type="button" >Enviar</button>
                                    </span>
                                </div>
                                <asp:Label runat="server" id="ldMsgRecuperar"></asp:Label>
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
    <script>
        var primeiroAcesso = primeiroAcesso || (function ($) {
            'use strict';

            // Creating modal dialog's DOM
            var $dialogacesso1 = $(
                '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                '<div class="modal-dialog modal-m">' +
                '<div class="modal-content">' +
                '<div class="modal-header"><h3>A</3></div>' +
                '<div class="modal-body">Para completar seu cadastro, confirme seu e-mail clicando no link que acabamos de enviar para você...' +
                '<div class="modal-footer"><button runat="server" onclick="fimCadastroDialog.hide();redirecionarPrincial();" type="button" class="btn btn-success" data-dismiss="modal" >Concordo</button>' +
                '</div></div>' +
                '</div></div></div>');

            return {
                /**
                 * Opens our dialog
                 * @param message Custom message
                 * @param options Custom options:
                 * 				  options.dialogSize - bootstrap postfix for dialog size, e.g. "sm", "m";
                 * 				  options.progressType - bootstrap postfix for progress bar type, e.g. "success", "warning".
                 */
                show: function (message, options) {
                    // Assigning defaults
                    if (typeof options === 'undefined') {
                        options = {};
                    }
                    if (typeof message === 'undefined') {
                        message = 'SEJA BEM VINDO';
                    }
                    var settings = $.extend({
                        dialogSize: 'm',
                        progressType: '',
                        onHide: null // This callback runs after the dialog was hidden
                    }, options);

                    // Configuring dialog
                    $dialogacesso1.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
                    $dialogacesso1.find('.progress-bar').attr('class', 'progress-bar');
                    if (settings.progressType) {
                        $dialogProgres.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
                    }
                    $dialogacesso1.find('h3').text(message);
                    // Adding callbacks
                    if (typeof settings.onHide === 'function') {
                        $dialogacesso1.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                            settings.onHide.call($dialogProgres);
                        });
                    }
                    // Opening dialog
                    $dialogacesso1.modal();
                },
                /**
                 * Closes dialog
                 */
                hide: function () {
                    $dialogacesso1.modal('hide');

                }
            };

        })(jQuery);
    </script>
</asp:Content>
