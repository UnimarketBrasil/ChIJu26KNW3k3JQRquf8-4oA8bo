use unimarket
go
Excluir DetalheUsuario
go
create procedure DetalheUsuario(
	@IdUsuario int
	)
as	
begin
	select Usuario.Email, Usuario.Nome, Usuario.Sobrenome, Usuario.CpfCnpj, Usuario.Nascimento, Usuario.Genero, 
	Usuario.Telefone, TipoUsuario.Nome as TipoUsuario, StatusUsuario.Nome as StatusUsuario,  
	Usuario.Latitude, Usuario.Longitude, Usuario.Complemento, Usuario.AreaAtuacao, (
	select COUNT(*) from Item where IdUsuario=@IdUsuario and Desabilitado=0) as QtdadeItens, (
	select COUNT(*) from Pedido where IdVendedor=@IdUsuario and IdStatusPedido=1) as PedidosPendente, (
	select COUNT(*) from Pedido where IdVendedor=@IdUsuario and IdStatusPedido=2) as PedidosFinalizado, (
	select COUNT(*) from Pedido where IdVendedor=@IdUsuario and IdStatusPedido=3) as PedidosCancelado
	from Usuario
	inner join StatusUsuario on StatusUsuario.Id = Usuario.IdStatusUsuario
	inner join TipoUsuario on TipoUsuario.Id = Usuario.IdTipoUsuario
	where (Usuario.Id = @IdUsuario)
end