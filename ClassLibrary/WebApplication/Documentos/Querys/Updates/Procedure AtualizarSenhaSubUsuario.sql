use UnimarketDB
go
Excluir AlterarSenhaSubUsuario
go
create procedure AlterarSenhaSubUsuario(
	@IdUsuario int,
	@Senha varchar(50)
	)
as
begin
	update Usuario set
	Usuario.Senha = @Senha
	where (Usuario.Id = @IdUsuario)
end