use unimarket
if OBJECT_ID('DesbloquearUsuario') is not null
drop procedure DesbloquearUsuario
go
create procedure DesbloquearUsuario (
	@IdUsuario int
	)
as
begin
	begin try
		begin tran
			update Usuario
			set Usuario.IdStatusUsuario = 1
			where Usuario.Id = @IdUsuario
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end