SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTransactionsByAccId](
    @userId UNIQUEIDENTIFIER,
    @accountId int)
AS
BEGIN
  

SELECT *
FROM Dispositions AS d
INNER JOIN Transactions AS t ON t.AccountId = d.AccountId
WHERE d.UserId = @UserId and d.AccountId = @AccountId

END
GO
