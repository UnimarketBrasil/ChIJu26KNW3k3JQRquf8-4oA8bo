use unimarket
go
if exists ( select name FROM sys.objects where (type in ('FN')) and (name = 'CalculoDistancia')) drop function CalculoDistancia
go
create function CalculoDistancia(
	 @LatitudeVendedor int,
	 @LongitudeVendedor int,
	 @LatitudeComprador int,
	 @LongitudeComprador int
	 )
returns real
as
begin 
	return sqrt( power( @LatitudeVendedor - @LatitudeComprador, 2) + power(@LongitudeVendedor - @LongitudeComprador, 2));
end



