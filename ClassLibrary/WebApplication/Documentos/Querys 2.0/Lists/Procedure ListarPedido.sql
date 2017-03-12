use UnimarketDB
go
Excluir ListarPedidoComprador
go
create procedure ListarPedidoComprador(
	@IdUsuario int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Administrador.Nome from Pedido
	inner join Administrador on Pedido.IdComprador = Administrador.Id
	where (Administrador.Id = @IdUsuario)
	order by Pedido.Id desc
end
go
Excluir ListarPedidoVendedor
go
create procedure ListarPedidoVendedor(
	@IdUsuario int
	)
as
begin
	select Administrador.Id, Pedido.Codigo, Administrador.Nome from Pedido
	inner join Administrador on Pedido.IdComprador = Administrador.Id
	where (Administrador.Id = @IdUsuario)
	order by Pedido.Id desc
end