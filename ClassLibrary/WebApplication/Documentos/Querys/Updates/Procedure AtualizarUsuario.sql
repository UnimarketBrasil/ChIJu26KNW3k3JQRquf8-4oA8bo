use unimarket
go
create  procedure AtualizarUsuario(
	@IdUsuario int,
	@Email varchar(50),
	@Nome varchar(50),
	@Sobrenome varchar(50) = null,
	@Telefone varchar(15),
	@Latitude varchar(20),
	@Longitude varchar(20),
	@Complemento text,
	@Numero int,
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
			Sobrenome = @Sobrenome,
			Telefone = @Telefone,
			Latitude = @Latitude,
			Longitude = @Longitude,
			Complemento = @Complemento,
			Numero = @Numero,
			AreaAtuacao = @AreaAtuacao,
			IdTipoUsuario = @IdTipoUsuario
			where ( Id = @IdUsuario )
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
	
