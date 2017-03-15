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
	select Pedido.Id, Pedido.Codigo, Usuario.Nome from Pedido
	inner join Usuario on Pedido.IdComprador = Usuario.Id
	where ((Usuario.Id = @IdUsuario) and (Pedido.Id = Pedido.IdStatusPedido))
end
go
create procedure ListarPedidoPeloStatusComprador(
	@IdUsuario int,
	@IdStatus int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Usuario.Nome from Pedido
	inner join Usuario on Pedido.IdVendedor = Usuario.Id
	where ((Usuario.Id = @IdUsuario) and (Pedido.Id = Pedido.IdStatusPedido))
end