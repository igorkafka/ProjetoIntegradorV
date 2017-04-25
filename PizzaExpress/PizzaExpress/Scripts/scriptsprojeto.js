$(document).ready(function () {
    $("input[name='ObjPizza.Sabores[0].NomeSabor'").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Pedido/BuscarSabor",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        
                        return { label: item.Label, value: item.Name, Id: item.Value };
                    }))

                }
            })
        },
        select: function (event, ui) {
            $("input[name='ObjPizza.Sabores[0].IdSabor'").val(ui.item.Id);

        },
        messages: {
            noResults: "Não foi Encontrado", results: ""
        }
    });
})
$(document).ready(function () {
    $("input[name='ObjPizza.Sabores[1].NomeSabor'").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Pedido/BuscarSabor",
                type: "POST",

                dataType: "json",

                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        $("input[name='ObjPizza.Sabores[1].IdSabor'").val(item.Value);
                        return { label: item.Label, value: item.Name, Id: item.Value };
                    }))

                },


            })
        },
        select: function (event, ui) {
            $("input[name='ObjPizza.Sabores[1].IdSabor'").val(ui.item.Id);

        },
        messages: {
            noResults: "", results: ""
        }

    });
})

$(document).ready(function () {
    $("input[name='ObjPizza.Sabores[2].NomeSabor'").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Pedido/BuscarSabor",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Label, value: item.Name, Id: item.Value };
                    }))

                }
            })
        },
        select: function (e, ui) {
            $("input[name='ObjPizza.Sabores[2].IdSabor'").val(ui.item.Id);



        },
        messages: {
            noResults: "", results: ""
        }
    });
})
$(document).ready(function () {
    $("input[name='ObjProduto.NomeProduto']").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Pedido/BuscarProduto",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {

                        return { label: item.Label, value: item.Name, Id: item.Value };
                    }))

                }
            })
        },
        select: function (e, ui) {
            $("input[name='ObjProduto.IdProduto']").val(ui.item.Id);




        },
        messages: {
            noResults: "", results: ""
        }
    });
})
$(document).ready(function () {
    $("input[name='ObjCliente.NomeCliente']").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Pedido/BuscarCliente",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {

                        return { label: item.Label, value: item.Name, Id: item.Value };
                    }))

                }
            })
        },
        select: function (e, ui) {
            $("input[name='ObjCliente.IdCliente']").val(ui.item.Id);




        },
        messages: {
            noResults: "", results: ""
        }
    });
})
$(document).ready(function () { $("#DataPedido").datetimepicker(); });
var helloApp = angular.module("helloApp", []);
helloApp.controller("PizzaCtrl", function ($scope) {
    $scope.pizzas = [{ 'PrecoPizza': 0, 'Tamanho': '', 'Sabor1': '', 'Sabor2': '', 'Sabor3': '', 'Status': '', 'IdSabor1': 0, 'IdSabor2': 0, 'IdSabor3': 0 }];
    $scope.pizzas.splice(0);
    $scope.addRow = function () {
         

        $scope.pizzas.push({ 'PrecoPizza': $scope.PrecoPizza, 'Tamanho': $scope.Tamanho, 'Sabor1': $scope.Sabor1, 'Sabor2': $scope.Sabor2, 'Sabor3': $scope.Sabor3, 'Status': $scope.Status, 'IdSabor1': $scope.IdSabor1, 'IdSabor2': $scope.IdSabor2, 'IdSabor3': $scope.IdSabor3 });
        $scope.PrecoPizza = '';
        $scope.Tamanho = '';
        $scope.Sabor1 = '';
        $scope.Sabor2 = '';
        $scope.Sabor3 = '';
        $scope.Status = '';
        $scope.IdSabor1 = '';
        $scope.IdSabor2 = '';
        $scope.IdSabor3 = '';
        $("input[name='Pizzas[0].Status']").alert(this.val);
    }
    $scope.remove = function (item) {
        var index = $scope.pizzas.indexOf(item);
        $scope.pizzas.splice(index, 1);
    }
});
  