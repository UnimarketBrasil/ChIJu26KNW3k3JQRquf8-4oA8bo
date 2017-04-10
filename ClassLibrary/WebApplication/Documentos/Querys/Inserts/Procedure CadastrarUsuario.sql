use unimarket
go
Excluir CadastrarUsuario
go
create procedure CadastrarUsuario(
	@Email varchar (50),
	@Nome varchar(50),
	@Sobrenome varchar(50) = null,
	@Senha varchar(50),
	@CpfCnpj varchar(20),
	@Nascimento datetime,
	@Genero smallint = null,
	@Telefone varchar(15),
	@Longitude varchar(20),
	@Latitude varchar(20),
	@Complemento varchar(20) = null,
	@AreaAtuacao real =null,
	@IdTipoUsuario int
	)
as 
begin
	begin try
		begin tran
			insert into Usuario( 
			 Email,
			 Nome,
			 Sobrenome,
			 Senha, 
			 CpfCnpj,
			 Nascimento, 
			 Genero, 
			 Telefone,
			 Longitude,
			 Latitude,
			 Complemento,
			 AreaAtuacao,
			 IdTipoUsuario
			 ) 
			 values(
			 @Email,
			 @Nome,
			 @Sobrenome,
			 @Senha,
			 @CpfCnpj,
			 @Nascimento,
			 @Genero,
			 @Telefone,
			 @Longitude,
			 @Latitude,
			 @Complemento,
			 @AreaAtuacao,
			 @IdTipoUsuario
			 )
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
 

