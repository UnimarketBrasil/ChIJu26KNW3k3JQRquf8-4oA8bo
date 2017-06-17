<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaDetalheItem.aspx.cs" Inherits="WebApplication.SistemaDetalheItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dvMsg" runat="server" role="alert">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <asp:Label ID="lbMsg" runat="server"></asp:Label>
    </div>
    <form runat="server" oninput="calc_total();">
        <div class="panel panel-default">
            <div class="panel-heading text-center">
                <asp:Label runat="server" ID="lbNomeProduto" Text=""></asp:Label>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-4">
                        <div class="form-group">
                            <asp:Image ID="imProduto" class="img-responsive" runat="server" />
                        </div>
                    </div>
                    <div class="col-xs-4">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="h4" Text="Caracteristicas"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lbDescricao" Text=""></asp:Label>
                        </div>
                        <hr />
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="h4" Text="Métodos de Pagamento"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Dinheiro:"></asp:Label>
                            <asp:Label runat="server" Text="Sim"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Cartão de Débito:"></asp:Label>
                            <asp:Label runat="server" ID="lbCartaoDebito" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Cartão de Crédito:"></asp:Label>
                            <asp:Label runat="server" ID="lbCartaoCredito" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="col-xs-4">
                        <div class="form-group well well-sm">
                            <asp:Label runat="server" Text="Preço: R$ "></asp:Label>
                            <asp:Label runat="server" ID="lbValorUnitario" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Quantidade:"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantidade" TextMode="Number" MaxLength="1" Text="1" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Total: R$ "></asp:Label>
                            <asp:Label runat="server" ID="lbTotal" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lbIdItem" Visible="false"></asp:Label>
                            <asp:LinkButton ID="btVoltar" runat="server" CssClass="btn btn-default" OnClientClick="javascript:window.history.go(-1);"><span aria-hidden="true" class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton ID="btAdicionaCarrinho" OnClick="btAdicionaCarrinho_Click" runat="server" CssClass="btn btn-success"><span aria-hidden="true" class="glyphicon glyphicon-plus-sign"></span>&nbsp;Adicionar ao carrinho</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-xs-4">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Vendedor:"></asp:Label>
                            <asp:Label runat="server" ID="lbNomeVendedor" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Endereço:"></asp:Label>
                            <asp:Label runat="server" ID="lbEndereco" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Telefone:"></asp:Label>
                            <asp:Label runat="server" ID="lbTelefone" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="E-mail:"></asp:Label>
                            <asp:Label runat="server" ID="lbEmailVendedor" Text=""></asp:Label>
                        </div>
                        <div id="dvDuvida" runat="server" class="form-group">
                            <div>
                                <asp:Label runat="server" Text="">Dúvidas sobre este item? <a href="#demo" class="btn btn-link" data-toggle="collapse">clique aqui</a></asp:Label>
                            </div>
                            <div id="demo" class="collapse">
                                <asp:Label runat="server" Text="Descreva sua dúvida no campo abaixo, o vendedor receberá por e-mail..."></asp:Label>
                                <div class="input-group">
                                    <input id="txtDuvida" runat="server" type="text" class="form-control">
                                    <span class="input-group-btn">
                                        <button id="btEnviar" onclick="" class="btn btn-default" data-loading-text="Enviando" type="button">Enviar</button>
                                    </span>
                                </div>
                                <asp:Label runat="server" ID="ldMsgEnvio"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $('#btEnviar').on('click', function () {

            var $btn = $(this).button('loading')

            var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById('<% Response.Write(ldMsgEnvio.ClientID);%>').innerHTML = xmlhttp.response;
                    $btn.button('reset')

                    if (xmlhttp.response == 'E-mail enviado com sucesso') {
                        document.getElementById('<% Response.Write(ldMsgEnvio.ClientID);%>').className = "label label-success";
                        $("#txtDuvida").val('');
                    }
                }
            }

            xmlhttp.open("GET", "<%Response.Write(ResolveUrl("~/Views/Ajax/EnviarDuvidaP_Vendedor.aspx"));%>?idItem=" +
                location.search.split('id')[1] + "&NomeVendedor=" +
                document.getElementById("<%Response.Write(lbNomeVendedor.ClientID);%>").innerHTML + "&NomeItem=" +
                document.getElementById("<%Response.Write(lbNomeProduto.ClientID);%>").innerHTML + "&DescricaoItem=" +
                document.getElementById("<%Response.Write(lbDescricao.ClientID);%>").innerHTML + "&Duvida=" +
                document.getElementById("<%Response.Write(txtDuvida.ClientID);%>").value + "&EmailVendedor=" +
                document.getElementById("<%Response.Write(lbEmailVendedor.ClientID);%>").innerHTML, true);
            xmlhttp.send();

        })
    </script>
    <script type="text/javascript">
        function calc_total() {
            var qtd = parseInt(document.getElementById('<% Response.Write(txtQuantidade.ClientID); %>').value);
            var preco = parseFloat(document.getElementById('<% Response.Write(lbValorUnitario.ClientID); %>').innerText.replace(",", "."));
            var tot = (qtd * preco);
            tot = tot.toFixed(2);
            tot = tot.replace(".", ",");
            document.getElementById('<% Response.Write(lbTotal.ClientID);%>').innerHTML = tot;
        }
    </script>
    <script>
        function chamaModal() {
            waitingDialog.show('Ops! Antes precisamos de alguns dados...');
        }
    </script>
    <script type="text/javascript">
        function chamarAjax() {
            var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    location.reload();
                }
            }
            xmlhttp.open("GET", "<%Response.Write(ResolveUrl("~/Views/Ajax/BuscaEndereco.aspx"));%>?cep=" +
                document.getElementById("txtCep").value +
                "&num=" + document.getElementById("txtNumero").value, true);
            xmlhttp.send();
            setTimeout(function () { waitingDialog.hide(); }, 900);

        }
    </script>
    <script>
        var waitingDialog = waitingDialog || (function ($) {
            'use strict';

            // Creating modal dialog's DOM
            var $dialog = $(
                '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:8%; overflow-y:visible;">' +
                '<div class="modal-dialog modal-m">' +
                '<div class="modal-content">' +
                '<div class="modal-header"><h3 style="margin:0;"></h3></div>' +
                '<div class="modal-body"><label class="control-label" for="inputSuccess">CEP</label><input type="number" class="form-control" id="txtCep"><label class="control-label" for="inputSuccess">Número</label><input type="number" class="form-control" id="txtNumero"></div>' +
                '<div class="modal-footer"><button runat="server" onclick="chamarAjax();" type="button" class="btn btn-primary">Continuar...</button></div>' +
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
</asp:Content>
