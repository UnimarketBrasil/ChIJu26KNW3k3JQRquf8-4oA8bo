use unimarket
if OBJECT_ID('Top3Itens') is not null
drop procedure Top3Itens
go
create procedure Top3Itens
as
begin
	select top(3) Item.Id, Item.Nome, Item.ValorUnitario, Item.IdUsuario from ItemPedido
	inner join Pedido on ItemPedido.IdPedido = Pedido.Id
	inner join Item on ItemPedido.IdItem = Item.Id
	where Pedido.IdStatusPedido=2
	order by  ItemPedido.Quantidade desc
end