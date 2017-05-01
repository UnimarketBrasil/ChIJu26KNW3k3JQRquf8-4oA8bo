use unimarket
go
Excluir CadastrarItem
go
create procedure CadastrarItem(
	@Codigo varchar(50),
	@Nome varchar(50),
	@Descricao text,
	@ValorUnitario real,
	@Quantidade varchar(50),
	@IdCategoria int,
	@IdUsuario int
	)
as begin
	begin try
		begin tran
			insert into Item (
			Codigo,
			Nome,
			Descricao,
			ValorUnitario,
			Quantidade,
			IdCategoria,
			IdUsuario
			) output inserted.Id values (
			@Codigo,
			@Nome,
			@Descricao,
			@ValorUnitario,
			@Quantidade,
			@IdCategoria,
			@IdUsuario
			)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
