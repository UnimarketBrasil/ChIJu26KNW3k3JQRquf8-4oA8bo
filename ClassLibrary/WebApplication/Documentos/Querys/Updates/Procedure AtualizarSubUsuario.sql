use UnimarketDB
go
Excluir AtualizarSubUsuario
go
create procedure AtualizarSubUsuario(
	@IdSubUsuario int,
	@Nome varchar(50),
	@Email varchar(50),
	@Senha varchar(50)
	)
as
begin
	begin try
		begin tran
			update SubUsuario set
			SubUsuario.Nome = @Nome,
			SubUsuario.Email = @Email
			where (SubUsuario.Id = @IdSubUsuario)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end