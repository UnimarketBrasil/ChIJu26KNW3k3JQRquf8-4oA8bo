use UnimarketDB
go
Excluir DesabilitarItemPorId
go
create procedure DesabilitarItemPorId(
	@IdItem int
	)
as
begin
	update Item
	set Desabilitado = 'true'
	where Item.Id = @IdItem
end