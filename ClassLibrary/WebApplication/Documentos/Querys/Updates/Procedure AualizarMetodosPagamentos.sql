use unimarket
if OBJECT_ID('AtualizarMetodosPagamento') is not null
drop procedure AtualizarMetodosPagamento
go
create procedure AtualizarMetodosPagamento(
	@IdMetodo int,
	@IdVendedor int,
	@Desabilitado bit
	)
as begin
	begin try
		begin tran		
			update MetodosPagamentoUsuario set
			Desabilitado = @Desabilitado
			where (IdMetodo = @IdMetodo) and (@IdVendedor = @IdVendedor)			
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end