$(function ($) {
    $.ajaxSetup({
        async: false,
        cache: false,
        headers: {
            '__RequestVerificationToken': encodeURIComponent($('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val())
        },
        error: function (jqXHR) {
            if (jqXHR.status == 403) {
                window.location.reload();
            }
        }
    });
});

//#region Extensions
//Form
$.fn.updateValidation = function () {
    var form = this.closest("form").removeData("validator").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(form);
    return this;
};

$.fn.cleanValidation = function () {
    $(this).find(".field-validation-error").each(function () {
        $(this).removeClass("field-validation-error").addClass("field-validation-valid");
    });
    $(this).find(".input-validation-error").each(function () {
        $(this).removeClass("input-validation-error").addClass("valid");
    });
    $(this).find(".validation-summary-errors").each(function () {
        $(this).find("ul").empty();
        $(this).removeClass("validation-summary-errors").addClass("validation-summary-valid");
    });
    $(this).updateValidation();
};

$.fn.isValid = function (hasTabs) {
    var form = this.closest('form');
    if (hasTabs) {
        form.data("validator").settings.ignore = '.tab-pane';
    }
    if (form.valid()) {
        return true;
    } else {
        var located;
        var ctrl;
        $(form).find('.input-validation-error:visible').each(function (index, ictrl) {
            located = true;
            ctrl = ictrl;
            return false;
        });
        if (!located && hasTabs) {
            $(form).find('.input-validation-error:hidden').each(function (index, ictrl) {
                var tab = $(ictrl).closest('.tab-pane');
                $('.nav-tabs a[href="#' + tab.attr("id") + '"]').tab('show');
                ctrl = ictrl;
                return false;
            });
        }
        $('html, body').animate({ scrollTop: $(ctrl).offset().top - 75 }, 'slow');
        $(ctrl).focus();
        return false;
    }
};

$.fn.showRequiredFields = function () {
    var form = this.closest('form');
    $(form).find('.asterisk').each(function () { $(this).remove(); });
    $(form).find('input[type=text], input[type=checkbox], input[type=password], select, textarea').each(function () {
        var req = $(this).attr('data-val-required');
        if (req != undefined) {
            if ($(this).is('input[type=checkbox]')) {
                var span = $('span[data-valmsg-for="' + $(this).attr('name') + '"]');
                span.before('<span class="data-val-required asterisk"> (*) </span>');
            } else {
                var formId = '#' + form[0].id + ' ';
                var label = $(formId + 'label[for="' + $(this).attr('id') + '"]');
                var text = label.text();
                if (text.length > 0) {
                    label.append('<span class="data-val-required asterisk"> (*)</span>');
                }
            }
        }
    });
};

$.fn.serializeForm = function () {
    var form = this.closest("form");
    var data = form.serialize();
    $(form).find('input:disabled, select:disabled').each(function () { //, input[type="hidden"]
        var id = $(this).attr("id");
        var val = $(this).val();
        data += '&' + id + '=' + val;
    });
    return data;
};
//#endregion

//#region Defaults
//DataTables
$.extend($.fn.dataTable.defaults, {
    language: {

        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        }
    },
    "searching": false,
    "bServerSide": true,
    "bProcessing": true,
    "bAutoWidth": false,
    "dom": 'litp'
});

//PNotify
PNotify.prototype.options.delay = 3000; //4500
PNotify.prototype.options.opacity = 0.9;
PNotify.prototype.options.history.history = false;
//PNotify.prototype.options.confirm.buttons = [];
PNotify.prototype.options.mouse_reset = false;
//#endregion

//#region Custom
$('form:not(.skip) input').bind('keypress', function (e) {
    if (e.keyCode == 13) {
        return false;
    }
});

$('body').tooltip({
    title: function () {
        if ($(this).find("i.fa-search-plus").length) return "Mostrar";
        if ($(this).find("i.fa-search").length) return "Mostrar";
        if ($(this).find("i.fa-pencil").length) return "Editar";
        if ($(this).find("i.fa-trash-o").length) return "Eliminar";
        if ($(this).find("i.fa-folder-open").length) return "Abrir";
        if ($(this).find("i.fa-paperclip").length) return "Descargar";
        if ($(this).find("i.fa-upload").length) return "Adjuntar";
        if ($(this).find("i.fa-share").length) return "Enviar";
        if ($(this).find("i.fa-close").length) return "Cancelar";
        if ($(this).find("i.fa-times-circle").length) return "Cancelar";
        if ($(this).find("i.fa-plus-square").length) return "Agregar";
        if ($(this).find("i.fa-thumbs-o-down").length) return "Rechazar";
        if ($(this).find("i.fa-thumbs-o-up").length) return "Aceptar";
        if ($(this).find("i.fa-reply").length) return "Recuperar";
        return $(this).attr("title") == "" || $(this).attr("title") == undefined ? false : $(this).attr("title");
    },
    placement: function () {
        if ($(this).attr("data-placement") != "" && $(this).attr("data-placement") != undefined)
            return $(this).attr("data-placement");
        return 'right';
    },
    selector: 'a:not(.no-tooltip):has(i.fa-search-plus), a:not(.no-tooltip):has(i.fa-search), a:not(.no-tooltip):has(i.fa-pencil), a:not(.no-tooltip):has(i.fa-trash-o), a:not(.no-tooltip):has(i.fa-folder-open), a:not(.no-tooltip):has(i.fa-paperclip), a:not(.no-tooltip):has(i.fa-upload), a:not(.no-tooltip):has(i.fa-credit-card), a:not(.no-tooltip):has(i.fa-share), a:not(.no-tooltip):has(i.fa-close), a:not(.no-tooltip):has(i.fa-plus-square), a:not(.no-tooltip):has(i.fa-times-circle), a:not(.no-tooltip):has(i.fa-thumbs-o-down), a:not(.no-tooltip):has(i.fa-thumbs-o-up), a:not(.no-tooltip):has(i.fa-reply),a:not(.no-tooltip):has(i.fa-camera)'
});

function notify(data) {
    PNotify.removeAll();
    new PNotify({
        title: data.Title,
        text: data.Message,
        type: data.Type,
        width: data.Width
    });
};

function ask(text, width) {
    text = text === undefined ? '¿Está seguro(a) que desea eliminar el registro?' : text;
    width = width === undefined ? '400px' : width;
    var deferred = $.Deferred();
    var promise = deferred.promise();
    new PNotify({
        title: 'Confirmación',
        text: text,
        icon: 'glyphicon glyphicon-question-sign',
        width: width,
        hide: false,
        confirm: {
            confirm: true,
            buttons: [{
                text: 'Aceptar'
            }, {
                text: 'Cancelar',
            }]
        },
        buttons: {
            closer: false,
            sticker: false
        },
        history: {
            history: false
        },
        addclass: 'stack-modal',
        stack: {'dir1': 'down', 'dir2': 'right', 'modal': true}
    }).get().on('pnotify.confirm', function (notice) {
        deferred.resolve({ notice: notice });
    }).on('pnotify.cancel', function (notice) {
        deferred.reject();
    });
    return promise;
}
//#endregion