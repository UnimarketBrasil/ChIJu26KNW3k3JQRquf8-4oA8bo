create procedure RelatorioItem(
	@IdVendedor int
	)
as
begin
	with Itens (IdItem, QuantidadeItens) as
	(select IdItem, sum(Quantidade) as QuantidadeItens from ItemPedido group by idItem)

	select QuantidadeItens, Itens.IdItem, Item.Nome from Itens
	inner join Item on Item.Id = IdItem
end
go
create procedure RelatorioPedidos(
	@IdVendedor int,
	@DataInicio date,
	@DataFinal date
)
as
begin
	with Pedidos (Id, DataPedido) as
	(select Pedido.Id, Pedido.Data as DataPedido from Pedido
	 where IdVendedor = @IdVendedor and Pedido.Data <= @DataFinal and Pedido.Data >= @DataInicio and Pedido.IdStatusPedido = 2),
	 Itens (TotalItem, DataPedido) as
	(select ItemPedido.Quantidade*ItemPedido.ValorUnitario as TotalItem, DataPedido from Pedidos
	inner join ItemPedido on ItemPedido.IdPedido =  Pedidos.id)
	
	select sum(TotalItem) as ValorTotal,  cast(DataPedido as Date) as Data from Itens
	group by cast(DataPedido as Date)
end