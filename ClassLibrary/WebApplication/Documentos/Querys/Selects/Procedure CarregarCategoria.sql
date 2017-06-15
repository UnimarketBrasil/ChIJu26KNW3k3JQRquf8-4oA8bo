use unimarket
if OBJECT_ID('CarregarCategoria') is not null
drop procedure CarregarCategoria
go
create procedure CarregarCategoria
as	
begin
	Select * from Categoria
end