use unimarket
go
create procedure MecanismoDeBusca(
	@Pesquisa varchar(50),
	@IdComprador int,
	@LatitudeComprador varchar(20),
	@LongitudeComprador varchar(20)
	)
as begin
	select Item.Id, Item.Nome,Item.ValorUnitario, Usuario.Nome as Vendedor,
	Usuario.Id as IdVendendor from Item
	inner join Usuario on Usuario.Id = Item.IdUsuario
	where((dbo.CalculoDistancia( Usuario.Latitude, Usuario.Longitude, @LatitudeComprador, @LongitudeComprador) < Usuario.AreaAtuacao*1000) and (Item.Desabilitado = 'false') and (Item.Quantidade > 0) and (Item.Nome like '%'+@Pesquisa+'%') and (Usuario.Id <> @IdComprador))
	
end
go
create procedure MecanismoDeBuscaCategoria(
	@IdCategoria int,
	@IdComprador int,
	@LatitudeComprador varchar(20),
	@LongitudeComprador varchar(20)
	)
as begin
	select Item.Id, Item.Nome,Item.ValorUnitario, Usuario.Nome as Vendedor,
	Usuario.Id as IdVendendor	from Item
	inner join Usuario on Usuario.Id = Item.IdUsuario
	where( (dbo.CalculoDistancia( Usuario.Latitude, Usuario.Longitude, @LatitudeComprador, @LongitudeComprador) <= Usuario.AreaAtuacao*1000) and (Item.Desabilitado = 'false') and (Item.Quantidade > 0) and (Usuario.Id <> @IdComprador) and (Item.IdCategoria=@IdCategoria))
end