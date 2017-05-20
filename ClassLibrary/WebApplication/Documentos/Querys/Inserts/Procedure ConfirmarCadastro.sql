use unimarket
go
create procedure ConfirmarCadastro(
	@HashConfirmacao varchar(50)
	)
as 
begin
	update Usuario set IdStatusUsuario='1' where IdStatusUsuario='2' 
	and HashConfirmacao=@HashConfirmacao
	if @@ROWCOUNT = 1
	select Usuario.Id as Id, Usuario.Nome, Usuario.Email, Usuario.CpfCnpj, Usuario.Latitude, 
	Usuario.Longitude, Usuario.Numero, Usuario.AreaAtuacao, Usuario.IdStatusUsuario, Usuario.IdTipoUsuario
	from Usuario where HashConfirmacao=@HashConfirmacao
end
