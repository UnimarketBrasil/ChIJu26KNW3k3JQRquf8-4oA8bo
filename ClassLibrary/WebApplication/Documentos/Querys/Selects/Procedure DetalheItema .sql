use unimarket
go
Excluir DetalheUsuario
go
create procedure DetalheItem(
	@IdItem int
	)
as	
begin
	select Item.Id, Item.Nome, Item.ValorUnitario, Item.Quantidade, Item.Descricao,
	Categoria.Nome, Usuario.Nome, Usuario.Latitude, Usuario.Longitude, Usuario.Telefone,
	Usuario.Email from Item
	inner join Usuario on (Item.IdUsuario = Usuario.Id)
	inner join Categoria on (Item.IdCategoria = Categoria.Id)
	where (Item.Id = @IdItem)
end