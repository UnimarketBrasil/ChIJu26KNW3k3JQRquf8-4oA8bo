use UnimarketDB
go
Excluir CadastrarAdministrador
go
create procedure CadastrarUsuario(
	@Email varchar (50),
	@Nome varchar(50),
	@Senha varchar(50),
	@CpfCnpj varchar(20),
	@Nascimento datetime,
	@Genero int,
	@Telefone varchar(15),
	@IdTipoUsuario int
	)
as 
begin
	 insert into Administrador( Email, Nome, Senha, CpfCnpj, Nascimento, Genero, Telefone, IdTipoUsuario) 
	 values(
	 @Email,
	 @Nome,
	 @Senha,
	 @CpfCnpj,
	 @Nascimento,
	 @Genero,
	 @Telefone,
	 @IdTipoUsuario
	 )
end
 

