use unimarket
if OBJECT_ID('ListarPedidoPeloStatusVendedor') is not null
drop procedure ListarPedidoPeloStatusVendedor
go
if OBJECT_ID('ListarPedidoPeloStatusComprador') is not null
drop procedure ListarPedidoPeloStatusComprador
go
create procedure ListarPedidoPeloStatusVendedor(
	@IdUsuario int,
	@IdStatus int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Pedido.Data, Comprador.Nome as 'Comprador',(
	select SUM(ValorUnitario) from ItemPedido where IdPedido=Pedido.Id) as Valor, StatusPedido.Nome as Status 
	from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join StatusPedido on Pedido.IdStatusPedido = StatusPedido.Id
	where ((Vendedor.Id = @IdUsuario) and (Pedido.IdStatusPedido = @IdStatus))
	order by Pedido.Id desc
end
go
create procedure ListarPedidoPeloStatusComprador(
	@IdUsuario int,
	@IdStatus int
	)
as
begin
	Select Pedido.Id, Pedido.Codigo, Pedido.Data, Vendedor.Nome as 'Vendedor',(
	select SUM(ValorUnitario) from ItemPedido where IdPedido=Pedido.Id) as Valor, StatusPedido.Nome as Status 
	from Pedido
	inner join Usuario as Vendedor on Pedido.IdVendedor = Vendedor.Id
	inner join Usuario as Comprador on Pedido.IdComprador = Comprador.Id
	inner join StatusPedido on Pedido.IdStatusPedido = StatusPedido.Id
	where ((Comprador.Id = @IdUsuario) and (Pedido.IdStatusPedido = @IdStatus))
	order by Pedido.Id desc
end