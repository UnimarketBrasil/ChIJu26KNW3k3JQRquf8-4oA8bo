use unimarket
go
create procedure DesabilitarItemPorId(
	@IdItem int
	)
as
begin
	begin try
		begin tran
			update Item
			set Desabilitado = 'true'
			where Item.Id = @IdItem
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end