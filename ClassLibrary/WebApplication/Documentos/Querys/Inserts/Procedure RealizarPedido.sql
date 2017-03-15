use UnimarketDB
go
Excluir RealizarPedido
go
--Falta incluir a funcionalidade de baixa na quantidade ao realizar pedido.
create procedure RealizarPedido(
	@CodigoPedido varchar(50),
	@IdVendedor int,
	@IdComprador int,
	@IdStatusPedido int
	)
as begin
	insert into Pedido(
		Codigo,
		IdVendedor,
		IdComprador,
		IdStatusPedido
		)  output inserted.Id values (
		@CodigoPedido,
		@IdVendedor,
		@IdComprador,
		@IdStatusPedido
		);return
end

go
Excluir CadastrarItemPedido
go
Create procedure CadastrarItemPedido(
	@IdPedido int,
	@IdItem int,
	@Quantidade varchar(20)
	)
as
begin
--Validar se existe quantidade disponível
	insert into ItemPedido( 
	Quantidade, 
	IdItem,	
	IdPedido
	) values (
	@Quantidade, 
	@IdItem, 
	@IdPedido
	)		
end