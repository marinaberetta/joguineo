$(document).ready(function(){
    carregaListagem();
});


function carregaListagem(){
    $('#aqui').html('');
    $.ajax({
        url: "http://localhost:8888/trabalhos/navarro/api.php", 
        method: "POST",
        data: {tipo: "get"}})
        .done(function(resp){
            var res = JSON.parse(resp);
            var html = "";
            res.forEach(function(el){
                html += '<ion-item class="item item-block item-ios"><div class="item-inner"><div class="input-wrapper">\
                            <ion-label class="label label-ios">\
                                <h2>'+el.nome+'</h2>\
                                <p>'+el.pontuacao+'</p>\
                            </ion-label>\
                        </div></div><div class="button-effect"></div></ion-item>';
            });
            $('#aqui').html(html);
        }
    );
}

function makePost(){
    var method = $('#selectMethod').find('.select-text').text();
    var nome = $('#nome').find('input');
    var pontuacao = $('#pontuacao').find('input');
    var senha = $('#senha').find('input');
    $.ajax({
        url: "http://localhost:8888/trabalhos/navarro/api.php", 
        method: "POST",
        data: {tipo: method, nome: nome.val(), senha: senha.val(), pontuacao: pontuacao.val()}})
        .done(function(resp){
            if(resp==="OK"){
                carregaListagem();
                nome.val('');
                pontuacao.val('');
                senha.val('');
            }
        }
    );
}

$('body').on('click', 'button[ion-button=alert-button]:nth-child(2)', function(){
    var method = $('#selectMethod').find('.select-text').text();
    var campo = $('#pontuacao').parent().parent().parent().parent();
    if(method=='DELETE'){
        campo.css('display', 'none');
    }else{
        campo.css('display', 'block');
    }
});