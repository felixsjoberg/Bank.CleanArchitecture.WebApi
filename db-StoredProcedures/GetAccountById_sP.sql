SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create the stored procedure in the specified schema
CREATE PROCEDURE [dbo].[GetAccountById](@AccountId int)
AS
BEGIN
  SELECT * FROM Accounts
  INNER JOIN Transactions ON Accounts.AccountId = Transactions.AccountId
  where Accounts.AccountId = @AccountId;

END
GO
