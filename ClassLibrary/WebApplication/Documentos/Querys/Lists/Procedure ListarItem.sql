use unimarket
if OBJECT_ID('ListarItem') is not null
drop procedure ListarItem
go
create procedure ListarItem(
	@IdUsuario int
	)
as
begin
	select Item.Id, Item.Codigo, Item.Nome, Item.Valorunitario, Item.Quantidade from Item
	where ((Item.IdUsuario = @IdUsuario) and (Item.Desabilitado = 'False'))
end