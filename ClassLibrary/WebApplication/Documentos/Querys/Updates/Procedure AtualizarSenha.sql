use unimarket
go
Excluir AtualizarSenha
go
create procedure AtualizarSenha(
	@IdUsuario int,
	@Senha varchar(50)
	)
as
begin
	begin try
		begin tran
			update Usuario set 
			senha = @Senha
			where (Usuario.Id = @IdUsuario)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end