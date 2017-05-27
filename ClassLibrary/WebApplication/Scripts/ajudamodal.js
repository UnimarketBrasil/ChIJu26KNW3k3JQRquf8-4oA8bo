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
                            '<div class="modal-body">Falta pouco! Confirme seu cadastro para começar a usar o UNIMARKET.' +
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
                            '<div class="modal-body">O administrador do sistema bloqueou sua conta devido o mau uso do sistema.' +
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