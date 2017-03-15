use UnimarketDB
go
Excluir AtualizarSenha
go
create procedure AtualizarSenha(
	@IdUsuario int,
	@Senha varchar(50)
	)
as
begin
	update Usuario set 
	senha = @Senha
	where (Usuario.Id = @IdUsuario)
end