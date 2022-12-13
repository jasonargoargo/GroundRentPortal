CREATE PROCEDURE [dbo].[spTest_ReadByAccountId]
@AccountId NCHAR (16)

as
begin
select *
from dbo.[Test] 
where [AccountId] = @AccountId
end