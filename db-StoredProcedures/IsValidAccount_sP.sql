SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IsValidAccount](@AccountId int)
AS
BEGIN
  SELECT COUNT(*) FROM Accounts
    WHERE AccountId = @AccountId

END
GO
