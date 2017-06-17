use unimarket
if OBJECT_ID('AtualizarUsuario') is not null
drop procedure AtualizarUsuario
go
if OBJECT_ID('AtualizarMetodosPagamento') is not null
drop procedure AtualizarMetodosPagamento
go
create  procedure AtualizarUsuario(
	@IdUsuario int,
	@Email varchar(50),
	@Nome varchar(50),
	@Sobrenome varchar(50) = null,
	@Telefone varchar(15),
	@Latitude float,
	@Longitude float,
	@Complemento text = null,
	@Numero int,
	@AreaAtuacao real
	)
as
begin
	begin try
		begin tran
			update Usuario set
			Email = @Email,
			Nome = @Nome,
			Sobrenome = @Sobrenome,
			Telefone = @Telefone,
			Latitude = @Latitude,
			Longitude = @Longitude,
			Complemento = @Complemento,
			Numero = @Numero,
			AreaAtuacao = @AreaAtuacao
			where ( Id = @IdUsuario )
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
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
			where (IdMetodo = @IdMetodo) and (IdVendedor = @IdVendedor)			
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
	
