use UnimarketDB
go
Excluir CadastrarSubUsuario
go
create procedure CadastrarSubUsuario(
	@IdUsuario int,
	@Nome varchar(50),
	@Email varchar(50),
	@Senha varchar(50)
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