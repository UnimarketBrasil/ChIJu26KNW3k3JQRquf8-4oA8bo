use unimarket
go
Excluir ListarPedidoComprador
go
create procedure ListarPedidoComprador(
	@IdUsuario int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Vendedor.Nome as 'Vendedor', ItemPedido.Quantidade * ItemPedido.ValorUnitario as 'Valor' from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join ItemPedido on Pedido.Id = ItemPedido.IdPedido
	where (Comprador.Id = @IdUsuario)
	order by Pedido.Id desc
end
go
create procedure ListarPedidoVendedor(
	@IdUsuario int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Comprador.Nome as 'Comprador', ItemPedido.Quantidade * ItemPedido.ValorUnitario as 'Valor' from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join ItemPedido on Pedido.Id = ItemPedido.IdPedido
	where (Vendedor.Id = @IdUsuario)
	order by Pedido.Id desc
end