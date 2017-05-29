use unimarket
if OBJECT_ID('CancelarPedido') is not null
drop procedure CancelarPedido
go
create procedure CancelarPedido(
	@IdPedido int
	)
as
begin
	begin try
		begin tran
			update Item set Quantidade = (Item.Quantidade + (select ItemPedido.Quantidade from ItemPedido where IdPedido=@IdPedido and ItemPedido.IdItem=Item.Id)) 
			where Item.Id = (select ItemPedido.IdItem from ItemPedido where IdPedido=@IdPedido and ItemPedido.IdItem=Item.Id)
			update Pedido set
			Pedido.IdStatusPedido = 3, DateFinalizadoOuCancelado=GETDATE()
			where (Pedido.Id = @IdPedido)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end