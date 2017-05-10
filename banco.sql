create database navarro;
use navarro;
create table pontuacao(
`codigo` int(12) not null auto_increment,
`nome` varchar(45) not null,
`pontuacao` int(12) not null,
`senha` varchar(45) not null,
primary key(`codigo`)
);