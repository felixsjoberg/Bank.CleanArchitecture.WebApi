SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerIdDispostion]
    @userId UNIQUEIDENTIFIER
AS
BEGIN
    
SELECT TOP 1 CustomerId from Dispositions
WHERE UserId = @userId
    
END
GO
