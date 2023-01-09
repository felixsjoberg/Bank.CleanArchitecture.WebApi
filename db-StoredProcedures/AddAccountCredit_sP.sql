SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAccountCredit]
    @accountId int,
    @creditDeposit decimal(13,2)

AS
BEGIN
    DECLARE @sourceBalance MONEY;
    
    SELECT @sourceBalance = Balance FROM accounts WHERE AccountId = @accountId;  

    UPDATE accounts SET balance = balance + @creditDeposit WHERE AccountId = @accountId;

    INSERT INTO transactions (AccountId, [Date],[Type],Operation, Amount, balance)
    VALUES (@accountId, CURRENT_TIMESTAMP,'Credit','Credit Deposit', @creditDeposit,  @sourceBalance + @creditDeposit);
    
    SELECT *
    FROM Transactions
    WHERE TransactionId = SCOPE_IDENTITY()
END
GO
