use unimarket
go
Excluir LoginUsuario
go
create procedure LoginUsuario (
	@Email varchar(50),
	@senha varchar(50)
	)
as
	declare @IdUsuario int = 0
begin
	if exists (select Usuario.Id as IdUsuario from Usuario where (Usuario.Email = @Email))
		select @IdUsuario = Usuario.Id from Usuario where (Usuario.Email = @Email)
	else if exists (select SubUsuario.Id as IdUsuario from SubUsuario where (SubUsuario.Email = @Email) and (SubUsuario.Senha = @Senha))
		select  @IdUsuario = SubUsuario.Id from SubUsuario where (SubUsuario.Email = @Email) and (SubUsuario.Senha = @Senha)
end