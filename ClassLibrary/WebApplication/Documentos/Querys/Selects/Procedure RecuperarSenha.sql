use unimarket
go
Excluir Recuperarsenha
go
create procedure Recuperarsenha(
	@Email int
	)
as
begin
	if exists ( select Usuario.Id from Usuario where Usuario.Email = @Email)	
		print 'true'
	else
		print 'false'
end