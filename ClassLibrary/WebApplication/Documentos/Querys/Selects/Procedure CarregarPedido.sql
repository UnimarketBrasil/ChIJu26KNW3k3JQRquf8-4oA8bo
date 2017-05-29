use unimarket
if OBJECT_ID('CarregarPedidoComprador') is not null
drop procedure CarregarPedidoComprador
go
if OBJECT_ID('CarregarPedidoVendedor') is not null
drop procedure CarregarPedidoVendedor
go
if OBJECT_ID('CarregarItemPedido') is not null
drop procedure CarregarItemPedido
go
create procedure CarregarPedidoComprador(
	@IdPedido int,
	@IdComprador int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Vendedor.Id as IdVendedor ,Vendedor.Nome as Vendedor, Vendedor.Telefone, Vendedor.Email,
	Vendedor.Latitude as LatVendedor, Vendedor.Longitude as LongVendedor, Vendedor.Numero as NumVendedor, Vendedor.Complemento as ComplVendedor,
	Comprador.Nome as Comprador, Comprador.Latitude as LatComprador, Comprador.Longitude LongComprador, Comprador.Numero as NumComprador, Comprador.Complemento as ComplComprador,
	Data, StatusPedido.Nome as Status, (
	select SUM(ValorUnitario) from ItemPedido where IdPedido=Pedido.Id) as Valor
	from Pedido
	inner join Usuario as Vendedor on Vendedor.Id = Pedido.IdVendedor
	inner join Usuario as Comprador on Comprador.Id = Pedido.IdComprador
	inner join StatusPedido on StatusPedido.Id = Pedido.IdStatusPedido
	where Pedido.Id=@IdPedido and Pedido.IdComprador=@IdComprador
end
go
create procedure CarregarPedidoVendedor(
	@IdPedido int,
	@IdVendedor int
	)
as
begin
	select Pedido.Id, Pedido.Codigo, Vendedor.Id as IdVendedor ,Vendedor.Nome as Vendedor, 
	Vendedor.Latitude as LatVendedor, Vendedor.Longitude as LongVendedor, Vendedor.Numero as NumVendedor, Vendedor.Complemento as ComplVendedor,
	Comprador.Nome as Comprador, Comprador.Telefone, Comprador.Email, Comprador.Latitude as LatComprador, Comprador.Longitude LongComprador, Comprador.Numero as NumComprador, Comprador.Complemento as ComplComprador,
	Data, StatusPedido.Nome as Status, (
	select SUM(ValorUnitario) from ItemPedido where IdPedido=Pedido.Id) as Valor
	from Pedido
	inner join Usuario as Vendedor on Vendedor.Id = Pedido.IdVendedor
	inner join Usuario as Comprador on Comprador.Id = Pedido.IdComprador
	inner join StatusPedido on StatusPedido.Id = Pedido.IdStatusPedido
	where Pedido.Id=@IdPedido and Pedido.IdVendedor=@IdVendedor
end
go
create procedure CarregarItemPedido(
	@IdPedido int
	)
as 
begin
	select Item.Id, Item.Nome, ItemPedido.Quantidade, Item.ValorUnitario, ItemPedido.Quantidade * ItemPedido.ValorUnitario as ValorTotal
	from ItemPedido
	inner join Item on Item.Id = ItemPedido.IdItem
	where (ItemPedido.IdPedido = @IdPedido) 
end
go

