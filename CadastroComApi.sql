create database cadastrocomapi;

use cadastrocomapi;

create table Usuarios(
id int not null auto_increment primary key,
email varchar(40) not null,
senha varchar(40) not null
);

create table Colaboradores (
id int not null auto_increment primary key,
NomeCompleto varchar(40),
Idade int not null,
EstadoCivil varchar(40) not null,
Cep varchar(40) not null,
Logradouro varchar(80) not null,
Bairro varchar(80) not null,
Localidade varchar(80) not null,
Uf varchar(12) not null,
Ddd varchar(5) not null,
UsuarioId int not null,
foreign key (UsuarioId) references Usuarios (id)
);

/* Esta trigger remove os registros da tabela colaborador de forma automatica, toda vez que uma conta for excluida */
Delimiter $$
	create trigger ExcluirColaborador before delete
	on usuarios
	for each row
	Begin
		delete from Colaboradores where UsuarioId = old.id;
	End $$
Delimiter ;