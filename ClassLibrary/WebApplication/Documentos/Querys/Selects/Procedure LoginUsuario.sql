use unimarket
go
Excluir LoginUsuario
go
create procedure LoginUsuario (
	@Email varchar(50),
	@Senha varchar(50)
	)
as
	declare @IdUsuario int
begin
	if exists (select Usuario.Id from Usuario where (Usuario.Email = @Email))
	begin
		select Usuario.Id as Id, Usuario.Nome, Usuario.Email, Usuario.CpfCnpj, Usuario.Latitude, Usuario.Longitude, Usuario.AreaAtuacao, Usuario.IdStatusUsuario, Usuario.IdTipoUsuario
		from Usuario where (Usuario.Email = @Email) and (Usuario.Senha = @Senha) and (Usuario.IdStatusUsuario = 1)
	end
	else if exists (select SubUsuario.Id as IdUsuario from SubUsuario where (SubUsuario.Email = @Email))
		select SubUsuario.IdUsuario as Id, SubUsuario.Nome, SubUsuario.Email, Usuario.CpfCnpj, Usuario.Latitude, Usuario.Longitude, Usuario.AreaAtuacao, Usuario.IdStatusUsuario, Usuario.IdTipoUsuario 
		from SubUsuario 
		inner join Usuario on (Usuario.ID = SubUsuario.IdUsuario)
		where (SubUsuario.Email = @Email) and (SubUsuario.Senha = @Senha) and (Usuario.IdStatusUsuario = 1)
	end