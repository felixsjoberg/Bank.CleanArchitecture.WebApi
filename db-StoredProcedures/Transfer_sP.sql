SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Transfer]
    @accountId int,
    @operation NVARCHAR(50),
    @transferAmount decimal(13,2),
    @destinationAccountNumber NVARCHAR(50)
AS
BEGIN
    DECLARE @sourceBalance MONEY;
    DECLARE @destinationBalance MONEY;
    DECLARE @OperationResponse NVARCHAR(50);
    DECLARE @count int;

    SELECT @sourceBalance = Balance FROM accounts WHERE AccountId = @accountId;
    SELECT @destinationBalance = Balance FROM accounts WHERE AccountId = @destinationAccountNumber;
    set @OperationResponse ='Collection from Another Bank';

    IF @sourceBalance < @transferAmount
    BEGIN
      return;
    END;

    -- Transfer between accounts, must be owner of both accs. 
    IF @operation LIKE 'Tr%'
    BEGIN
        SELECT @count = COUNT(*) FROM Accounts
        WHERE AccountId = @accountId OR AccountId = @destinationAccountNumber

            IF @count = 2
            SET @OperationResponse = @operation;
            
            ELSE
            return ;
    END;

    UPDATE accounts SET balance = balance - @transferAmount WHERE AccountId = @accountId;
    UPDATE accounts SET balance = balance + @transferAmount WHERE AccountId = @destinationAccountNumber;

    INSERT INTO transactions (AccountId, [Date],[Type],Operation, Amount, balance,Account)
    VALUES (@accountId, CURRENT_TIMESTAMP,'Debit',@operation, @transferAmount * (-1),  @sourceBalance - @transferAmount,@destinationAccountNumber);
    
    INSERT INTO transactions (AccountId, [Date],[Type],Operation, amount,  balance,Account)
    VALUES (@destinationAccountNumber, CURRENT_TIMESTAMP,'Debit',@OperationResponse, @transferAmount,  @destinationBalance + @transferAmount,@accountId);

    SELECT *
  FROM Transactions
  WHERE TransactionId = SCOPE_IDENTITY()
    
END
GO
