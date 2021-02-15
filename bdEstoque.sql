drop database bdEstoque;
create database bdEstoque;
use bdEstoque;

create table tblpessoas (
	pesid int(11) not null primary key auto_increment,
    pesnome varchar(50) not null,
    pesemail varchar(300) not null,
    pestelefonefixo varchar(15) not null,
    pestelefonecelular varchar(15) not null
);

insert into tblpessoas (pesnome, pesemail, pestelefonefixo, pestelefonecelular) values ("Luan", "luan.queiroz@gmail.com", "(19)99523-0386", "(19)99523-0386");

create table tblusuarios (
	pesid int(11) not null primary key,
    usrnome varchar(10) not null,
    usrsenha varchar(300) not null
);

insert into tblusuarios (pesid, usrnome, usrsenha) values (1, "Luan", "senha");

create table tblprodutos (
	prodid int(11) not null primary key auto_increment,
    prodnome varchar(100) not null,
    prodqtde double(12,2) not null default 0.00,
    prodpreco decimal(12,2) not null default 0.00
);

create table tblmomvprodutos(
	mvpid int(11) not null primary key auto_increment,
    prodid int(11)not null,
    mvpdata date not null,
    mvptipomov varchar(1) not null default 'E',
    mvpqtde double(12,2) not null default 0.00
);