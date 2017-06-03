use unimarket
if OBJECT_ID('CadastrarMetodosPagamento') is not null
drop procedure CadastrarMetodosPagamento
go
create procedure CadastrarMetodosPagamento(
	@IdUsuario int
	)
as begin
	begin try
		begin tran
			insert into MetodosPagamentoUsuario(
			IdMetodo,
			IdVendedor,
			Desabilitado
			)select MetodosPagamento.Id, @IdUsuario, 'false' from MetodosPagamento
			update MetodosPagamentoUsuario set Desabilitado ='true' where IdMetodo=1 and IdVendedor=@IdUsuario
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
