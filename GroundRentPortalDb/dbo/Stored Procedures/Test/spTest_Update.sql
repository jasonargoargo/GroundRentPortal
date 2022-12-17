﻿CREATE PROCEDURE [dbo].[spTest_Update]
	@AccountId  NCHAR (16),
    @IsProcessed BIT,
    @IsVerified BIT,
    @IsLegible BIT,
    @NotLegibleType NCHAR(32),
    @DataDifferencesJson NVARCHAR(2048),
    @PaymentAmount DECIMAL(7,2),
    @GroundRentPaymentFrequency NCHAR(16),
    @PaymentDateAnnual SMALLDATETIME,
    @PaymentDateSemiAnnual1 SMALLDATETIME,
    @PaymentDateSemiAnnual2 SMALLDATETIME,
    @PaymentDateQuarterly1 SMALLDATETIME,
    @PaymentDateQuarterly2 SMALLDATETIME,
    @PaymentDateQuarterly3 SMALLDATETIME,
    @PaymentDateQuarterly4 SMALLDATETIME,
    @PaymentDateOther NVARCHAR(128),
    @UserWhoProcessed NVARCHAR(64),
    @UserWhoVerified NVARCHAR(64)

AS
begin
	set nocount on;

	update dbo.[Test] set
	[AccountId] = @AccountId,
    [IsProcessed] = @IsProcessed,
    [IsVerified] = @IsVerified,
    [IsLegible] = @IsLegible,
    [NotLegibleType] = @NotLegibleType,
    [DataDifferencesJson] = @DataDifferencesJson,
    [PaymentAmount] = @PaymentAmount,
    [GroundRentPaymentFrequency] = @GroundRentPaymentFrequency,
    [PaymentDateAnnual] = @PaymentDateAnnual,
    [PaymentDateSemiAnnual1] = @PaymentDateSemiAnnual1,
    [PaymentDateSemiAnnual2] = @PaymentDateSemiAnnual2,
    [PaymentDateQuarterly1] = @PaymentDateQuarterly1,
    [PaymentDateQuarterly2] = @PaymentDateQuarterly2,
    [PaymentDateQuarterly3] = @PaymentDateQuarterly3,
    [PaymentDateQuarterly4] = @PaymentDateQuarterly4,
    [PaymentDateOther] = @PaymentDateOther,
    [UserWhoProcessed] = @UserWhoProcessed,
    [UserWhoVerified] = @UserWhoVerified

	where AccountId = @AccountId
end