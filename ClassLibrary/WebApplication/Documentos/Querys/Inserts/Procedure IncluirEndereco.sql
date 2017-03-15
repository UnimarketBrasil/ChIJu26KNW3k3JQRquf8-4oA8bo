use UnimarketDB
go
Excluir IncluirEndereco
go
create procedure IncluirEndereco(
	@IdUsuario int,
	@Longitude bigint,
	@Latitude bigint,
	@AreaAtuacao real,
	@Complemento varchar(255)
	)
as
begin
	update Usuario
	set
	Usuario.Longitude = @Longitude,
	Usuario.Latitude = @Latitude,
	Usuario.AreaAtuacao = @AreaAtuacao,
	Usuario.Complemento = @Complemento,
	Usuario.IdStatusUsuario = 1
	where (Usuario.Id = @IdUsuario)
end