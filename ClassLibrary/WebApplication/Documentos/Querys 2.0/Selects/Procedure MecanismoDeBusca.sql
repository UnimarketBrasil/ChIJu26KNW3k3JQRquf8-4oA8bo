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
	select Item.Id, Item.Nome,Item.ValorUnitario, Administrador.Nome as Vendedor from Item
	inner join Administrador on Administrador.Id = Item.IdUsuario
	where( (dbo.CalculoDistancia( Administrador.Latitude, Administrador.Longitude, @LatitudeComprador, @LongitudeComprador) <= Administrador.AreaAtuacao*1000) and (Item.Desabilitado = 'false'))
	order by difference( @Pesquisa+' %', Item.Nome) desc;
end