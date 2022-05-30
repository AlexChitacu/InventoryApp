CREATE PROCEDURE [dbo].[GetUserByName]
	@UserName nvarchar(max)
AS
BEGIN
	SELECT * FROM Users WHERE UserName = @UserName;
END
