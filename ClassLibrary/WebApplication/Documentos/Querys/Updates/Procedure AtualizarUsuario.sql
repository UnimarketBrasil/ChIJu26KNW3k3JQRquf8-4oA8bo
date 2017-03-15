use UnimarketDB
go
Excluir AtualizarUsuario
go
create  procedure AtualizarUsuario(
	@IdUsuario int,
	@Email varchar(50),
	@Nome varchar(50),
	@Telefone varchar(15),
	@Latitude int,
	@Longitude int,
	@Complemento text,
	@AreaAtuacao real
	)
as
begin
	update administrador set
	Email = @Email,
	Nome = @Nome,
	Telefone = @Telefone,
	Latitude = @Latitude,
	Longitude = @Longitude,
	Complemento = @Complemento,
	AreaAtuacao = @AreaAtuacao
	where ( Id = @IdUsuario )
end
	
