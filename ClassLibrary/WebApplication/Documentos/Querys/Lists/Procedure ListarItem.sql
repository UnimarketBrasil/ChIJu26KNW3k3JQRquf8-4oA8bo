use unimarket
if OBJECT_ID('CadastrarUsuario') is not null
drop procedure CadastrarUsuario
go
create procedure ListarItem(
	@IdUsuario int
	)
as
begin
	select Item.Id, Item.Codigo, Item.Nome, Item.Valorunitario, Item.Quantidade from Item
	where ((Item.IdUsuario = @IdUsuario) and (Item.Desabilitado = 'False'))
end