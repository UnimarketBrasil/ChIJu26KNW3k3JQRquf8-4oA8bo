use unimarket
go
create procedure ConfirmarCadastro(
	@HashConfirmacao varchar(50)
	)
as begin
	begin try
		begin tran
			declare @id table (id int);

			update Usuario set IdStatusUsuario='1' output inserted.Id into @id where IdStatusUsuario='2' 
			and HashConfirmacao=@HashConfirmacao 
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
