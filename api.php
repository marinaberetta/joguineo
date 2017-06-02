<?php
header("Access-Control-Allow-Origin: http://localhost:8100");
    

    //INSERT
    //$_POST = ["tipo"=>"insert","nome"=>"marina","senha"=>"a","pontuacao"=>100];
    //delete
    //$_POST = ["tipo"=>"delete","senha"=>"a","codigo"=>17];
    //get
    // $_POST = ["tipo"=>"get"];
    //edit
    //$_POST = ["tipo"=>"editar","codigo":1,"nova_pontuacao":2,"senha":"senha"];


    if($_POST['tipo']=="PUT") $_POST['tipo'] = "insert";
    if($_POST['tipo']=="UPDATE") $_POST['tipo'] = "editar";
    if($_POST['tipo']=="DELETE") $_POST['tipo'] = "delete";
    $mysqli = new mysqli("localhost", "root", "root", "allan");
    if ($mysqli->connect_errno) {
        printf("Connect failed: %s\n", $mysqli->connect_error);
        exit();
    }


    if($_POST['tipo']=="insert"){
        insert();
    }else if($_POST['tipo']=="editar"){
        update();
    }else if($_POST['tipo']=="delete"){
        delete();
    }else if($_POST['tipo']=="get"){
        getTop();
    }


function insert(){
    global $mysqli;
    $sql = "INSERT INTO pontuacao (nome,pontuacao,senha) VALUES('{$_POST['nome']}','{$_POST['pontuacao']}','{$_POST['senha']}'); ";
    if ($mysqli->query($sql) === TRUE) {
        echo "OK";
    }else{
        echo "NOK";
    }
}

function delete(){
    global $mysqli;
    $sql = "DELETE FROM pontuacao WHERE senha='{$_POST['senha']}' AND nome='{$_POST['nome']}'; ";
    if ($mysqli->query($sql) === TRUE) {
        echo "OK";
    }else{
        echo "NOK";
    }
}

function update(){
    global $mysqli;
    $sql = "UPDATE pontuacao SET pontuacao='{$_POST['pontuacao']}' WHERE senha='{$_POST['senha']}' AND nome='{$_POST['nome']}'; ";
    if ($mysqli->query($sql) === TRUE) {
        echo "OK";
    }else{
        echo "NOK";
    }
}

function getTop(){
    global $mysqli;
    $sql = "SELECT * FROM pontuacao order by PONTUACAO DESC limit 100";
    $a = $mysqli->query($sql);
    $todos = [];
    while($r=$a->fetch_assoc()){
        $todos[] = $r;
    }
    echo json_encode($todos);
}
