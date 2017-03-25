use unimarket
go
Excluir RealizarPedido
go
create procedure RealizarPedido(
	@CodigoPedido varchar(50),
	@IdVendedor int,
	@IdComprador int,
	@IdStatusPedido int
	)
as begin
	begin try
		begin tran
			insert into Pedido(
			Codigo,
			IdVendedor,
			IdComprador,
			IdStatusPedido
			)  output inserted.Id values (
			@CodigoPedido,
			@IdVendedor,
			@IdComprador,
			@IdStatusPedido
			);return
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end

go
Excluir CadastrarItemPedido
go
Create procedure CadastrarItemPedido(
	@IdPedido int,
	@IdItem int,
	@Quantidade varchar(20)
	)
as
begin
	begin try
		begin tran		
			if ((select Quantidade from Item where (Item.Id = @IdItem)) >= (@Quantidade))
				begin
					insert into ItemPedido( 
					Quantidade, 
					IdItem,	
					IdPedido
					)
					values (
					@Quantidade, 
					@IdItem, 
					@IdPedido
					)		
			  end
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end