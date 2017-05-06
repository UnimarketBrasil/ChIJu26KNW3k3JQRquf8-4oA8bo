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
create procedure CadastrarItemPedido(
	@IdPedido int,
	@IdItem int,
	@Quantidade real,
	@ValorUnitario real
	)
as
begin
	begin try
		begin tran		
			if ((select Quantidade from Item where (Item.Id = @IdItem)) >= (@Quantidade))
				begin
					insert into ItemPedido( 
					Quantidade,
					ValorUnitario,
					IdItem,	
					IdPedido
					)
					values (
					@Quantidade,
					@ValorUnitario,
					@IdItem, 
					@IdPedido
					)		
			  end
			else
			print 'deu erro';
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end