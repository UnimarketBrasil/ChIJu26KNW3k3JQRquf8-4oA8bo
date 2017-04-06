use unimarket
go
Excluir LoginUsuario
go
create procedure LoginUsuario(
	@Email varchar(50),
	@Senha varchar(50)
	)
as 
begin
	select Usuario.Id, Usuario.Email, Usuario.Nome, Usuario.Sobrenome, Usuario.CpfCnpj,
	Usuario.Telefone, Usuario.Longitude, Usuario.Latitude, Usuario.Complemento, Usuario.AreaAtuacao, Usuario.nome,
	Usuario.IdTipoUsuario, Usuario.IdStatusUsuario
	from Usuario
	where (Usuario.Email = @Email and Usuario.Senha = @Senha)
end