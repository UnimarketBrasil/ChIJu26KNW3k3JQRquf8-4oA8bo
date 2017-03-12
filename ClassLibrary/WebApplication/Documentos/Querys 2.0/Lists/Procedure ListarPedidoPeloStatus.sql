use UnimarketDB
go
Excluir ListarPedidoPeloStatusVendedor
go
create procedure ListarPedidoPeloStatusVendedor(
	@IdUsuario int,
	@IdStatus int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Administrador.Nome from Pedido
	inner join Administrador on Pedido.IdComprador = Administrador.Id
	where ((Administrador.Id = @IdUsuario) and (Pedido.Id = Pedido.IdStatusPedido))
end
go
create procedure ListarPedidoPeloStatusComprador(
	@IdUsuario int,
	@IdStatus int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Administrador.Nome from Pedido
	inner join Administrador on Pedido.IdVendedor = Administrador.Id
	where ((Administrador.Id = @IdUsuario) and (Pedido.Id = Pedido.IdStatusPedido))
end