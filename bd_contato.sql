USE bd_contato;

CREATE TABLE contato(
id int identity not null primary key,
nome varchar(200) not null,
telefone_residencial varchar(14) not null,
telefone_celular varchar(14) not null
);

