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
	select Item.Id, Item.Nome,Item.ValorUnitario, Administrador.Nome as Vendedor from Item
	inner join Administrador on Administrador.Id = Item.IdUsuario
	inner join Categoria on Categoria.Id = Item.IdCategoria
	where( (dbo.CalculoDistancia( Administrador.Latitude, Administrador.Longitude, @LatitudeComprador, @LongitudeComprador) <= Administrador.AreaAtuacao) and (Item.Desabilitado = 'false') and (Categoria.Id = @IdCategoria))
end