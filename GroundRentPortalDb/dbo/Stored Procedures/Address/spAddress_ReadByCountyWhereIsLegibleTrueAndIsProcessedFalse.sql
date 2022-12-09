CREATE PROCEDURE [dbo].[spAddress_ReadByCountyWhereIsLegibleTrueAndIsProcessedFalse]
@UnprocessedAddressListAmount smallint,
@County NCHAR(16)

as
begin
select top (@UnprocessedAddressListAmount) 
[AccountId],
[IsLegible],
[IsProcessed],
[IsVerified],
[NotLegibleType],
[PaymentAmount],
[PaymentFrequency],
[PaymentDateAnnual],
[PaymentDateSemiAnnual1],
[PaymentDateSemiAnnual2],
[PaymentDateQuarterly1],
[PaymentDateQuarterly2],
[PaymentDateQuarterly3],
[PaymentDateQuarterly4],
[PaymentDateOther],
[UserWhoProcessed],
[UserWhoVerified]
	
from dbo.[Address] 
where [County] = @County and [IsLegible] = 1 and [IsProcessed] = 0
end