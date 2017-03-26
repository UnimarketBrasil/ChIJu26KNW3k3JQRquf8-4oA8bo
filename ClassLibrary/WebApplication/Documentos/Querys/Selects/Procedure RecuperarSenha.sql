use unimarket
go
Excluir Recuperarsenha
go
create procedure Recuperarsenha(
	@Email int
	)
as
	declare @Retorno bit
begin
	if exists ( select Usuario.Id from Usuario where Usuario.Email = @Email)	
		set @Retorno = 'true'
	else
		set @Retorno = 'false'
end