var CriarViewModel = function (data) {
    var self = ko.mapping.fromJS(data);

    return self;
}