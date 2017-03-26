use unimarket
go
Excluir CarregarSubUsuario
go
create procedure CarregarSubUsuario (
	@IdUsuario int
	)
as
begin
	select SubUsuario.Id, SubUsuario.Nome, SubUsuario.Email from SubUsuario
	where (SubUsuario.Id = @IdUsuario)
end