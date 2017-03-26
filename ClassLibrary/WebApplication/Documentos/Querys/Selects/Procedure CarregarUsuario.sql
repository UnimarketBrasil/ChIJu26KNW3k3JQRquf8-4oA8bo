use unimarket
go
Excluir CarragarUsuario
go
create procedure CarragarUsuario(
	@IdUsuario int
	)
as	
begin
	select Usuario.Email, Usuario.Nome, Usuario.Telefone, Usuario.Latitude, Longitude, Usuario.Complemento, Usuario.AreaAtuacao from Usuario
	where (Usuario.Id = @IdUsuario)
end