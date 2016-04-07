
var modalDeExclusaoDTO = function (m) {

	var dto = this;

	$('body').append('<div id="janela' + m + '" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="Janela de Confirmacao para Exclusao" aria-hidden="true" data-backdrop="static"><div class="modal-dialog modal-sm"><div class="modal-content"><div class="modal-header"><h4 class="modal-title no-padding">Tem certeza que deseja realizar a ação?</h4></div><div class="modal-footer"><button type="button" data-dismiss="modal" title="Não" class="btn btn-cancel">Não</button><button type="button" data-dismiss="modal" title="Sim" class="btn btn-primary" data-bind="click: $root.' + m + '.confirma">Sim</button></div></div></div></div>');

	dto.texto = ko.observable('Tem certeza que deseja realizar a ação?');
	dto.item = ko.observable({});

	dto.abrir = function (d) {
		dto.item = d;
		var j = $('#janela' + m);
		var t = dto.texto();

		if (t.indexOf('{') >= 0)
			$.each(dto.item, function (a, b) {
				t = t.replace('{ ' + a + ' }', b);
			});

		j.modal('show');
		j.find('.modal-title').text(t);
	}

	dto.fechar = function () {
		$('#janela' + m).modal('hide');
	}
}