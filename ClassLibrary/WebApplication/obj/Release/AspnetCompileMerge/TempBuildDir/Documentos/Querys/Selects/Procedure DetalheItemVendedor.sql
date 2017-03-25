use UnimarketDB
go
Excluir DetalheItemVendedor
go
create procedure DetalheItemVendedor(
	@IdItem int
	)
as
begin
	select Item.Codigo, Item.Nome, Item.Descricao, Item.ValorUnitario, Item.Quantidade, Categoria.Nome from Item
	inner join Categoria on Categoria.Id = Item.IdCategoria
	where (Item.Id = @IdItem)
end