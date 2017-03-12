use UnimarketDB
go
Excluir ListarAdministrador
go
create procedure ListarAdministrador
as	
begin
	select Administrador.Id, Administrador.Email, Administrador.Nome, TipoUsuario.Nome, StatusUsuario.Nome  from Administrador
	inner join StatusUsuario on StatusUsuario.Id = Administrador.IdStatusUsuario
	inner join TipoUsuario on TipoUsuario.Id = Administrador.IdTipoUsuario
end