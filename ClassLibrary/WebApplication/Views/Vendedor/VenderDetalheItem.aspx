<%@ Page Title="" Language="C#" MasterPageFile="~/Vender.Master" AutoEventWireup="true" CodeBehind="VenderDetalheItem.aspx.cs" Inherits="WebApplication.SistemaNovoItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap-fileinput.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="dvMsg" runat="server" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="lbMsg" runat="server"></asp:Label>
        </div>
        <div class="panel panel-default">
            <div id="dvHeadNovo" runat="server" class="panel-heading">
                <h4>Novo Item<a onclick="ajudaModal.show('NOVO ITEM',5);" class='glyphicon glyphicon-question-sign small' style="color: #2780e3"></a></h4>
            </div>
            <div id="dvHeadAlterar" runat="server" class="panel-heading">
                <h4>Alterar Item</h4>
            </div>
            <div class="panel-body">
                <form runat="server">
                    <div class="row">
                        <div class="col-xs-6 col-sm-2 col-md-2 col-lg-2 form-group">
                            <label for="iputnome">Imagem do Item</label>
                            <div class="form-group">
                                <asp:Image ID="imItem" CssClass="img-responsive" runat="server" />
                            </div>
                            <div>
                                <asp:FileUpload ID="InputFoto" CssClass="file" accept="image/*" runat="server" />
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-7 col-md-7 col-lg-7 form-group">
                            <label for="<%=txtNome.ClientID%>">Nome do Item</label>
                            <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" placeholder="Nome do Produto" required="true"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3 form-group">
                            <label for="<%=txtCod.ClientID%>">Código do Item</label>
                            <asp:TextBox runat="server" ID="txtCod" CssClass="form-control" placeholder="Cód" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h4 class="form-group">Informações do Item</h4>
                            <hr />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-7 col-lg-7 form-group">
                            <label for="<%=dpCategoria.ClientID%>">Categoria</label>
                            <asp:DropDownList ID="dpCategoria" runat="server" CssClass="form-control" DataTextField="Nome" DataValueField="Id" />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3 form-group">
                            <label for="<%=txtQuantidade.ClientID %>">Quantidade</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtQuantidade" onKeyUp="calc_total();" onchange="calc_total();" TextMode="Number" MaxLength="1" CssClass="form-control" placeholder="Quantidade" required="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2 form-group">
                            <label for="<%=txtValorUnitario.ClientID%>">Valor Unitário</label>
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="txtValorUnitario" onchange="formataValor(this,event); calc_total();" onKeyUp="calc_total(); formataValor(this,event);" CssClass="form-control" placeholder="Valor Unitário" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                            <label for="<%=txtDescricao.ClientID%>">Descrição</label>
                            <div class="input-group">
                                <textarea runat="server" id="txtDescricao" cols="127" rows="3" maxlength="800" style="resize: none; width: 100%"></textarea>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2 form-group">
                            <label for="<%=lbValorTotal.ClientID%>">Valor Total</label>
                            <div class="input-group">
                                <asp:Label runat="server" ID="lbValorTotal" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="dvBtnAlterar" class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                                <div class="btn btn-danger glyphicon glyphicon-trash">
                                    <asp:Button ID="btnLixeira" runat="server" BackColor="Transparent" BorderWidth="0" Text="Excluir" OnClick="btnLixeira_Click"></asp:Button>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <button onclick="javascript:window.history.go(-1);" type="reset" class="btn btn-default">Cancelar</button>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <asp:Button runat="server" ID="btSalvarrItem" Text="Salvar" CssClass="btn btn-primary" OnClick="btAtualizarItem_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div runat="server" id="dvBtnNovo" class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-12 col-md-10 col-lg-10 form-group">
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <button type="reset" onclick="javascript:window.history.go(-1);" class="btn btn-default">Cancelar</button>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-1 col-lg-1 form-group">
                                <asp:Button runat="server" ID="btAtualizarItem" Text="Salvar" CssClass="btn btn-primary" OnClick="bt_CadastrarItem"></asp:Button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function calc_total() {
            var resultadoF=0;
            var qtd = parseInt(document.getElementById('<% Response.Write(txtQuantidade.ClientID); %>').value);
            var preco = document.getElementById('<% Response.Write(txtValorUnitario.ClientID); %>').value;

            if ((document.getElementById('<%Response.Write(txtQuantidade.ClientID);%>').value != "") && (document.getElementById('<%Response.Write(txtValorUnitario.ClientID);%>').value != "")) {
                preco = preco.replace(",", ".");
                resultadoF = (preco * qtd);
                document.getElementById('<%Response.Write(lbValorTotal.ClientID);%>').innerHTML = (resultadoF).toFixed(2);
            }
            else {
                document.getElementById('<%Response.Write(lbValorTotal.ClientID);%>').innerHTML = "";
            }
        }
        
    </script>
    <script>
        function chamaModal() {
            waitingDialog.show('ITEM EXCLUÍDO');
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
                '<div class="modal-body"><p>Item excluído com sucesso.</p></div>' +
                '<div class="modal-footer"><a runat="server" href="~/Views/VenderItem.aspx" class="btn btn-primary">Ok</a></div>' +
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
    <script src="../../Scripts/Mascara.js"></script>
</asp:Content>
