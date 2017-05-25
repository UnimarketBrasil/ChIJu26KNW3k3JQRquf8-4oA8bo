use unimarket
if OBJECT_ID('CadastrarUsuario') is not null
drop procedure CadastrarUsuario
go
create procedure CadastrarUsuario(
	@Email varchar (50),
	@Nome varchar(50),
	@Sobrenome varchar(50) = null,
	@Senha varchar(50),
	@HashConfirmacao varchar(50),
	@CpfCnpj varchar(20),
	@Nascimento datetime,
	@Genero smallint = null,
	@Telefone varchar(15),
	@Longitude varchar(20),
	@Latitude varchar(20),
	@CEP varchar(8),
	@Numero int,
	@Complemento varchar(20) = null,
	@AreaAtuacao real =null,
	@IdTipoUsuario int,
	@UltimoAcesso datetime
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
			 HashConfirmacao,
			 CpfCnpj,
			 Nascimento, 
			 Genero, 
			 Telefone,
			 Longitude,
			 Latitude,
			 CEP,
			 Numero,
			 Complemento,
			 AreaAtuacao,
			 IdTipoUsuario,
			 UltimoAcesso
			 ) output inserted.Id values(
			 @Email,
			 @Nome,
			 @Sobrenome,
			 @Senha,
			 @HashConfirmacao,
			 @CpfCnpj,
			 @Nascimento,
			 @Genero,
			 @Telefone,
			 @Longitude,
			 @Latitude,
			 @CEP,
			 @Numero,
			 @Complemento,
			 @AreaAtuacao,
			 @IdTipoUsuario,
			 @UltimoAcesso
			 )
			 select Usuario.Email from Usuario where Email=@Email
		commit tran
	end try
	begin catch
		rollback tran
	end catch 
end
 

