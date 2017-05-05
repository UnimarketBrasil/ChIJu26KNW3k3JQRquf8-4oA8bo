use unimarket
go
Excluir ListarPedidoComprador
go
create procedure ListarPedidoComprador(
	@IdUsuario int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Vendedor.Nome as 'Vendedor' from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	where (Comprador.Id = @IdUsuario)
	order by Pedido.Id desc
end
go
create procedure ListarPedidoVendedor(
	@IdUsuario int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Comprador.Nome as 'Comprador' from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	where (Vendedor.Id = @IdUsuario)
	order by Pedido.Id desc
end