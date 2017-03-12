use Unimarketdb
go
Excluir BloquearAdministrador
go
create procedure BloquearAdministrador(
	@IdAdminstrador int
	)
as
begin
	update Adminstrador
	set Adminstrador.IdStatusUsuario = 3
	where Adminstrador.Id = @IdAdminstrador
end