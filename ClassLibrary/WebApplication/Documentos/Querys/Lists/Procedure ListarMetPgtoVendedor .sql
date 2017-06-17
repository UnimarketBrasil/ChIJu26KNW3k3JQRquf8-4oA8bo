use unimarket
if OBJECT_ID('ListarMetPgtoVendedor ') is not null
drop procedure ListarMetPgtoVendedor 
go
create procedure ListarMetPgtoVendedor (
	@IdUsuario int
	)
as
begin
	select MetodosPagamento.Id, MetodosPagamento.IdTipoMetodo , MetodosPagamento.Nome from MetodosPagamentoUsuario
	inner join MetodosPagamento on (MetodosPagamentoUsuario.IdMetodo = MetodosPagamento.Id)
	where MetodosPagamentoUsuario.IdVendedor=@IdUsuario and Desabilitado<>0
end