use UnimarketDB
go
Excluir ListarItemPorCategoria
go
create procedure ListarItemPorCategoria(
	@IdCategoria varchar(50),
	@LatitudeComprador int,
	@LongitudeComprador int
	)
as begin
	select Item.Id, Item.Nome,Item.ValorUnitario, Usuario.Nome as Vendedor from Item
	inner join Usuario on Usuario.Id = Item.IdUsuario
	inner join Categoria on Categoria.Id = Item.IdCategoria
	where( (dbo.CalculoDistancia( Usuario.Latitude, Usuario.Longitude, @LatitudeComprador, @LongitudeComprador) <= Usuario.AreaAtuacao) and (Item.Desabilitado = 'false') and (Categoria.Id = @IdCategoria))
end