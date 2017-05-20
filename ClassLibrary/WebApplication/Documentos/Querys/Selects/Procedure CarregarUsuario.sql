use unimarket
go
create procedure CarregarUsuario
	(
	@IdUsuario int
	)
as	
begin
	select Usuario.Id, Usuario.Email, Usuario.Nome, Usuario.Sobrenome, Usuario.CpfCnpj, Usuario.Nascimento, 
	Usuario.Genero, Usuario.Telefone, Usuario.Latitude, Longitude, Usuario.Complemento, Usuario.AreaAtuacao,
	Usuario.Numero, Usuario.IdStatusUsuario, Usuario.IdTipoUsuario from Usuario
	where (Usuario.Id = @IdUsuario)
end