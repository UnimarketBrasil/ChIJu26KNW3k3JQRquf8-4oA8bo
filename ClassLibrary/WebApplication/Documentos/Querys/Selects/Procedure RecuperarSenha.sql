use unimarket
if OBJECT_ID('Recuperarsenha') is not null
drop procedure Recuperarsenha
go
create procedure Recuperarsenha(
	@Email varchar(80),
	@hashNovaSenha varchar(80)
	)
as
begin
	if exists ( select Usuario.Id from Usuario where Usuario.Email = @Email)
		Begin
			update Usuario set HashNovaSenha=@hashNovaSenha
			where Usuario.Email = @Email and Usuario.IdStatusUsuario = 1
			select Usuario.Email, Usuario.HashNovaSenha from Usuario 
			where Usuario.Email = @Email and USuario.HashNovaSenha = @hashNovaSenha
		end
end