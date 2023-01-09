SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateCustomer]
    @Gender NVARCHAR(50),
    @Givenname NVARCHAR(50),
    @Surname NVARCHAR(50),  
    @Streetaddress NVARCHAR(50),
    @City NVARCHAR(50),
    @Zipcode NVARCHAR(50),
    @Country NVARCHAR(50),
    @CountryCode NVARCHAR(50),
    @Birthday DATETIME,
    @Telephonecountrycode NVARCHAR(50),
    @Telephonenumber NVARCHAR(50),
    @Emailaddress NVARCHAR(50)
 
AS
BEGIN
    DECLARE @customerId INT;

    INSERT INTO [dbo].[Customers]
(
 Gender,Givenname,Surname,Streetaddress,City,Zipcode,Country,CountryCode,Birthday,Telephonecountrycode,Telephonenumber,Emailaddress
)
VALUES
(
 @Gender,@Givenname,@Surname,  @Streetaddress,@City,@Zipcode,@Country,@CountryCode,@Birthday,@Telephonecountrycode,@Telephonenumber,@Emailaddress
)

SET @customerId = SCOPE_IDENTITY();


SELECT TOP 1 *
FROM Customers
WHERE CustomerId = @customerId
ORDER by CustomerId DESC;

END
GO
