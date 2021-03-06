use unimarket
if OBJECT_ID('IncluirEndereco') is not null
drop procedure IncluirEndereco
go
create procedure IncluirEndereco(
	@IdUsuario int,
	@Longitude bigint,
	@Latitude bigint,
	@AreaAtuacao real = null,
	@Complemento varchar(255)
	)
as
begin
	begin try
		begin tran
			update Usuario
			set
			Usuario.Longitude = @Longitude,
			Usuario.Latitude = @Latitude,
			Usuario.AreaAtuacao = @AreaAtuacao,
			Usuario.Complemento = @Complemento,
			Usuario.IdStatusUsuario = 1
			where (Usuario.Id = @IdUsuario)
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end