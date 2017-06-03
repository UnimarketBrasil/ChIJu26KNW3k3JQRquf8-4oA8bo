use unimarket
go
if exists ( select name FROM sys.objects where (type in ('FN')) and (name = 'CalculoDistancia')) drop function CalculoDistancia
go
create function CalculoDistancia(
	 @LatitudeVendedor varchar(20),
	 @LongitudeVendedor varchar(20),
	 @LatitudeComprador varchar(20),
	 @LongitudeComprador varchar(20)
	 )
returns real
as
begin 
	return sqrt( power(convert(float, @LatitudeComprador) - convert(float, @LatitudeVendedor), 2) + power( convert(float, @LongitudeComprador) -  convert(float, @LongitudeVendedor), 2))
end

