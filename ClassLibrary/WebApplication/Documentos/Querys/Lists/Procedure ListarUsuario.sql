use unimarket
if OBJECT_ID('ListarUsuario') is not null
drop procedure ListarUsuario
go
create procedure ListarUsuario
as	
begin
	select Usuario.Id, Usuario.Email, Usuario.Nome, TipoUsuario.Nome as TipoUsuario, StatusUsuario.Nome as StatusUsuario from Usuario
	inner join StatusUsuario on StatusUsuario.Id = Usuario.IdStatusUsuario
	inner join TipoUsuario on TipoUsuario.Id = Usuario.IdTipoUsuario
	where Usuario.IdTipoUsuario<>1
end