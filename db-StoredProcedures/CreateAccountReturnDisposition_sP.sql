SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateAccountReturnDisposition]
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

SELECT TOP 1 * FROM Dispositions as d
INNER JOIN Accounts AS a ON a.AccountId = d.AccountId
INNER JOIN Customers AS c on d.CustomerId = c.CustomerId
INNER JOIN [User] AS u on u.UserId = d.UserId
WHERE d.UserId = @userId
ORDER by d.AccountId DESC;

END
GO
