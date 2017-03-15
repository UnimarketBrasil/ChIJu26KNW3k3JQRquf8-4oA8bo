use UnimarketDB
go
Excluir CadastrarItem
go
create procedure CadastrarItem(
	@Codigo varchar(50),
	@Nome varchar(50),
	@Descricao text,
	@ValorUnitario real,
	@Quantidade varchar(50),
	@IdCategoria int,
	@IdUsuario int
	)
as begin
	insert into Item (
	Codigo,
    Nome,
	Descricao,
	ValorUnitario,
	Quantidade,
	IdCategoria,
	IdUsuario
	) 
	values (
	@Codigo,
    @Nome,
	@Descricao,
	@ValorUnitario,
	@Quantidade,
	@IdCategoria,
	@IdUsuario
	)
end
