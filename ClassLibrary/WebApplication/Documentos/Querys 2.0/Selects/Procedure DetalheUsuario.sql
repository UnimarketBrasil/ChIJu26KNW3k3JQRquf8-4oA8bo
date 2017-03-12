use UnimarketDB
go
Excluir DetalheAdministrador
go
create procedure DetalheAdministrador(
	@IdAdministrador int
	)
as	
begin
	select Administrador.Email, Administrador.Nome, Administrador.Telefone, Administrador.Latitude, Administrador.Longitude, Administrador.Complemento, Administrador.AreaAtuacao, TipoUsuario.Nome, StatusUsuario.Nome  from Administrador
	inner join StatusUsuario on StatusUsuario.Id = Administrador.IdStatusUsuario
	inner join TipoUsuario on TipoUsuario.Id = Administrador.IdTipoUsuario
	where (Administrador.Id = @IdAdministrador)
end