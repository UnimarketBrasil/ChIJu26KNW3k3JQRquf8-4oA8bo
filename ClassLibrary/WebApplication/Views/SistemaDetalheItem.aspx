<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaDetalheItem.aspx.cs" Inherits="WebApplication.SistemaDetalheItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" oninput="calc_total();">
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading text-center">
                <asp:Label runat="server" ID="lbNomeProduto" Text="Nome Do Seu Produto"></asp:Label>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4 col-sm-6">
                        <div class="form-group">
                            <asp:Image ID="imProduto" class="img-responsive" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="form-group well well-sm">
                            <asp:Label runat="server" Text="Preço: R$ "></asp:Label>
                            <asp:Label runat="server" ID="lbValorUnitario" Text="R$ 190.00"></asp:Label>
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
                            <asp:LinkButton ID="btLixeira" runat="server" CssClass="btn btn-default" PostBackUrl="~/Views/SistemaPesquisa.aspx"><span aria-hidden="true" class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton ID="btAdicionaCarrinho" OnClick="btAdicionaCarrinho_Click" runat="server" CssClass="btn btn-success"><span aria-hidden="true" class="glyphicon glyphicon-plus-sign"></span>&nbsp;COMPRAR</asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Vendedor:"></asp:Label>
                            <asp:Label runat="server" ID="lbNomeVendedor" Text="Jão da Silva"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Endereço:"></asp:Label>
                            <asp:Label runat="server" ID="lbEndereco" Text="Rua blá blá"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="Telefone:"></asp:Label>
                            <asp:Label runat="server" ID="lbTelefone" Text="(41) 1234-5678"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" Text="E-mail:"></asp:Label>
                            <asp:Label runat="server" ID="lbEmailVendedor" Text="jose@jose.com"></asp:Label>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-8">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lbDescricao" Text="Um produto muito bom"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
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
