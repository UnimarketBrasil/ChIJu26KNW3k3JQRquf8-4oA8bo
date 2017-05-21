use unimarket
go
create procedure MecanismoDeBusca(
	@Pesquisa varchar(50),
	@LatitudeComprador varchar(20),
	@LongitudeComprador varchar(20)
	)
as begin
	select Item.Id, Item.Nome,Item.ValorUnitario, Usuario.Nome as Vendedor,
	Usuario.Id as IdVendendor
	from Item
	inner join Usuario on Usuario.Id = Item.IdUsuario
	where( (dbo.CalculoDistancia( Usuario.Latitude, Usuario.Longitude, @LatitudeComprador, @LongitudeComprador) <= Usuario.AreaAtuacao*1000) and (Item.Desabilitado = 'false') and (Item.Quantidade > 0)) and (Item.Nome like '%'+@Pesquisa+'%')
	order by difference( @Pesquisa+' %', Item.Nome) desc;
end