use unimarket
if OBJECT_ID('CancelarConta') is not null
drop procedure CancelarConta
go
create procedure CancelarConta (
	@IdUsuario int
	)
as
begin
	begin try
		begin tran
			update Usuario
			set Usuario.IdStatusUsuario = 4
			where Usuario.Id = @IdUsuario
			update Item
			set Item.Desabilitado='true'
			where Item.IdUsuario = @IdUsuario
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end