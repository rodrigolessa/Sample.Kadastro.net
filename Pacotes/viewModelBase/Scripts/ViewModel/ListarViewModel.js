// Funções genéricas para view de listagem simples
/////////////////////////////////////////
var ListarViewModel = function (d) {

    var s = new ViewModelBase(d);

    s.lista = ko.observableArray([]);
    s.criar = function (x) { window.location = config.urlCriar + "/" + eval("x." + config.codigo); }

    app.get(config.urlAPI, {}, function (r) {
        s.lista(r);
        if (s.lista().length == 0) s.exibirMensagemRegistrosNaoEncontrados();
    });

    return s;
}