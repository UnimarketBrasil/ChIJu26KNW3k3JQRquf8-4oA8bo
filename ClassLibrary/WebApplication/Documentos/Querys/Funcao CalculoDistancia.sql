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
	return sqrt( power(convert(float, @LatitudeVendedor) - convert(float, @LatitudeComprador), 2) + power( convert(float, @LongitudeVendedor) -  convert(float, @LongitudeComprador), 2))
end

