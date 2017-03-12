use UnimarketDB
go
Excluir AtualizarSenha
go
create procedure AtualizarSenha(
	@IdAdminstrador int,
	@Senha varchar(50)
	)
as
begin
	update Administrador set 
	senha = @Senha
	where (Administrador.Id = @IdAdminstrador)
end