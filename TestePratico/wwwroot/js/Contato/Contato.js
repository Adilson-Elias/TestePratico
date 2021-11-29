
$(function () {
    var contato = new Contato();

    $('#btnAdicionar').on('click', contato.Adicionar);
})


var lista = [];

var Contato = function ()
{
    this.Adicionar = function () {

        var Nome = $('#txtNome').val();
        var TelefoneRes = $('#txtTelRes').val();
        var Celular = $('#txtCelular').val();

        Ajax.post(`../Contato/InsertOrUpdateContato`, { ID: 0, Nome: Nome, TelefoneResidencial: TelefoneRes, TelefoneCelular: Celular },
            (response) => {
                alert("Registro inserido");
            },
            (response) => { });
    }

    this.CarregarGrid = function (list) {

    }

    this.RemoverContato = function (codigo) {

        Ajax.post(`../Contato/DeleteContato`, codigo,
            (response) => {
                alert("Registro excluído");
            },
            (response) => { });
    }
}

Ajax = {
    post: function (url, model, callBackSuccess, callBackError) {
        $('.c-loader-overlay').css('display', 'flex');
        var $divAlertMessage = $("#divAlertMessage");
        $divAlertMessage.addClass("ag-d-none");

        $.ajax({
            url: url,
            type: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            data: JSON.stringify(model),
            success: function (data) {
                var $divDescricaoAlert = $("#divDescricaoAlert");

                $divAlertMessage.removeClass("ag-d-none");

                if (data.sucesso) {
                    $("#errorTitulo").html("<span>Cadastro editado com sucesso!</span>")
                }
                else {
                    var notificacoes = data.notificacoes;
                    if (notificacoes) {
                        if (notificacoes.length == 1) {
                            $("#errorTitulo").html(notificacoes[0].value)
                        } else {
                            $("#errorTitulo").html("Falhas ao salvar")
                            var html = "";
                            html += "<ul>";

                            for (var i = 0; i < notificacoes.length; i++) {
                                var notificacao = notificacoes[i];
                                html += "<li><span>" + notificacao.value + "</span></li>";
                            }

                            html += "</ul>";
                            $divDescricaoAlert.show();
                            $divDescricaoAlert.html(html);
                        }

                    }
                }

                if (callBackSuccess !== "" && callBackSuccess !== null) {
                    $('.c-loader-overlay').css('display', 'none');
                    callBackSuccess(data)

                }

            },
            error: function (error) {
                if (callBackError !== "" && callBackError !== null) {
                    $('.c-loader-overlay').css('display', 'none');
                    callBackError(error);

                }
            }
        });
    },

    delete: function (url, model, callBackSuccess, callBackError) {
        $('.c-loader-overlay').css('display', 'flex');
        var $divAlertMessage = $("#divAlertMessage");
        $divAlertMessage.addClass("ag-d-none"); $.ajax({
            url: url,
            type: 'DELETE',
            headers: {
                "Content-Type": "application/json"
            },
            data: JSON.stringify(model),
            success: function (data) {
                var $divDescricaoAlert = $("#divDescricaoAlert");

                $divAlertMessage.removeClass("ag-d-none");

                if (data.sucesso) {
                    $("#errorTitulo").html("<span>Cadastro editado com sucesso!</span>")
                }
                else {
                    var notificacoes = data.notificacoes;
                    if (notificacoes) {
                        if (notificacoes.length == 1) {
                            $("#errorTitulo").html(notificacoes[0].value)
                        } else {
                            $("#errorTitulo").html("Falhas ao salvar")
                            var html = "";
                            html += "<ul>";

                            for (var i = 0; i < notificacoes.length; i++) {
                                var notificacao = notificacoes[i];
                                html += "<li><span>" + notificacao.value + "</span></li>";
                            }

                            html += "</ul>";
                            $divDescricaoAlert.show();
                            $divDescricaoAlert.html(html);
                        }

                    }
                }

                if (callBackSuccess !== "" && callBackSuccess !== null) {
                    $('.c-loader-overlay').css('display', 'none');
                    callBackSuccess(data)

                }

            },
            error: function (error) {
                if (callBackError !== "" && callBackError !== null) {
                    $('.c-loader-overlay').css('display', 'none');
                    callBackError(error);

                }
            }
        });
    },
    get: function (url, callBackSuccess, callBackError) {
        $('.c-loader-overlay').css('display', 'flex');
        $.ajax({
            url: url,
            type: 'GET',
            success: function (data, status, response) {
                Util.Ajax.notificacoes(data);
                if (callBackSuccess !== "" && callBackSuccess !== null) {
                    $('.c-loader-overlay').css('display', 'none');
                    callBackSuccess(data, status, response);

                }
            },
            error: function (error) {
                if (callBackError !== "" && callBackError !== null) {
                    $('.c-loader-overlay').css('display', 'none');
                    callBackError(error);

                }
            }
        });
    },
    notificacoes: function (data) {
        if (data.notificacoes) {
           
        }
    }
};

