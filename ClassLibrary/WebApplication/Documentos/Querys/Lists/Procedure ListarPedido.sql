use unimarket
if OBJECT_ID('ListarPedidoComprador') is not null
drop procedure ListarPedidoComprador
go
if OBJECT_ID('ListarPedidoVendedor') is not null
drop procedure ListarPedidoVendedor
go
create procedure ListarPedidoComprador(
	@IdUsuario int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Pedido.Data, Vendedor.Nome as 'Vendedor',(
	select SUM(ValorUnitario) from ItemPedido where IdPedido=Pedido.Id) as Valor, StatusPedido.Nome as Status 
	from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join StatusPedido on Pedido.IdStatusPedido = StatusPedido.Id
	where (Comprador.Id = @IdUsuario)
	order by Pedido.Id desc 
end
go
create procedure ListarPedidoVendedor(
	@IdUsuario int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Pedido.Data, Comprador.Nome as 'Comprador',(
	select SUM(ValorUnitario) from ItemPedido where IdPedido=Pedido.Id) as Valor, StatusPedido.Nome as Status 
	from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join StatusPedido on Pedido.IdStatusPedido = StatusPedido.Id
	where (Vendedor.Id = @IdUsuario)
	order by Pedido.Id desc
end