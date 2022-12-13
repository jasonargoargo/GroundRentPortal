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
[NotVerifiedType],
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
	
from dbo.[Test] 
where [County] = @County and [IsLegible] = 1 and ([IsProcessed] = 0 or [IsProcessed] is null)
end