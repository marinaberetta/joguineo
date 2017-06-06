api_url = "http://localhost/allan/api.php"

$(document).ready(function(){
    carregaListagem();
});

function carregaListagem(){
    $('#aqui').html('');
    $.ajax({
        url: api_url, 
        method: "POST",
        data: {tipo: "get"}})
        .done(function(resp){
            var res = JSON.parse(resp);
            var html = "";
            res.forEach(function(el){
                html += '<ion-item class="item item-block item-ios excluirItem" data-nome="'+el.nome+'">\
                            <div class="item-inner"><div class="input-wrapper">\
                                <ion-label class="label label-ios">\
                                    <h2>'+el.nome+'</h2>\
                                    <p>'+el.pontuacao+'</p>\
                                </ion-label>\
                            </div></div><div class="button-effect"></div>\
                        </ion-item>';
            });
            $('#aqui').html(html);
        }
    );
}

function makePost(dados){
    $.ajax({
        url: api_url, 
        method: "POST",
        data: dados
    }).done(function(resp){
        if(resp==="OK"){
            carregaListagem();
        }
    });
}

$('body').on('click', '.excluirItem', function(){
    nome = $(this).data('nome')
    $('#excluirNome').val(nome)
    $('.alert-sub-title').html('Usuário: '+nome)
});

$('body').on('click', 'button[ng-reflect-ng-class=excluirBtn]', function(){
    excluirPontuacao();
});

function excluirPontuacao(){
    pass = $('#excluirPass').val()
    nome = $('#excluirNome').val()
    dados = {tipo: 'delete', nome: nome, senha: pass}
    makePost(dados);
}

$('body').on('keydown', 'input[id=excluirPass]', function(e){
    var key = e.keyCode
    if(key==13){
        excluirPontuacao();
    }
});
