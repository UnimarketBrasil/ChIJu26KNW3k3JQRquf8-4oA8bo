use UnimarketDB
go
Excluir AlterarSenhaSubUsuario
go
create procedure AlterarSenhaSubUsuario(
	@IdUsuario int,
	@Senha varchar(50)
	)
as
begin
	begin try
		begin tran
			update Usuario set
			Usuario.Senha = @Senha
			where (Usuario.Id = @IdUsuario)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end