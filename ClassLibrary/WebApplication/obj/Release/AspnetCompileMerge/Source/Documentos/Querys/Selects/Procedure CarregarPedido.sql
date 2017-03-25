use UnimarketDB
go
Excluir CarregarPedido
go
create procedure CarregarPedido(
	@IdPedido int
	)
as 
begin
	select Item.Nome, Item.Quantidade from ItemPedido
	inner join Item on Item.Id = ItemPedido.IdItem
	where (ItemPedido.IdPedido = @IdPedido) 
end