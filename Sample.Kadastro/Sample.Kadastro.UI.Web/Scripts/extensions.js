function doAjx(action, data, refresh) {
    jQuery.ajax({
        url: action,
        type: "post",
        data: ko.toJSON(data),
        contentType: "application/json",
        success: function (result) { refresh(result) }
    });
}

function doBlockUI() {
    // Ativando bloqueio de tela
    /////////////////////////////////////////
    $.blockUI({
        message: 'Processando...<br /><img src="img/ajax-loader.gif" border="0">', // Refatorar para remover HTML
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
    });

    // Desativando bloqueio por tempo (segurança se algum método não tiver retorno)
    setTimeout($.unblockUI, 15000);
}