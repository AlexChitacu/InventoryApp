CREATE PROCEDURE [dbo].[GetUserByCredentials]
	@UserName nvarchar(max),
	@UserPassword nvarchar(max)
AS
BEGIN
	SELECT * FROM Users WHERE UserName = @UserName AND UserPassword = @UserPassword;
END