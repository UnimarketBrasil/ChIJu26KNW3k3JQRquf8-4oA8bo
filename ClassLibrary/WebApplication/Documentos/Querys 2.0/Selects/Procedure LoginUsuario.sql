use UnimarketDB
go
Excluir LoginUsuario
go
create procedure LoginUsuario(
	@Email varchar(50),
	@senha varchar(50)
	)
as
	declare @IdUsuario int
begin
	if exists (select Administrador.Id from Administrador where (Administrador.Email = @Email))
		select @IdUsuario = Adminstrador.Id from Adminstrador where (dministrador.Email = @Email) and (Administrador.Email = @Email)
	else if exists (select Usuario.Id, Usuario.Senha as pass from Usuario where (Usuario.Email = @Email))
		select @IdUsuario = Usuario.Id from Usuario where (Usuario.Email = @Email) and (Usuario.Senha = @Senha)
end