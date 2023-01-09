SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccounts](@userId UNIQUEIDENTIFIER)
AS
BEGIN

SELECT *
FROM Dispositions AS d
INNER JOIN Accounts AS a ON a.AccountId = d.AccountId
WHERE d.UserId = @userId

END
GO
