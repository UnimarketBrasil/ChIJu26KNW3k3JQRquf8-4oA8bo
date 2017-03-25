use UnimarketDB
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
create table Usuario(
	Id int Not null primary key identity(1,1),
	Email varchar(50) not null unique,
	Nome varchar(50) not null,
	Sobrenome varchar (50) null,
	Senha varchar(50) not null,
	CpfCnpj varchar(20) not null unique,
	Nascimento Date null,
	Genero smallint null,
	Telefone varchar(15) not null,
	Longitude bigint null,
	Latitude bigint null,
	Complemento varchar(50) null,
	AreaAtuacao real null check (AreaAtuacao > 0),
	IdTipoUsuario int foreign key references TipoUsuario(Id),
	IdStatusUsuario int foreign key references StatusUsuario(Id) default 2,
	DataCadastro dateTime not null default getdate()
)
go
create table SubUsuario(
	Id int not null primary key identity(1,1),
	Nome varchar(50) not null,
	Email varchar(50) not null,
	Senha varchar(50) not null,
	IdUsuario int foreign key references Usuario(Id),
	DataCadastro dateTime not null default getdate(),
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
	IdStatusPedido int not null foreign key references StatusPedido(Id) default 1,
	Data DateTime not null default getdate()
)
go
create table Item(
	Id int not null primary key identity(1,1),
	Codigo varchar(50) not null,
	Nome varchar(50) not null,
	Descricao varchar(255) not null,
	ValorUnitario real not null,
	Quantidade varchar(20) null check (Quantidade > -1),
	IdCategoria int foreign key references Categoria(Id),
	IdUsuario int not null foreign key references Usuario(Id),
	DataCadastro DateTime not null default getdate(),
	Desabilitado bit not null default 'false'
)
go
create table ItemPedido(
	Id int not null primary key identity(1,1),
	Quantidade int null, --Alterar nas procedures
	IdItem int not null foreign key references Item(Id),
	IdPedido int not null foreign key references Pedido(Id),
	Desabilitado bit not null default 'false'
)
go
insert into StatusPedido values ('Pendênte')
insert into StatusPedido values ('Finalizado')
insert into StatusPedido values ('Cancelado')
go
insert into StatusUsuario values ('Ativo')
insert into StatusUsuario values ('Pendênte')
insert into StatusUsuario values ('Bloqueado')
go
insert into TipoUsuario values ('Admin')
insert into TipoUsuario values ('Vendedor')
insert into TipoUsuario values ('Comprador')
go
insert into Categoria values ('Eletro')
insert into Categoria values ('Bebidas')
insert into Categoria values ('Hortifrúti')
insert into Categoria values ('HIgiene')
insert into Categoria values ('Limpeza')
insert into Categoria values ('Padaria e Confeitaria')
insert into Categoria values ('Açougue')
insert into Categoria values ('Infantil')
insert into Categoria values ('Casa e Decoração')
insert into Categoria values ('Esporte e Lazer')
insert into Categoria values ('Automotivos')
insert into Categoria values ('Alimentos')
insert into Categoria values ('Ferramentas')
insert into Categoria values ('Moda')
insert into Categoria values ('Saúde e Beleza')
insert into categoria values ('Pet')
insert into Categoria values ('Construção')
insert into Categoria values ('Artesanato')
insert into Categoria values ('Livros')
go