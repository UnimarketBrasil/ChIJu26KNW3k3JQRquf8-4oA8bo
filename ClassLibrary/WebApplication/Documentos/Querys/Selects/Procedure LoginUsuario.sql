use unimarket
if OBJECT_ID('LoginUsuario') is not null
drop procedure LoginUsuario
go
create procedure LoginUsuario (
	@Email varchar(50),
	@Senha varchar(50)
	)
as
	declare @IdUsuario int
begin
	select Usuario.Id as Id, Usuario.Nome, Usuario.Sobrenome, Usuario.Email, Usuario.CpfCnpj, Usuario.Telefone, Usuario.Latitude, Usuario.Longitude, Usuario.AreaAtuacao, Usuario.IdStatusUsuario, Usuario.IdTipoUsuario
	from Usuario where (Usuario.Email = @Email) and (Usuario.Senha = @Senha)
end
