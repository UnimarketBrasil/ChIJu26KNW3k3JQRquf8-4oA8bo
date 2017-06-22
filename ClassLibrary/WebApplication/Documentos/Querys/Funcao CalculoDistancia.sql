use unimarket
go
if exists ( select name FROM sys.objects where (type in ('FN')) and (name = 'CalculoDistancia')) drop function CalculoDistancia
go
create function CalculoDistancia(
	 @LatV varchar(20),
	 @LongV varchar(20),
	 @LatC varchar(20),
	 @LongC varchar(20)
	 )
returns float
as
	
begin
	declare @Retorno float
	declare @LatitudeVendedor float
	declare @LongitudeVendedor float
	declare @LatitudeComprador float
	declare @LongitudeComprador float
	set @LatV = replace(@LatV,'.','')
	set @LatV = replace(@LatV,',','.')
	set @LongV = replace(@LongV,'.','')
	set @LongV = replace(@LongV,',','.')
	set @LatC = replace(@LatC,'.','')
	set @LatC = replace(@LatC,',','.')
	set @LongC = replace(@LongC,'.','')
	set @LongC = replace(@LongC,',','.')	
	set @LatitudeVendedor = convert(float, @LatV)
	set @LongitudeVendedor = convert(float, @LongV)
	set @LatitudeComprador = convert(float, @LatC)
	set @LongitudeComprador = convert(float, @LongC)
	--if(abs(@LatitudeComprador - @LatitudeVendedor) > abs(@LongitudeComprador - @LongitudeVendedor))
	--begin
	--	if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor > 0)
	--	 	set @Retorno = (abs(@LatitudeComprador - @LatitudeVendedor) / cos(atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--	if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor < 0)
	--	 	set @Retorno = (abs(@LatitudeComprador - @LatitudeVendedor) / cos(180 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--	if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor < 0)
	--		set @Retorno =  (abs(@LatitudeComprador - @LatitudeVendedor) / cos(180 + atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--	if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor > 0)
	--	 	set @Retorno = (abs(@LatitudeComprador - @LatitudeVendedor) / cos(360 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--end
	--else
	--	if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor > 0)
	--		set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--	if(@LatitudeComprador - @LatitudeVendedor > 0 and @LongitudeComprador - @LongitudeVendedor < 0)
	--	 	set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(180 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--	if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor < 0)
	--	 	set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(180 + atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--	if(@LatitudeComprador - @LatitudeVendedor < 0 and @LongitudeComprador - @LongitudeVendedor > 0)
	--	 	set @Retorno = (abs(@LongitudeComprador - @LongitudeVendedor) / cos(360 - atan(abs(@LatitudeComprador - @LatitudeVendedor)/abs(@LongitudeComprador - @LongitudeVendedor))) )
	--return @Retorno / 10000
	return (sqrt(power(@LatitudeVendedor - @LatitudeComprador,2) + power(@LongitudeVendedor - @LongitudeComprador,2)) /100)
end		
		----return ( sqrt( exp((convert(float, @LatitudeComprador)) - (convert(float, @LatitudeVendedor))) + exp((convert(float, @LongitudeComprador)) - (convert(float, @LongitudeVendedor)))))
----return sqrt(square(@LatitudeVendedor - @LatitudeComprador) + square(@LongitudeVendedor - @LongitudeComprador))
--end

