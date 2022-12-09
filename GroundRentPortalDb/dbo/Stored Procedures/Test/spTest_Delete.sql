CREATE PROCEDURE [dbo].[spTest_Delete]
	@AccountId nchar(16)
AS
BEGIN
	DELETE FROM dbo.[Test] WHERE AccountId = @AccountId;
END