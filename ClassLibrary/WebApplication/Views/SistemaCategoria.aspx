<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" CodeBehind="SistemaCategoria.aspx.cs" Inherits="WebApplication.SistemaCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="row container-fluid">
            <div id="divMsg" runat="server" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <asp:Label ID="msgPesquisa" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row container-fluid">
            <asp:GridView ID="grdItens" CssClass="table table-hover table-striped" GridLines="None" runat="server" OnPageIndexChanging="grdItens_PageIndexChanging" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="col-md-2" Visible="false" />
                    <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="80" ControlStyle-Height="80" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Nome" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?id={0}" ItemStyle-CssClass="col-md-2" />
                    <asp:BoundField DataField="Vendedor.Nome" HeaderText="Vendedor" ItemStyle-CssClass="col-md-2" />
                    <asp:BoundField DataField="ValorUnitario" HeaderText="Preço" ItemStyle-CssClass="col-md-2" />
                </Columns>
                <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
            </asp:GridView>
        </div>
    </form>
    <script>
        function chamaModal() {
            waitingDialog.show('Ops! Antes precisamos de alguns dados...');
        }
    </script>
    <script type="text/javascript">
        function chamarAjax() {
            var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");

            xmlhttp.onreadystatechange = function () {
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
