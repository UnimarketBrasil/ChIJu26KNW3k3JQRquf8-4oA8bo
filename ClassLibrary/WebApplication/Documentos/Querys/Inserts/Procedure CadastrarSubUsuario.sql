use UnimarketDB
go
Excluir CadastrarSubUsuario
go
create procedure CadastrarSubUsuario(
	@Nome varchar(50),
	@Email varchar(50),
	@Senha varchar(50),
	@IdUsuario int
	)
as
begin
	insert into SubUsuario (
	Nome,
	Email,
	Senha,
	IdUsuario
	) 
	values(
	@Nome,
	@Email,
	@Senha,
	@IdUsuario
	)
end