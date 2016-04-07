var validacaoGenerica = {
    campoObrigatorio: function (c) { return "Preencha o campo " + c + "."; },
    minimoObrigatorio: function (c, q) { return "Preencha " + c + " com no mínimo " + q + " caracteres."; },
    maximoPermitido: function (c, q) { return "O campo " + c + " aceita no máximo " + q + " caracteres."; },
    registrosNaoEncontrados: function () { return "Não foram encontrados registros que atendam às condições estabelecidas."; }
};