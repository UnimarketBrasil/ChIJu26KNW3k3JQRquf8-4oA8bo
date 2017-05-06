use unimarket
go
Excluir ListarPedidoPeloStatusVendedor
go
create procedure ListarPedidoPeloStatusVendedor(
	@IdUsuario int,
	@IdStatus int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Comprador.Nome as 'Comprador', ItemPedido.Quantidade * ItemPedido.ValorUnitario as 'Valor' from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join ItemPedido on Pedido.Id = ItemPedido.IdPedido
	where ((Vendedor.Id = @IdUsuario) and (Pedido.IdStatusPedido = @IdStatus))
end
go
create procedure ListarPedidoPeloStatusComprador(
	@IdUsuario int,
	@IdStatus int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Vendedor.Nome as 'Vendedor', ItemPedido.Quantidade * ItemPedido.ValorUnitario as 'Valor' from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join ItemPedido on Pedido.Id = ItemPedido.IdPedido
	where ((Comprador.Id = @IdUsuario) and (Pedido.IdStatusPedido = @IdStatus))
end