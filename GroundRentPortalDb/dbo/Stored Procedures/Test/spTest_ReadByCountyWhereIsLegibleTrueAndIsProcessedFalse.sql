CREATE PROCEDURE [dbo].[spTest_ReadByCountyWhereIsLegibleTrueAndIsProcessedFalse]
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
[GroundRentPaymentFrequency],
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
	
from dbo.[Test] 
where [County] = @County and [IsProcessed] is null and ([IsLegible] = 1 or [IsLegible] is null)
end