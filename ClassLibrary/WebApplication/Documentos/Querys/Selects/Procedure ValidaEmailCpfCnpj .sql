use unimarket
if OBJECT_ID('ValidaEmailCpfCnpj') is not null
drop procedure ValidaEmailCpfCnpj
go
create procedure ValidaEmailCpfCnpj (
	@Email varchar(50),
	@CpfCnpj varchar(50)
	)
as
if exists(select Usuario.Id from Usuario where (Usuario.Email = @Email and Usuario.CpfCnpj= @CpfCnpj))
	begin
		select Usuario.Id, Usuario.Email, Usuario.CpfCnpj, 'Email_CpfCnpj' as 'Existe' from Usuario where (Usuario.Email = @Email and Usuario.CpfCnpj= @CpfCnpj)
	end
	else if exists(select Usuario.Id from Usuario where (Usuario.Email = @Email))
		select Usuario.Id, Usuario.Email, Usuario.CpfCnpj, 'Email' as 'Existe' from Usuario where (Usuario.Email = @Email)
	else if exists(select Usuario.Id from Usuario where (Usuario.CpfCnpj = @CpfCnpj))
		select Usuario.Id, Usuario.Email, Usuario.CpfCnpj, 'CpfCnpj' as 'Existe' from Usuario where (Usuario.CpfCnpj = @CpfCnpj)
