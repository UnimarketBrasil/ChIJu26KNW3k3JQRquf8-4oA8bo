use unimarket
go
Excluir AtualizarUsuarioPF
go
create  procedure AtualizarUsuarioPF(
	@IdUsuario int,
	@Email varchar(50),
	@Nome varchar(50),
	@Sobrenome varchar(50),
	@Genero smallint,
	@Nascimento Date,
	@Telefone varchar(15),
	@Latitude int,
	@Longitude int,
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
			Sobrenome = @Sobrenome,
			Genero = @Genero,
			Nascimento = @Nascimento,
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
	
