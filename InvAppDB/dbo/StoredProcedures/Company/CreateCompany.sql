CREATE PROCEDURE [dbo].[CreateCompany]
	@CompanyName nvarchar(max),
	@CompanyEmail nvarchar(max),
	@CIF nvarchar(max),
	@UserName nvarchar(max),
	@UserEmail nvarchar(max),
	@UserPassword nvarchar(max)
AS
BEGIN
		INSERT INTO Companies (CompanyName, Email, CIF) 
		VALUES (@CompanyName, @CompanyEmail, @CIF)

		INSERT INTO Users (UserName, UserPassword, Email) 
		VALUES (@UserName, @UserPassword, @UserEmail)

		INSERT INTO CompanyUsers(CompanyID, UserID, RoleID)
		VALUES (
		(SELECT ID FROM Companies WHERE CIF = @CIF),
		(SELECT ID FROM Users WHERE Email = @UserEmail),
		(SELECT ID FROM Roles WHERE RoleName = 'Admin')
		);
END
