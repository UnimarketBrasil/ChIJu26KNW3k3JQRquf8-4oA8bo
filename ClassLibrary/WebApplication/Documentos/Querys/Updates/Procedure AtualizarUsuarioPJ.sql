use unimarket
go
Excluir AtualizarUsuarioPJ
go
create  procedure AtualizarUsuarioPJ(
	@IdUsuario int,
	@Email varchar(50),
	@Nome varchar(50),
	@Telefone varchar(15),
	@Latitude varchar(20),
	@Longitude varchar(20),
	@Complemento text,
	@AreaAtuacao real,
	@IdTipoUsuario int
	)
as
begin
	begin try
		begin tran
			update Usuario set
			Email = @Email,
			Nome = @Nome,
			Telefone = @Telefone,
			Latitude = @Latitude,
			Longitude = @Longitude,
			Complemento = @Complemento,
			AreaAtuacao = @AreaAtuacao,
			IdTipoUsuario = @IdTipoUsuario
			where ( Id = @IdUsuario )
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
	
