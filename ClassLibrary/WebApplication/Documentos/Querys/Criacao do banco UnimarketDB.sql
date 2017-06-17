use unimarket
go
create table StatusUsuario(
	Id int Not null primary key identity(1,1),
	Nome varchar(50) not null
)
go
create table TipoUsuario(
	Id int Not null primary key identity(1,1),
	Nome varchar(50) not null
)
go
create table TipoMetodosPagamento(
	Id int Not null primary key identity(1,1),
	Nome varchar(50) not null
)
go
create table MetodosPagamento(
	Id int Not null primary key identity(1,1),
	IdTipoMetodo int foreign key references TipoMetodosPagamento(Id),
	Nome varchar(50) not null
)
go
create table Usuario( 
	Id int Not null primary key identity(1,1),
	Email varchar(50) not null unique,
	Nome varchar(50) not null,
	Sobrenome varchar (50) null,
	Senha varchar(50) not null,
	HashConfirmacao varchar(50) not null,
	HashNovaSenha varchar(50) null,
	CpfCnpj varchar(20) not null unique,
	Genero smallint null,
	Telefone varchar(15) not null,
	Longitude float,
	Latitude float,
	CEP varchar(8) not null,
	Numero int not null,
	Complemento varchar(50) null,
	AreaAtuacao real null check (AreaAtuacao > 0),
	IdTipoUsuario int foreign key references TipoUsuario(Id),
	IdStatusUsuario int foreign key references StatusUsuario(Id) default 2,
	DataCadastro dateTime not null default getdate(),
	UltimoAcesso DateTime not null
)
go
create table MetodosPagamentoUsuario(
	IdMetodo int not null foreign key references MetodosPagamento(Id),
	IdVendedor int not null foreign key references Usuario(Id),
	Desabilitado bit not null
)
go
create table StatusPedido(
	Id int Not null primary key identity(1,1),
	Nome varchar(50) not null
)
go
create table Categoria(
	Id int Not null primary key identity(1,1),
	Nome varchar(50) not null
)
go
create table Pedido(
	Id int not null primary key identity(1,1),
	Codigo varchar(50) not null,
	IdVendedor int not null foreign key references Usuario(Id),
	IdComprador int not null foreign key references Usuario(Id),
	IdStatusPedido int not null foreign key references StatusPedido(Id) default 1,
	Data DateTime not null default getdate(),
	DateFinalizadoOuCancelado DateTime null
)
go
create table Item(
	Id int not null primary key identity(1,1),
	Codigo varchar(50) not null,
	Nome varchar(50) not null,
	Descricao varchar(255) not null,
	ValorUnitario real not null,
	Quantidade real null check (Quantidade > -1),
	IdCategoria int foreign key references Categoria(Id),
	IdUsuario int not null foreign key references Usuario(Id),
	DataCadastro DateTime not null default getdate(),
	Desabilitado bit not null default 'false'
)
go
create table ItemPedido(
	Id int not null primary key identity(1,1),
	Quantidade real null,
	ValorUnitario real not null,
	IdItem int not null foreign key references Item(Id),
	IdPedido int not null foreign key references Pedido(Id),
	Desabilitado bit not null default 'false'
)
go
insert into StatusPedido values ('Pendente')
insert into StatusPedido values ('Finalizado')
insert into StatusPedido values ('Cancelado')
go
insert into StatusUsuario values ('Ativo')--1
insert into StatusUsuario values ('Pendente')--2
insert into StatusUsuario values ('Bloqueado')--3
insert into StatusUsuario values ('Desabilitado')--4
insert into StatusUsuario values ('1° Acesso comprador')--5
insert into StatusUsuario values ('1° Acesso vendedor')--6
go
insert into TipoUsuario values ('Admin')
insert into TipoUsuario values ('Comprador')
insert into TipoUsuario values ('Vendedor')
go
insert into TipoMetodosPagamento values ('À vista')
insert into TipoMetodosPagamento values ('Débito')
insert into TipoMetodosPagamento values ('Crédito')
go
insert into MetodosPagamento values (1,'Dinheiro')
insert into MetodosPagamento values (2,'Elo')
insert into MetodosPagamento values (2,'MasterCard')
insert into MetodosPagamento values (2,'Visa')
insert into MetodosPagamento values (2,'HiperCard')
insert into MetodosPagamento values (2,'Diners')
insert into MetodosPagamento values (3,'Elo')
insert into MetodosPagamento values (3,'MasterCard')
insert into MetodosPagamento values (3,'Visa')
insert into MetodosPagamento values (3,'HiperCard')
insert into MetodosPagamento values (3,'Diners')
go
insert into Categoria values ('Eletrônicos')
insert into Categoria values ('Informática')
insert into Categoria values ('Bebidas')
insert into Categoria values ('Higiene')
insert into Categoria values ('Limpeza')
insert into Categoria values ('Confeitaria')
insert into Categoria values ('Açougue')
insert into Categoria values ('Infantil')
insert into Categoria values ('Casa e Decoração')
insert into Categoria values ('Esporte e Lazer')
insert into Categoria values ('Automotivos')
insert into Categoria values ('Alimentos')
insert into Categoria values ('Moda')
insert into Categoria values ('Saúde e Beleza')
insert into categoria values ('Pet')
insert into Categoria values ('Construção')
insert into Categoria values ('Artesanato')
insert into Categoria values ('Livros')
insert into Categoria values ('Serviços')
go