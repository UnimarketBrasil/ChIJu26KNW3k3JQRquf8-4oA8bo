use unimarket
go
Excluir ListarPedidoComprador
go
create procedure ListarPedidoComprador(
	@IdUsuario int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Usuario.Nome from Pedido
	inner join Usuario on Pedido.IdComprador = v.Id
	where (Usuario.Id = @IdUsuario)
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
	select Usuario.Id, Pedido.Codigo, Usuario.Nome from Pedido
	inner join Usuario on Pedido.IdComprador = Usuario.Id
	where (Usuario.Id = @IdUsuario)
	order by Pedido.Id desc
end