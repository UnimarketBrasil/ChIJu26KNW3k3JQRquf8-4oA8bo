use unimarket
go
Excluir CarregarSubUsuario
go
create procedure CarregarSubUsuario
as
begin
	select Usuario.Id, Usuario.Nome, Usuario.Email from Usuario
end