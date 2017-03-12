use UnimarketDB
go
Excluir CarragarAdmistrador
go
create procedure CarragarAdmistrador(
	@IdAdministrador int
	)
as	
begin
	select Email, Nome, Telefone, Latitude, Longitude, Complemento, AreaAtuacao from Adminstrador
	where (Adminstrador.Id = @IdAdministrador)
end