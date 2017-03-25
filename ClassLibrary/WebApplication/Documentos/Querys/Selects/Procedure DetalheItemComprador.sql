use unimarket
go
Excluir DetalheItemComprador
go
create procedure DetalheItemComprador(
	@IdItem int
	)
as
begin
	select Item.Nome, Item.Descricao, Item.ValorUnitario, Item.Quantidade, Categoria.Nome, Administrador.Nome from Item
	inner join Categoria on Categoria.Id = Item.IdCategoria
	inner join Adminstrador on Administrador.Id = Item.IdUsuario
	where (Item.Id = @IdItem)
end