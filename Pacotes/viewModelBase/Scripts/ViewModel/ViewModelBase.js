// Funções base para ViewModel
/////////////////////////////////////////
var ViewModelBase = function (data) {

    var self = ko.mapping.fromJS(data);

    // Propriedades
    /////////////////////////////////////////
    self.HasSuccess = ko.observable(false);
    self.Mensagens = ko.observableArray([]);
    self.listaDeLogs = ko.observableArray([]);

    // Métodos
    /////////////////////////////////////////
    self.exibirMensagem = function (sucesso, mensagem) {
        self.HasSuccess(sucesso);
        self.Mensagens.push(mensagem);
    } // self.exibirMensagem

    self.LimparMensagem = function () {
        self.HasSuccess(true);
        self.Mensagens.removeAll();
    } // self.exibirMensagemUnica

    self.exibirMensagemRegistrosNaoEncontrados = function () {
        self.exibirMensagem(false, validacaoGenerica.registrosNaoEncontrados());
    } // self.exibirMensagemRegistrosNaoEncontrados

    self.businessResponse = function (data) {
        self.HasSuccess(data.Response);
        self.Mensagens(data.Messages);
    } // self.businessResponse

    return self;
}