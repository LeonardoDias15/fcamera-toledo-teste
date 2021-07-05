
jQuery(document).ready(function ($) {
    $('#CPF').mask('000.000.000-00');
    $('#DataNascimento').mask('00/00/0000');
    $('#Cep').mask('00000-000');

    buscarFuncionarios();
});

function buscarAniversariantes() {

    var mes = $("#mes").val();

    $.ajax({
        url: " Aniversariante/ListagemAniversariantes?mes=" + mes,
        type: 'get',
        success: function (response) {
            $("#partialAniversariantes").html(response);
        }
    });
}

function buscarFuncionarios() {

    var filtroDTO = new Object();

    var nome = $("#nome").val();
    var sexo = $("#sexo").val();
    var ativo = $("#ativo").val();
    var naoPossuemDependencias = $("#naoPossuemDependencias").val();

    if (nome) {
        filtroDTO.Nome = nome;
    }

    if (sexo && sexo != 'ambos') {
        filtroDTO.Sexo = sexo;
    }

    if (ativo && ativo != 'ambos') {
        filtroDTO.Ativo = ativo == '1' ? true : false;
    }

    if (naoPossuemDependencias) {
        filtroDTO.ExibirNaoDependentes = naoPossuemDependencias == '1' ? true : false;
    }

    $.ajax({
        url: "Funcionario/ListagemFuncionarios",
        type: 'POST',
        data: filtroDTO,
        success: function (response) {
            $("#partialListagemFuncionarios").html(response);
        }
    });
}

function buscarCep(cep) {

    if (cep) {
        cep = cep.replace('-', '');

        if (cep.length == 8) {
            $.ajax({
                url: "https://viacep.com.br/ws/" + cep + "/json/",
                type: 'GET',
                success: function (response) {
                    preencherEndereco(response);
                }
            });
        }
    }
}

function preencherEndereco(data) {
    if (data) {
        $("#Endereco").val(data.logradouro);
        $("#Bairro").val(data.bairro);
        $("#Cidade").val(data.localidade);
        $("#Estado").val(data.uf);

        $("#Numero").focus();
    }
}