use unimarket
go
Excluir CarragarUsuario
go
create procedure CarragarUsuario(
	@IdUsuario int
	)
as	
begin
	select Email, Nome, Telefone, Latitude, Longitude, Complemento, AreaAtuacao from Usuario
	where (Usuario.Id = @IdUsuario)
end