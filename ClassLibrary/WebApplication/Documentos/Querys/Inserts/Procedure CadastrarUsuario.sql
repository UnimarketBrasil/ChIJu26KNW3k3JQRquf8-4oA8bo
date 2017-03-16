use UnimarketDB
go
Excluir CadastrarUsuario
go
create procedure CadastrarUsuario(
	@Email varchar (50),
	@Nome varchar(50),
	@Sobrenome varchar(50),
	@Senha varchar(50),
	@CpfCnpj varchar(20),
	@Nascimento datetime,
	--@Genero smallint, *GENERO N�O � OBRIGATORIO NO CADASTRO DE PESSOA JUR�DICA
	@Telefone varchar(15),
	@IdTipoUsuario int
	)
as 
begin
	 insert into Usuario( Email, Nome, Sobrenome, Senha, CpfCnpj, Nascimento, Telefone, IdTipoUsuario) 
	 values(
	 @Email,
	 @Nome,
	 @Sobrenome,
	 @Senha,
	 @CpfCnpj,
	 @Nascimento,
	 --@Genero, *GENERO N�O � OBRIGATORIO NO CADASTRO DE PESSOA JUR�DICA
	 @Telefone,
	 @IdTipoUsuario
	 )
end
 

