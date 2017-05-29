use unimarket
if OBJECT_ID('FinalizarPedido') is not null
drop procedure FinalizarPedido
go
create procedure FinalizarPedido(
	@IdPedido int
	)
as
begin
	begin try
		begin tran
			update Pedido set
			Pedido.IdStatusPedido = 2, DateFinalizadoOuCancelado=GETDATE()
			where (Pedido.Id = @IdPedido)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end