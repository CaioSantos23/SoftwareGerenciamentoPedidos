create database tcc;
use tcc;
CREATE TABLE CadastrarCliente(
    codcli INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR (60),
    end VARCHAR (60),
    bairro VARCHAR (60),
    num int,
    complemento VARCHAR (30),
    tel VARCHAR (30),
    PRIMARY KEY (codcli)
);
CREATE TABLE CadastrarPedido(
    codped INT NOT NULL AUTO_INCREMENT,
    comanda VARCHAR (60),
    nome VARCHAR (60),
    produto VARCHAR (60),
    preco DECIMAL (10,2),
    categoria VARCHAR (60),
    PRIMARY KEY (codped)
);
CREATE TABLE CadastrarCaixa(
    codcaixa INT NOT NULL AUTO_INCREMENT,
    valor DECIMAL (10,2),
    dat VARCHAR (60),
    obs VARCHAR (60),
    PRIMARY KEY (codcaixa) 
);
CREATE TABLE CadastrarProduto(
    codprod INT NOT NULL AUTO_INCREMENT,
    codper INT,
    produto VARCHAR (30),
    preco DECIMAL (10,2),
    categoria VARCHAR (30),
    PRIMARY KEY (codped)
);
