use UnimarketDB
go
Excluir CancelarPedido
go
create procedure CancelarPedido(
	@IdPedido int
	)
as
begin
	begin try
		begin tran
			update Pedido set
			Pedido.IdStatusPedido = 3
			where (Pedido.Id = @IdPedido)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end