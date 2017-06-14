use unimarket
if OBJECT_ID('BloquearUsuario') is not null
drop procedure BloquearUsuario
go
create procedure BloquearUsuario(
	@IdUsuario int
	)
as
begin
	begin try
		begin tran
			update Usuario
			set Usuario.IdStatusUsuario = 3
			where Usuario.Id = @IdUsuario
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end