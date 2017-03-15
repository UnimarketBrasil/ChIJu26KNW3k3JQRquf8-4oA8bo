use UnimarketDB
go
Excluir FinalizarPedido
go
create procedure FinalizarPedido(
	@IdPedido int
	)
as
begin
	update Item set 
	Item.Quantidade = (select ItemPedido.Quantidade from ItemPedido where (ItemPedido.IdPedido = @IdPedido)or(ItemPedido.IdItem = Item.Id))
end