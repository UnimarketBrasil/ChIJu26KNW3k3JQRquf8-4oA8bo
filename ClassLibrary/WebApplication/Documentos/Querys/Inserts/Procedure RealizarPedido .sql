use unimarket
go
Excluir RealizarPedido
go
create procedure RealizarPedido(
	@IdVendedor int,
	@IdComprador int
	)
as begin
	begin try
		begin tran
			insert into Pedido(
			Codigo,
			IdVendedor,
			IdComprador
			)  output inserted.Id values (
			convert(int,(select top(1) codigo from Pedido where idVendedor = @IdVendedor order by Data desc)) + 1,
			@IdVendedor,
			@IdComprador
			)
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