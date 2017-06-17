use unimarket
if OBJECT_ID('CarregarUsuario') is not null
drop procedure CarregarUsuario
go
create procedure CarregarUsuario(
	@IdUsuario int
	)
as	
begin
	select Usuario.Id, Usuario.Email, Usuario.Nome, Usuario.Sobrenome, Usuario.CpfCnpj, 
	Usuario.Genero, Usuario.Telefone, Usuario.Latitude, Longitude, Usuario.CEP, Usuario.Complemento, Usuario.AreaAtuacao,
	Usuario.Numero, Usuario.IdStatusUsuario, Usuario.IdTipoUsuario from Usuario
	where (Usuario.Id = @IdUsuario)
end
go
use unimarket
if OBJECT_ID('CarregarMetodosPagamento') is not null
drop procedure CarregarMetodosPagamento
go
create procedure CarregarMetodosPagamento(
	@IdVendedor int
	)
as	
begin
	select MetodosPagamentoUsuario.IdMetodo, MetodosPagamento.Nome, MetodosPagamento.IdTipoMetodo , MetodosPagamentoUsuario.Desabilitado from MetodosPagamentoUsuario
	inner join MetodosPagamento on MetodosPagamento.Id = MetodosPagamentoUsuario.IdMetodo
	where (IdVendedor = @IdVendedor)
end