use UnimarketDB
go
Excluir AtualizarItem
go
create procedure AtualizarItem(
	@IdItem int,
	@Codigo varchar(50),
	@Nome varchar(50),
	@Descricao text,
	@ValorUnitario real,
	@Quantidade varchar(50),
	@IdCategoria int
	)
as begin
	update Item set
	Codigo = @Codigo,
    Nome = @Nome,
	Descricao = @Descricao,
	ValorUnitario = @ValorUnitario,
	Quantidade = @Quantidade,
	Idcategoria = @IdCategoria
	where (Item.Id = @IdItem)
end