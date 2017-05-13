use unimarket
go
Excluir DetalheItemVendedor
go
create procedure DetalheItemVendedor(
	@IdItem int,
	@IdUsuario int
	)
as
begin
	select Item.Id, Item.Codigo, Item.Nome, Item.Descricao, Item.ValorUnitario, Item.Quantidade, Categoria.Id as IdCategoria,
	Categoria.Nome as NomeCategoria, Usuario.Id as IdUsuario from Item
	inner join Categoria on Categoria.Id = Item.IdCategoria
	inner join Usuario on Usuario.Id = Item.IdUsuario
	where (Item.Id = @IdItem) and (Item.IdUsuario = @IdUsuario) and (Item.Desabilitado = 0)
end