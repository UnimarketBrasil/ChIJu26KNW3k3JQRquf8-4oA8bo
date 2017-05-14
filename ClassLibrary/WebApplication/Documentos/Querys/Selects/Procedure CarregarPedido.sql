use unimarket
go
Excluir CarregarPedido
go
create procedure CarregarPedido(
	@IdPedido int
	)
as
begin
	select Vendedor.Nome as Vendedor,
	Comprador.Nome as Comprador, Comprador.Latitude, Comprador.Longitude, Comprador.Numero, Comprador.Complemento, Data from Pedido
	inner join Usuario as Vendedor on Vendedor.Id = Pedido.IdVendedor
	inner join Usuario as Comprador on Comprador.Id = Pedido.IdComprador

end
go
create procedure CarregarItemPedido(
	@IdPedido int
	)
as 
begin
	select Item.Nome, ItemPedido.Quantidade, Item.ValorUnitario from ItemPedido
	inner join Item on Item.Id = ItemPedido.IdItem
	where (ItemPedido.IdPedido = @IdPedido) 
end
go

