use unimarket
go
Excluir ListarItemPorNomeOuCodigo
go
create procedure ListarItemPorNomeOuCodigo(
	@IdUsuario int,
	@Codigo varchar(50)
	)
as
begin
	select Item.Codigo, Item.Nome, Item.Valorunitario, Item.Quantidade from Item
	where ((Item.Desabilitado = 'False') and (Item.IdUsuario = @IdUsuario) and ((Item.Codigo like '%'+@Codigo+'%') or (Item.Nome like '%'+@Codigo+'%')))
end	