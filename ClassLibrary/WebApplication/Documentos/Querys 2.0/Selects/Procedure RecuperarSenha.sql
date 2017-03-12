use UnimarketDB
go
Excluir Recuperarsenha
go
create procedure Recuperarsenha(
	@Email int
	)
as
begin
	if exists ( select Admisntrador.Id from Admisntrador where Admisntrador.Email = @Email)	
		print 'true'
	else
		print 'false'
end