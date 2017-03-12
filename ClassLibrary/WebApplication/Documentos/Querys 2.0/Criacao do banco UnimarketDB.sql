use UnimarketDB
go
create table StatusUsuario(
	Id int Not null primary key identity(1,1),
	Nome varchar(50) not null
)
go
create table FuncaoPrincipal(
	Id int Not null primary key identity(1,1),
	Nome varchar(50) not null
)
go
create table Usuario(
	Id int Not null primary key identity(1,1),
	Email varchar(50) not null unique,
	Nome varchar(50) not null,
	Sobrenome varchar(50) not null,
	Senha varchar(50) Not null,
	CpfCnpj varchar(20) null unique,
	Nascimento Date null,
	Genero smallint null,
	Telefone varchar(15),
	Longitude bigint not null,
	Latitude bigint not null,
	Complemento varchar(255) null,
	AreaAtuacao real check (AreaAtuacao > 0),
	IdFuncaoPrincipal int foreign key references FuncaoPrincipal(Id),
	IdStatusUsuario int foreign key references StatusUsuario(Id) default 2,
	DataCadastro dateTime default getdate()
)
go
create table SubUsuario(
	Id int not null primary key identity(1,1),
	Nome varchar(50) not null,
	Sobrenome varchar (50) not null,
	Email varchar(50) not null,
	Senha varchar(50) not null,
	IdUsuario int foreign key references Usuario(Id),
	DataCadastro dateTime default getdate(),
	Desabilitado bit not null default 'false'
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
	IdStatusPedido int not null foreign key references StatusPedido(Id),
	Data DateTime not null default getdate()
)
go
create table Item(
	Id int not null primary key identity(1,1),
	Codigo varchar(50) not null,
	Nome varchar(50) not null,
	Descricao varchar(255) not null,
	ValorUnitario real not null,
	Quantidade varchar(20) null,
	IdCategoria int foreign key references Categoria(Id),
	IdUsuario int not null foreign key references Usuario(Id),
	DataCadastro DateTime not null default getdate(),
	Desabilitado bit not null default 'false'
)
go
create table ItemPedido(
	Id int not null primary key identity(1,1),
	Quantidade varchar(20) null,
	IdItem int not null foreign key references Item(Id),
	IdPedido int not null foreign key references Pedido(Id),
	Desabilitado bit not null default 'false'
)
go
insert into StatusPedido values ('Pend�nte')
insert into StatusPedido values ('Finalizado')
insert into StatusPedido values ('Cancelado')
go
insert into StatusUsuario values ('Ativo')
insert into StatusUsuario values ('Pend�nte')
insert into StatusUsuario values ('Bloqueado')
go
insert into FuncaoPrincipal values ('Admin')
insert into FuncaoPrincipal values ('Vendedor')
insert into FuncaoPrincipal values ('Comprador')
go
insert into Categoria values ('Eletro')
insert into Categoria values ('Bebidas')
insert into Categoria values ('Hortifr�ti')
insert into Categoria values ('HIgiene')
insert into Categoria values ('Limpeza')
insert into Categoria values ('Padaria e Confeitaria')
insert into Categoria values ('A�ougue')
insert into Categoria values ('Infantil')
insert into Categoria values ('Casa e Decora��o')
insert into Categoria values ('Esporte e Lazer')
insert into Categoria values ('Automotivos')
insert into Categoria values ('Alimentos')
insert into Categoria values ('Ferramentas')
insert into Categoria values ('Moda')
insert into Categoria values ('Sa�de e Beleza')
insert into categoria values ('Pet')
insert into Categoria values ('Constru��o')
insert into Categoria values ('Artesanato')
insert into Categoria values ('Livros')
go