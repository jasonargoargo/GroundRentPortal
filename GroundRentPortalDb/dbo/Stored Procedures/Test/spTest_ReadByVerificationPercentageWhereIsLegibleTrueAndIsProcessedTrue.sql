﻿CREATE PROCEDURE [dbo].[spTest_ReadByVerificationPercentageWhereIsLegibleTrueAndIsProcessedTrue]
@UnverifiedAddressListAmount smallint

as
begin
select top (@UnverifiedAddressListAmount) 
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
where [IsProcessed] = 1 and [IsVerified] is null
end