--VERIFICAR POSTERIORMENTE COMO SERÁ FEITA A PESQUISA QUANDO O USUARIO NÃO ESTIVER LOGADO

use UnimarketDB
go
Excluir MecanismoDeBusca
go
create procedure MecanismoDeBusca(
	@Pesquisa varchar(50),
	@LatitudeComprador int,
	@LongitudeComprador int
	)
as begin
	select Item.Id, Item.Nome,Item.ValorUnitario, Usuario.Nome as Vendedor from Item
	inner join Usuario on Usuario.Id = Item.IdUsuario
	where( (dbo.CalculoDistancia( Usuario.Latitude, Usuario.Longitude, @LatitudeComprador, @LongitudeComprador) <= Usuario.AreaAtuacao*1000) and (Item.Desabilitado = 'false') and (Item.Quantidade > 0))
	order by difference( @Pesquisa+' %', Item.Nome) desc;
end