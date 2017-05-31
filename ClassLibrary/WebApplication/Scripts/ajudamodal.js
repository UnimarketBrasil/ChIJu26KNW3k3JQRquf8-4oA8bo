var ajudaModal = ajudaModal || (function ($) {
    'use strict';

    // Creating modal dialog's DOM

    return {
        /**
         * Opens our dialog
         * @param message Custom message
         * @param options Custom options:
         * 				  options.dialogSize - bootstrap postfix for dialog size, e.g. "sm", "m";
         * 				  options.progressType - bootstrap postfix for progress bar type, e.g. "success", "warning".
         */
        show: function (mensagem, options) {
            switch (options) {
                case 1:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">No Unimarket você pode comprar ou vender produtos e/ou serviços...' +
                        'Só precisamos saber qual a sua principal intenção, assim vamos preparar o melhor ambiente para você!' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 2:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">Precisamos saber o seu endereço, assim localizaremos os itens mais próximo de você, informe seu CEP e número, buscaremos o restante...' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 3:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">Sua atividade principal é vender... Informe a área que que seus intens ficarão disponíveis, caso precise expandir sua área de atuação mais tarde é só atualizar o seu cadastro.' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 4:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">É nesta tela que aparecerá todos itens que você tem cadastrado no sistema, aqui você pode selecionar o item clicando no nome para atualizar o cadastro ou até mesmo excluir.' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 5:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">Informe o nome, código do item, categoria, quantidade disponível para venda, valor unitário e descrição do item. Você também pode salvar um imagem do produto.' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 6:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">É aqui onde você acompanha o ststus dos seus pedidos, é possível gerar PDF e visualizar detalhes dos mesmos.' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 7:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">É aqui onde você pode cancelar ou dar baixa em seus pedidos, é possível gerar PDF e visualizar detalhes dos mesmos.' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 8:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">Seu carrinho de compras está vazio... <p>Voltar para <a href="Sistema.aspx">página inicial</a> ou escolha outros itens.</p>' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 9:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">Primeiramente você precisa <a href="~/Views/SistemaCadastrar.aspx">realizar o seu cadastro</a> antes de confirmar o pedido, só assim o fornecedor do item conseguirá entrar em contato com você.' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                case 10:
                    var $dialogAjuda = $(
                        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
                        '<div class="modal-dialog modal-m">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header"><h3>' + mensagem + '</3><button runat="server" onclick="fimCadastroDialog.hide();" type="button" class="close" data-dismiss="modal" >&times;</button></div>' +
                        '<div class="modal-body">Informe o e-mail e senha que você usou para se cadastrar no sistema, caso tenha alterardo sua senha faça login com a senha atual. E se esqueceu sua senha, não tem problema! <a href="~/Views/SistemaRecuperarSenha.apsx">Clique aqui</a> , vamos te ajudar a recuperá-la....' +
                        '<div class="modal-footer">' +
                        '</div></div>' +
                        '</div></div></div>');
                    break;
                default:
                    break;
            }
            // Assigning defaults
            if (typeof options === 'undefined') {
                options = {};
            }
            var settings = $.extend({
                dialogSize: 'm',
                progressType: '',
                onHide: null // This callback runs after the dialog was hidden
            }, options);

            // Configuring dialog
            $dialogAjuda.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
            $dialogAjuda.find('.progress-bar').attr('class', 'progress-bar');
            if (settings.progressType) {
                $dialogProgres.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
            }
            // Adding callbacks
            if (typeof settings.onHide === 'function') {
                $dialogAjuda.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                    settings.onHide.call($dialogProgres);
                });
            }
            // Opening dialog
            $dialogAjuda.modal();
        },
        /**
         * Closes dialog
         */
        hide: function () {
            $dialogAjuda.modal('hide');
        }
    };
})(jQuery);