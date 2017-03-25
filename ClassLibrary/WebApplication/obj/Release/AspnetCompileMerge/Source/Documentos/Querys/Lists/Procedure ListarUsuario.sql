use UnimarketDB
go
Excluir ListarUsuario
go
create procedure ListarUsuario
as	
begin
	select Usuario.Id, Usuario.Email, Usuario.Nome, TipoUsuario.Nome, StatusUsuario.Nome  from Usuario
	inner join StatusUsuario on StatusUsuario.Id = Usuario.IdStatusUsuario
	inner join TipoUsuario on TipoUsuario.Id = Usuario.IdTipoUsuario
end