use unimarket
go
Excluir AlterarSenhaSubUsuario
go
create procedure AlterarSenhaSubUsuario(
	@IdUsuario int,
	@NovaSenha varchar(50),
	@SenhaAtual varchar(50)
	)
as
begin
	begin try
		begin tran
			if ((select Usuario.Senha from Usuario where (Usuario.Id = @IdUsuario)) = @SenhaAtual)
			begin
				update Usuario set
				Usuario.Senha = @Senha
				where (Usuario.Id = @IdUsuario)
			end
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end