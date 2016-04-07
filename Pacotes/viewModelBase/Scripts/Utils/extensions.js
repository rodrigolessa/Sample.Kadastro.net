var app = {

    config: {
        urlTeste: 'teste'
    },

    get: function (url, data, executarSeSucesso) {
        $.getJSON(url, data, function (allData, strStatus, xhr) {
            if (strStatus == "success")
                executarSeSucesso(allData);
        });
    },

    post: function (url, data, executarSeSucesso) {
        $.ajax(url, {
            data: ko.toJSON(data)
            , type: 'POST'
            , contentType: "application/json"
            , async: true
            , success: function (allData) {
                executarSeSucesso(allData);
            } //TODO: Comentar para produção
            , error: function (jqXHR, exception) {
                alert('Informe o erro: ' + jqXHR.status);
            }
        });
    },

    put: function (url, data, executarSeSucesso) {
        $.ajax(url, {
            data: ko.toJSON(data)
            , type: 'PUT'
            , contentType: "application/json"
            , async: true
            , success: function (allData) {
                executarSeSucesso(allData);
            } //TODO: Comentar para produção
            , error: function (jqXHR, exception) {
                alert('Informe o erro: ' + jqXHR.status);
            }
        });
    },

    delete: function (url, data, executarSeSucesso) {
        $.ajax(url, {
            data: ko.toJSON(data)
            , type: 'DELETE'
            , contentType: "application/json"
            , async: true
            , success: function (allData) {
                executarSeSucesso(allData);
            } //TODO: Comentar para produção
            , error: function (jqXHR, exception) {
                alert('Informe o erro: ' + jqXHR.status);
            }
        });
    },

    toTop: function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
    },

};