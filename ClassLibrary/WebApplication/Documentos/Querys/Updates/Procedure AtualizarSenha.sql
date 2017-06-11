use unimarket
if OBJECT_ID('AtualizarSenha') is not null
drop procedure AtualizarSenha
go
if OBJECT_ID('NovaSenha') is not null
drop procedure NovaSenha
go
create procedure AtualizarSenha(
	@IdUsuario int,
	@SenhaAntiga varchar(50),
	@NovaSenha varchar(50)
	)
as
begin
	if exists (select * from Usuario where Usuario.Senha = @SenhaAntiga) 
		begin
			update Usuario set senha = @NovaSenha
			where (Usuario.Id = @IdUsuario and Usuario.Senha = @SenhaAntiga)
			select Usuario.Email from Usuario where (Usuario.Senha = @NovaSenha)
		end	
end
go
create procedure NovaSenha(
	@hashNovaSenha varchar(80),
	@Senha varchar(50)
	)
as
begin
	if exists (select * from Usuario where Usuario.HashNovaSenha = @hashNovaSenha) 
		begin
			update Usuario set senha = @Senha, HashNovaSenha = null
			where (Usuario.HashNovaSenha = @hashNovaSenha)
			select Usuario.Email from Usuario where (Usuario.Senha = @Senha)
		end	
end