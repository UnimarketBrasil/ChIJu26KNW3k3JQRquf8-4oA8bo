use UnimarketDB
go
Excluir DetalheUsuario
go
create procedure DetalheUsuario(
	@IdUsuario int
	)
as	
begin
	select Usuario.Email, Usuario.Nome, Usuario.Telefone, Usuario.Latitude, Usuario.Longitude, Usuario.Complemento, Usuario.AreaAtuacao, TipoUsuario.Nome, StatusUsuario.Nome  from Usuario
	inner join StatusUsuario on StatusUsuario.Id = Usuario.IdStatusUsuario
	inner join TipoUsuario on TipoUsuario.Id = Usuario.IdTipoUsuario
	where (Usuario.Id = @IdUsuario)
end