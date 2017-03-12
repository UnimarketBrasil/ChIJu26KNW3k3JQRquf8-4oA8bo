use UnimarketDB
go
Excluir IncluirEndereco
go
create procedure IncluirEndereco(
	@IdAdministrador int,
	@Longitude bigint,
	@Latitude bigint,
	@AreaAtuacao real,
	@Complemento varchar(255)
	)
as
begin
	update Administrador
	set
	Administrador.Longitude = @Longitude,
	Administrador.Latitude = @Latitude,
	Administrador.AreaAtuacao = @AreaAtuacao,
	Administrador.Complemento = @Complemento,
	Administrador.IdStatusUsuario = 1
	where (Administrador.Id = @IdAdministrador)
end