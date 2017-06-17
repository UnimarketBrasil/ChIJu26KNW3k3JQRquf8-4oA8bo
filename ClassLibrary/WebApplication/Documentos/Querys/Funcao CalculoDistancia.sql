use unimarket
go
if exists ( select name FROM sys.objects where (type in ('FN')) and (name = 'CalculoDistancia')) drop function CalculoDistancia
go
create function CalculoDistancia(
	 @LatitudeVendedor float,
	 @LongitudeVendedor float,
	 @LatitudeComprador float,
	 @LongitudeComprador float
	 )
returns float
as
begin
declare @Retorno int
	if(abs(@LatitudeComprador - @LatitudeVendedor) > abs(@LongitudeComprador - @LongitudeVendedor))
	begin
		if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor > 0)
		 	set @Retorno = (abs(@LatitudeComprador - @LatitudeVendedor) / cos(atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
		if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor < 0)
		 	set @Retorno = (abs(@LatitudeComprador - @LatitudeVendedor) / cos(180 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
		if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor < 0)
			set @Retorno =  (abs(@LatitudeComprador - @LatitudeVendedor) / cos(180 + atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
		if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor > 0)
		 	set @Retorno = (abs(@LatitudeComprador - @LatitudeVendedor) / cos(360 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	end
	else
		if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor > 0)
			set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
		if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor < 0)
		 	set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(180 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
		if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor < 0)
		 	set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(180 + atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
		if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor > 0)
		 	set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(360 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	return @Retorno / 10000
end		
		----return ( sqrt( exp((convert(float, @LatitudeComprador)) - (convert(float, @LatitudeVendedor))) + exp((convert(float, @LongitudeComprador)) - (convert(float, @LongitudeVendedor)))))
----return sqrt(square(@LatitudeVendedor - @LatitudeComprador) + square(@LongitudeVendedor - @LongitudeComprador))
--return convert(varchar, sqrt(square(abs(@LatitudeVendedor) - abs(@LatitudeComprador)) + square(abs(@LongitudeVendedor) - abs(@LongitudeComprador))) )
--end

