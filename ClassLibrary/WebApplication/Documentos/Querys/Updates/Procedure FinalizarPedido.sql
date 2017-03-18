use UnimarketDB
go
Excluir FinalizarPedido
go
create procedure FinalizarPedido(
	@IdPedido int
	)
as
begin
	begin try
		begin tran
			update Item set 
			Item.Quantidade = (select ItemPedido.Quantidade from ItemPedido 
			where (ItemPedido.IdPedido = @IdPedido)or(ItemPedido.IdItem = Item.Id))
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end