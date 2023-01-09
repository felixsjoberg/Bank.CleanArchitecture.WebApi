SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateAccount]
    @customerId int,
    @userId UNIQUEIDENTIFIER,
    @frequency NVARCHAR(50),
    @accountTypesId INT

AS
BEGIN
    DECLARE @accountId INT;


    INSERT INTO [dbo].[Accounts]
(
 [Frequency], Created,AccountTypesId
)
VALUES
(
 @frequency, CURRENT_TIMESTAMP ,@accountTypesId
)

SET @accountId = SCOPE_IDENTITY();

    INSERT INTO [dbo].[Dispositions]
( 
 CustomerId,AccountId,UserId,[Type]
)
VALUES
( 
 @customerId, @accountId ,@userId, 'Owner'
)

SELECT TOP 1 *
FROM Accounts
WHERE AccountId = @accountId
ORDER by AccountId DESC;

END
GO
