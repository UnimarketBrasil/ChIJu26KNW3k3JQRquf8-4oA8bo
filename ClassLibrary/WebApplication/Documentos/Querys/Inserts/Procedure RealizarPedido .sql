use unimarket
if OBJECT_ID('RealizarPedido') is not null
drop procedure RealizarPedido
go
if OBJECT_ID('CadastrarItemPedido') is not null
drop procedure CadastrarItemPedido
go
create procedure RealizarPedido(
	@IdVendedor int,
	@IdComprador int
	)
as 
if ((select top(1) codigo from Pedido where (idVendedor = @IdVendedor)) >= (1))
	begin
		insert into Pedido(
		Codigo,
		IdVendedor,
		IdComprador
		)  output inserted.Id values (
		convert(int,(select top(1) codigo from Pedido where idVendedor = @IdVendedor order by Data desc)) + 1,
		@IdVendedor,
		@IdComprador
		)
	end
else
	begin
		insert into Pedido(
		Codigo,
		IdVendedor,
		IdComprador
		)  output inserted.Id values (
		1,
		@IdVendedor,
		@IdComprador
		)
	end
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