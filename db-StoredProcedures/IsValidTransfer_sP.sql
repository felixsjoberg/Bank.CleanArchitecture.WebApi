SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IsValidTransfer](@AccountId int ,@UserId UNIQUEIDENTIFIER)
AS
BEGIN
  SELECT COUNT(*) FROM Dispositions
    WHERE UserId = @UserId AND AccountId = @AccountId

END
GO
