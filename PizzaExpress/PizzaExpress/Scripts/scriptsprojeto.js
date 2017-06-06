$(document).ready(function () {
    $("input[name='ObjPizza.Sabores[0].NomeSabor'").autocomplete({
        source: function (request, response) {
            $.ajax({
                async: true,
                url: "/Pedido/BuscarSabor",
                type: "POST",
                dataType:"json",
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
            noResults: "Não foi Encontrado", results: function (count) {
                return count + (count === 0 ? ' result' : ' results');
            }
        }
    });
})
$(document).ready(function () {
    $("input[name='ObjPizza.Sabores[1].NomeSabor'").autocomplete({
        source: function (request, response) {
            $.ajax({
                async: true,
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
            noResults: "", results: function (count) {
                return count + (count === 0 ? ' result' : ' results');
            }
        }

    });
})

$(document).ready(function () {
    $("input[name='ObjPizza.Sabores[2].NomeSabor'").autocomplete({
        source: function (request, response) {
            $.ajax({
                async: true,
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
            noResults: "", results: function (count) {
                return count + (count === 0 ? ' result' : ' results');
            }
        }
    });
})
$(document).ready(function () {
    $("input[name='ObjProduto.NomeProduto']").autocomplete({
        source: function (request, response) {
            $.ajax({
                async: true,
                url: "/Pedido/BuscarProduto",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {

                        return { label: item.Label, value: item.Name, Id: item.Value, Descricao: item.Descricao, PrecoProduto: item.PrecoProduto };
                    }))

                }
            })
        },
        select: function (e, ui) {
            $("input[name='ObjProduto.IdProduto']").val(ui.item.Id);
    




        },
        messages: {
            noResults: "", results: function (count) {
                return count + (count === 0 ? ' result' : ' results');
            }
        }
    });
})
$(document).ready(function () {
    $("input[name='ObjCliente.NomeCliente']").autocomplete({
        source: function (request, response) {
            $.ajax({
                async: true,
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
            noResults: "", result: function (count) {
                return count + (count === 0 ? ' result' : ' results');
            }
        }
    });
})
var isFirefox = typeof InstallTrigger !== 'undefined';
if (isFirefox) {
    $(document).ready(function () {
        $("#DataPedido").datepicker({
            dateFormat: 'dd/mm/yy'
        })
    })
}