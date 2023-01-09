SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser] 
    @UserId nvarchar(100),
    @Email NVARCHAR(50),
    @Password NVARCHAR(50),
    @Role NVARCHAR(50)

    
AS
BEGIN
INSERT INTO [User](UserId,Email,[Password],[Role])
VALUES (@UserId,@Email,@Password,@Role)
     
END
GO
