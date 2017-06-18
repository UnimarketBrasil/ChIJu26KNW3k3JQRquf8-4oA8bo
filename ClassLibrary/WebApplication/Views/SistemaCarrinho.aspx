<%@ Page Title="" Language="C#" MasterPageFile="~/Comprar.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SistemaCarrinho.aspx.cs" Inherits="WebApplication.SistemaCarrinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server" class="table-responsive">
        <h2 class="text-uppercase"><strong>Carrinho de compra</strong></h2>
        <div class="row container-fluid">
            <div id="dvMsg" runat="server" role="alert" visible="false">
                <asp:Label ID="lbMsg" runat="server"></asp:Label>
            </div>
            <div id="dvCarrinhoVazio" runat="server" role="alert" visible="false">
                <asp:Label ID="lbCarrinhoVazio" runat="server">Seu carrinho de compras está vazio...<a onclick="ajudaModal.show('CARRINHO DE COMPRA',8);" class="glyphicon glyphicon-question-sign"></a></asp:Label>
            </div>
            <div id="dvFaltaLogin" runat="server" role="alert" visible="false">
                <asp:Label ID="lbFaltaLogin" runat="server"> Realize login para confirmar o pedido.<a onclick="ajudaModal.show('CARRINHO DE COMPRA',9);" class="glyphicon glyphicon-question-sign"></a></asp:Label>
            </div>
        </div>
        <div class="row container-fluid">
            <asp:GridView ID="grdCarrinhoDeCompra" ShowFooter="true" OnPageIndexChanging="grdCarrinhoDeCompra_PageIndexChanging" CssClass="table table-hover table-striped table-responsive" GridLines="None" runat="server" AutoGenerateColumns="false" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Width="100" ControlStyle-Height="100" ItemStyle-CssClass="col-md-2 col-sm-2 img-responsive" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Nome" HeaderText="Nome do Item" DataNavigateUrlFormatString="SistemaDetalheItem.aspx?id={0}" ItemStyle-CssClass="col-md-4 col-sm-4" />
                    <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2 col-sm-1" />
                    <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitário" ItemStyle-Width="100" ItemStyle-CssClass="col-md-2 col-sm-1" />
                    <asp:TemplateField ItemStyle-CssClass="col-md-2 col-sm-2">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbTotal" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Quantidade")) * Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "ValorUnitario"))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="col-md-2 col-sm-2">
                        <ItemTemplate>
                            <asp:LinkButton ForeColor="Red" ID="lnkExcluir" OnCommand="lnkExcluir_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' runat="server"><span aria-hidden="true" class="glyphicon glyphicon-trash"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="Numeric" Position="TopAndBottom" PageButtonCount="5" />
                <PagerStyle HorizontalAlign="Right" Font-Size="Medium" CssClass="GridPager" />
            </asp:GridView>
        </div>
        <div class="row container-fluid">
            <asp:Label runat="server" CssClass="pull-right" ID="lbTotalCarrinho" Text=""></asp:Label>
        </div>
        <div class="row container-fluid">
            <asp:LinkButton runat="server" ID="lkContinuarCOmprando" Text="Continuar Comprando" CssClass="btn btn-default pull-left" PostBackUrl="~/Views/Sistema.aspx" />
            <asp:Button runat="server" ID="btConfirmarPedido" Text="Confirmar Pedido" CssClass="btn btn-success pull-right" OnClick="btConfirmarPedido_Click" Visible="false" />
        </div>
    </form>
    <script>
        function faltaLogin() {
            faltaLoginDialog.show('Carrinho de Compras');
        }
    </script>
    <script>
        var faltaLoginDialog = faltaLoginDialog || (function ($) {
            'use strict';

            // Creating modal dialog's DOM
            var $dialogFaltaLogin = $(
                '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                '<div class="modal-dialog modal-m">' +
                '<div class="modal-content">' +
                '<div class="modal-header"><h3></3></div>' +
                '<div class="modal-body">É necessário se cadastrar para confirmar pedido.' +
                '<div class="modal-footer"><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="btn btn-success" data-dismiss="modal" >Ok</button>' +
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
                        message = 'Loading';
                    }
                    var settings = $.extend({
                        dialogSize: 'm',
                        progressType: '',
                        onHide: null // This callback runs after the dialog was hidden
                    }, options);

                    // Configuring dialog
                    $dialogFaltaLogin.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
                    $dialogFaltaLogin.find('.progress-bar').attr('class', 'progress-bar');
                    if (settings.progressType) {
                        $dialogProgres.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
                    }
                    $dialogFaltaLogin.find('h3').text(message);
                    // Adding callbacks
                    if (typeof settings.onHide === 'function') {
                        $dialogFaltaLogin.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                            settings.onHide.call($dialogProgres);
                        });
                    }
                    // Opening dialog
                    $dialogFaltaLogin.modal();
                },
                /**
                 * Closes dialog
                 */
                hide: function () {
                    $dialogFaltaLogin.modal('hide');

                }
            };

        })(jQuery);
    </script>
    <script>
        var realizaPedido = realizaPedido || (function ($) {
            'use strict';

            // Creating modal dialog's DOM
            var $dialogConf = $(
                '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                '<div class="modal-dialog modal-m">' +
                '<div class="modal-content">' +
                '<div class="modal-header"><h3>A</3></div>' +
                '<div class="modal-body">Pedido realizado com sucesso!!!' +
                '<div class="modal-footer"><button runat="server" onclick="realizaPedido.hide();chamarPagina();" type="button" class="btn btn-success" data-dismiss="modal" >Ok</button>' +
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
                        message = 'Loading';
                    }
                    var settings = $.extend({
                        dialogSize: 'm',
                        progressType: '',
                        onHide: null // This callback runs after the dialog was hidden
                    }, options);

                    // Configuring dialog
                    $dialogConf.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
                    $dialogConf.find('.progress-bar').attr('class', 'progress-bar');
                    if (settings.progressType) {
                        $dialogProgres.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
                    }
                    $dialogConf.find('h3').text(message);
                    // Adding callbacks
                    if (typeof settings.onHide === 'function') {
                        $dialogConf.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                            settings.onHide.call($dialogProgres);
                        });
                    }
                    // Opening dialog
                    $dialogConf.modal();
                },
                /**
                 * Closes dialog
                 */
                hide: function () {
                    $dialogConf.modal('hide');
                }
            };

        })(jQuery);
    </script>
    <script>
        function chamarPagina() {
            window.location.replace("/Views/Comprador/ComprarPedido.aspx");
        }
    </script>
</asp:Content>
