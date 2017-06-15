use unimarket
if OBJECT_ID('DetalheItem') is not null
drop procedure DetalheItem
go
create procedure DetalheItem(
	@IdItem int
	)
as	
begin
	select Item.Id, Item.Codigo, Item.Nome, Item.ValorUnitario, Item.Quantidade, Item.Descricao,
	Categoria.Nome as Categoria, Usuario.Id as IdVendedor,  Usuario.Nome as Vendedor, Usuario.Latitude, Usuario.Longitude, Usuario.Telefone,
	Usuario.Email from Item
	inner join Usuario on (Item.IdUsuario = Usuario.Id)
	inner join Categoria on (Item.IdCategoria = Categoria.Id)
	where (Item.Id = @IdItem)
end