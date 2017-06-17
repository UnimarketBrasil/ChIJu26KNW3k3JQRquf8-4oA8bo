<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaAtualizarCadastro.aspx.cs" Inherits="WebApplication.SistemaAtualizarCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="dvMsg" runat="server" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close" formmethod="put"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="lbMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-uppercase"><strong>Atualizar Cadastro</strong></h2>
        <!--Atualizar Cadastro-->
        <div id="dvAtualizarCadastro" class="row" runat="server">
            <form class="form-horizontal" runat="server">
                <div class="col-md-6">
                    <!--Pessoa Fisica-->
                    <div class="row">
                        <div id="dvPessoaFisica" runat="server">
                            <div class="form-group">
                                <label for="" class="col-lg-2 control-label">CPF</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" placeholder="CPF" required="true" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-lg-2 control-label">Nome</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Nome" required="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-lg-2 control-label">Sobrenome</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtSobrenome" runat="server" CssClass="form-control" placeholder="Sobrenome" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!--Pessoa Jurídica-->
                        <div id="dvPessoaJuridica" runat="server">
                            <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                            <div class="form-group">
                                <label for="" class="col-lg-2 control-label">CNPJ</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtCnpj" runat="server" CssClass="form-control" placeholder="CNPJ" required="true" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-lg-2 control-label">Razão Social</label>
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="form-control" placeholder="Razão Social" required="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--Email / Tel / Senha / Botão -->
                    <div class="form-group">
                        <label for="" class="col-lg-2 control-label">Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="" class="col-lg-2 control-label">Telefone</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" placeholder="Telefone" MaxLength="15" onkeyup="formataTelefone(this,event);" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="" class="col-lg-2 control-label">Endereço</label>
                        <div class="col-lg-5">
                            <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" OnKeyUp="formataCEP(this,event);" onchange="formataCEP(this,event);" placeholder="CEP" required="true" MaxLength="9"></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" TextMode="Number" placeholder="N°" required="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <button type="button" draggable="false" class="btn btn-primary" onclick="chamarAjax();" formmethod="put"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                        </div>
                    </div>
                    <div id="dvEndereco" runat="server" class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Label runat="server" ID="lbEndereco_" Font-Bold="True" CssClass="form-control well well-sm"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="" class="col-lg-2 control-label">Complemento</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control" placeholder="Complemento"></asp:TextBox>
                        </div>
                    </div>
                    <div id="dvAreaAtuacao" class="form-group" runat="server">
                        <label for="" class="col-lg-2 control-label">Área de atuação</label>
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
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <div>
                                <a onclick="cancelarContaDialog.show()">Cancelar Conta</a>
                            </div>
                            <p></p>
                            <div>
                                <asp:Button runat="server" ID="btSalvar" Text="Salvar" CssClass="btn btn-primary" OnClick="btSalvar_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div class="form-group col-md-3" runat="server">
                    <div>
                        <asp:Image ID="userImage" CssClass="img-circle img-responsive" runat="server" />
                    </div>
                    <div class="form-group" runat="server">
                        <asp:FileUpload ID="InputFoto" CssClass="file" accept="image/*" runat="server" />
                    </div>
                </div>
                <div id="dvMetodo" class="form-group col-md-3" runat="server" visible="false">
                    <asp:CheckBoxList ID="cbMetodosPagamento" runat="server">
                    </asp:CheckBoxList>
                </div>
            </form>
        </div>
    </div>
    <!--Scripts-->
    <!--googleMaps-->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAErShX6RRNkCAj2d3E9bxaEEGKSpIHZ1A&callback=initMap"
        async defer></script>
    <!--Outros-->
    <script type="text/javascript" src="../Scripts/Mascara.js"></script>
    <script type="text/javascript">
        function chamarAjax() {
            waitingDialog.show('Buscando...');
            var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById('<%Response.Write(lbEndereco_.ClientID);%>').innerHTML = xmlhttp.response;
                    setTimeout(function () { waitingDialog.hide(); }, 500);
                }
            }

            xmlhttp.open("GET", "<%Response.Write(ResolveUrl("~/Views/Ajax/BuscaEndereco.aspx"));%>?cep=" +
                document.getElementById("<%Response.Write(txtEndereco.ClientID);%>").value +
                "&num=" + document.getElementById("<%Response.Write(txtNumero.ClientID);%>").value, true);
            xmlhttp.send();
            setTimeout(function () { waitingDialog.hide(); }, 900);
        }

    </script>
    <script>
        var waitingDialog = waitingDialog || (function ($) {
            'use strict';

            // Creating modal dialog's DOM
            var $dialog = $(
                '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                '<div class="modal-dialog modal-m">' +
                '<div class="modal-content">' +
                '<div class="modal-header"><h3 style="margin:0;"></h3></div>' +
                '<div class="modal-body">' +
                '<div class="progress progress-striped active" style="margin-bottom:0;"><div class="progress-bar" style="width: 100%"></div></div>' +
                '</div>' +
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
                        message = 'Loading';
                    }
                    var settings = $.extend({
                        dialogSize: 'm',
                        progressType: '',
                        onHide: null // This callback runs after the dialog was hidden
                    }, options);

                    // Configuring dialog
                    $dialog.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
                    $dialog.find('.progress-bar').attr('class', 'progress-bar');
                    if (settings.progressType) {
                        $dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
                    }
                    $dialog.find('h3').text(message);
                    // Adding callbacks
                    if (typeof settings.onHide === 'function') {
                        $dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                            settings.onHide.call($dialog);
                        });
                    }
                    // Opening dialog
                    $dialog.modal();
                },
                /**
                 * Closes dialog
                 */
                hide: function () {
                    $dialog.modal('hide');
                }
            };

        })(jQuery);
    </script>
    <script>
        var cancelarContaDialog = cancelarContaDialog || (function ($) {
            'use strict';

            // Creating modal dialog's DOM
            var $dialogCancela = $(
                '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                '<div class="modal-dialog modal-m">' +
                '<div class="modal-content">' +
                '<div class="modal-header"><h3>A</3></div>' +
                '<div class="modal-body">Tem certeza que deseja cancelar sua conta? Esta operação não pode ser desfeita!' +
                '<div class="modal-footer"><button runat="server" onclick="cancelarContaDialog.hide();" type="button" class="btn btn-success" data-dismiss="modal" >NÃO CANCELAR</button>' +
                '<button runat="server" onclick="cancelarContaDialog.hide();cancelarConta();" type="button" class="btn btn-danger" data-dismiss="modal" >SIM</button>' +
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
                        message = 'Cancelar Conta';
                    }
                    var settings = $.extend({
                        dialogSize: 'm',
                        progressType: '',
                        onHide: null // This callback runs after the dialog was hidden
                    }, options);

                    // Configuring dialog
                    $dialogCancela.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
                    $dialogCancela.find('.progress-bar').attr('class', 'progress-bar');
                    if (settings.progressType) {
                        $dialogCancela.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
                    }
                    $dialogCancela.find('h3').text(message);
                    // Adding callbacks
                    if (typeof settings.onHide === 'function') {
                        $dialogCancela.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                            settings.onHide.call($dialog);
                        });
                    }
                    // Opening dialog
                    $dialogCancela.modal();
                },
                /**
                 * Closes dialog
                 */
                hide: function () {
                    $dialogCancela.modal('hide');
                }
            };

        })(jQuery);
    </script>
    <script type="text/javascript">
        function cancelarConta() {
            var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.location.href = '/Views/Logout.aspx'
                }
            }


            xmlhttp.open("GET", "<%Response.Write(ResolveUrl("~/Views/Ajax/CancelarConta.aspx"));%>", true);

            xmlhttp.send();

        }
    </script>
</asp:Content>
