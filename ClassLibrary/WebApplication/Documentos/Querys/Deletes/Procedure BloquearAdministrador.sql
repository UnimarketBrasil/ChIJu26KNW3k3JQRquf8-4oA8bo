use Unimarketdb
go
Excluir BloquearUsuario
go
create procedure BloquearUsuario(
	@IdUsuario int
	)
as
begin
	update Usuario
	set Usuario.IdStatusUsuario = 3
	where Usuario.Id = @IdUsuario
end